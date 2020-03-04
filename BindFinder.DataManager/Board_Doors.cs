using BindFinder.AppModels.Boards;
using Geocoding;

namespace BindFinder.DataManager
{
    internal sealed class Board_Doors : IBoard
    {
        #region Interface implementation
        public string ID => this.Dix.ToString();
        public string Supplier { get; }
        public string Code { get; }
        public BoardAddress Address { get; }
        public string Side { get; }
        public string Size { get; }
        public string Type { get; }
        public bool Lighting { get; }
        public BoardMetrics Metrics { get; }
        public string URL_Photo { get; }
        public string URL_Map { get; }
        public Location Location { get; }
        public string Provider { get; }
        public bool IsChecked { get; set; }

        #endregion
        private readonly int Dix;
        //public bool Deleted { get; }
        //public string PlaceCity { get; }
        //public int D_ID { get; }
        //public int CityID { get; }

        internal Board_Doors(DBSet.NosDataTableRow row)
        {
            this.Dix = row.id;
            this.Supplier = row.supplier.Trim();
            this.Code = row.code.Trim();
            this.Address = new BoardAddress {
                City = row.city.Trim(),
                Description = row.description.Trim(),
                District = null,
                Region = null,
                Street = row.street.Trim(),
                StreetNumber = row.streetnumber.Trim()
            };
            this.Side = row.side;
            this.Size = row.size;
            this.Type = row.type.Trim();
            this.Lighting = (int)row.lighting == 0 ? false : true;
            this.Metrics = new BoardMetrics { OTS = (int)row.ots, GRP = (float)row.grp };
            this.Location = new Location((double)row.latitude, (double)row.longitude);
            this.Provider = "Infopanel";            

            this.URL_Photo = @"http://www.doors-c.com.ua/pict/PHOTOS/" + row.cityshort + @"/" + $"{row.d_id}_{row.id}.jpg";
            this.URL_Map = @"http://www.doors-c.com.ua/pict/SHEM/" + row.cityshort + @"/" + $"{row.id}.jpg";
        }        
    }
}
