using BindFinder.AppModels.Binds;
using Ookii.Dialogs;
using SharpKml.Dom;
using SharpKml.Engine;
using System.Collections.Generic;
using System.ComponentModel;

namespace BindFinder.DataManager.Binds.Writers
{
    class KmlBindsWriter : IProcessor
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

            dialog.ReportProgress(-1, null, "Экспорт данных..", null);

            Folder f = new Folder();

            foreach (var bind in this.binds)
            {
                var point = new SharpKml.Dom.Point
                {
                    Coordinate = new SharpKml.Base.Vector(bind.Address.Coordinates.Latitude, bind.Address.Coordinates.Longitude)
                };
                var placemark = new Placemark
                {
                    
                    Geometry = point, 
                    Name = string.IsNullOrEmpty(bind.Description) ? bind.Address.FormattedAddress : bind.Description,
                    Address = bind.Address.FormattedAddress,
                    TargetId = bind.Address.PlaceId
                };
                f.AddFeature(placemark);
                //f.AddChild(placemark);
                done++;
                dialog.ReportProgress(done, null, $"Выполнено: {done}/{count}");
            }
            
            KmlFile kml = KmlFile.Create (f, false);
            if (System.IO.File.Exists(this.path))
                System.IO.File.Delete(this.path);
            using (var stream = System.IO.File.OpenWrite(this.path))
            {
                kml.Save(stream);
            }
            e.Result = this.path;
        }
    }
}
