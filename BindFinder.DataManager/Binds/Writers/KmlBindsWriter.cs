using BindFinder.AppModels.Binds;
using Ookii.Dialogs;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace BindFinder.DataManager.Binds.Writers
{
    sealed class KmlBindsWriter : IProcessor
    {
        private readonly List<Bind> binds;
        private readonly string path;

        public KmlBindsWriter(List<Bind> binds, string kmlPath)
        {
            this.binds = binds;
            this.path = kmlPath;
        }

        public void StartProcess(ProgressDialog dialog, DoWorkEventArgs e)
        {
            int count = dialog.Maximum = binds.Count;
            int done = 0;
            Color c = Color.FromArgb(255, 82, 82);

            dialog.ReportProgress(-1, null, "Экспорт данных..", null);

            var style = new Style();
            style.Id = $"colorIcon_{c.R}_{c.G}_{c.B}";
            style.Icon = new IconStyle();
            style.Icon.Color = new Color32(255, c.B, c.G, c.R);
            style.Icon.ColorMode = ColorMode.Normal;
            style.Icon.Icon = new IconStyle.IconLink(new Uri("http://www.gstatic.com/mapspro/images/stock/503-wht-blank_maps.png"));
            style.Icon.Scale = 1;

            style.Label = new LabelStyle();
            style.Label.Scale = 0;

            var document = new Document();
            document.Name = System.IO.Path.GetFileNameWithoutExtension(this.path);

            foreach (var bind in this.binds)
            {
                var placemark = CreatePlacemark(bind, style);
                document.AddFeature(placemark);
                
                done++;
                dialog.ReportProgress(done, null, $"Выполнено: {done}/{count}");
            }

            document.AddStyle(style);

            KmlFile kml = KmlFile.Create(document, false);
            KmzFile k = KmzFile.Create(kml);

            if (System.IO.File.Exists(this.path))
                System.IO.File.Delete(this.path);
            
            using (var stream = System.IO.File.OpenWrite(this.path))
            {
                k.Save(stream);
            }
            e.Result = this.path;
        }
        private static Placemark CreatePlacemark(Bind bind, Style style)
        {
            string name = string.IsNullOrEmpty(bind.Description) ? bind.Address.FormattedAddress : bind.Description;

            var placemark = new Placemark();
            placemark.Name = name;
            
            var styleId = style.Id;
            placemark.StyleUrl = new Uri($"#{styleId}", UriKind.Relative);
            placemark.Geometry = new SharpKml.Dom.Point
            {
                Coordinate = new Vector(bind.Address.Coordinates.Latitude, bind.Address.Coordinates.Longitude)
            };
            placemark.Description = new Description { Text = bind.Address.FormattedAddress };
            //placemark.Address = bind.Address.FormattedAddress;
            placemark.TargetId = bind.Address.PlaceId;

            return placemark;
        }
    }
}
