using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindFinder.AppModels.Binds;
using Geocoding;
using Ookii.Dialogs;

namespace BindFinder.DataManager.Binds.Readers
{
    class StringArrayReader : IProcessor
    {
        private string[] lines;
        private IGeocoder _geocoder;

        public StringArrayReader(string[] strings, IGeocoder coder)
        {
            this.lines = strings;
            this._geocoder = coder;
        }

        public void StartProcess(ProgressDialog dialog, DoWorkEventArgs e)
        {
            List<Bind> binds = new List<Bind>();

            int count = lines.Length;
            dialog.Maximum = count;
            int done = 0;

            foreach (var line in lines)
            {
                if (dialog.CancellationPending)
                    break;

                Bind bind = BuildBind(_geocoder, line);
                binds.Add(bind);
                done++;
                dialog.ReportProgress(done, null, $"Обработано {done} из {count}.");
            }
            e.Result = binds;
        }
        internal static Bind BuildBind(Geocoding.IGeocoder geocoder, string address)
        {
            if (Geocoding.Location.TryParse(address, out Geocoding.Location location))
                return BuildBind(geocoder, location);
            else
            {
                try
                {
                    IEnumerable<Address> addresses = geocoder.Geocode(address);
                    return Bind.Create(address, addresses);
                }
                catch (Exception ex)
                {
                    return Bind.Create(address, ex);
                }
            }
        }
        internal static Bind BuildBind(Geocoding.IGeocoder geocoder, Location location)
        {
            try
            {
                IEnumerable<Address> addresses = (geocoder as Geocoding.Google.GoogleGeocoder) .ReverseGeocode(location);
                return Bind.Create(location, addresses);
            }
            catch (Exception ex)
            {
                return Bind.Create(location.ToString(), ex);
            }
        }
    }
}
