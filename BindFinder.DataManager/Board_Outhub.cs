using BindFinder.AppModels.Boards;
using Geocoding;
using System.Globalization;

namespace BindFinder.DataManager
{
    sealed class Board_Outhub : IBoard
    {
        private const string PhotoDir_Prime = @"http://home.prime-group.com.ua/MapTest14/photo/boards/";
        private const string PhotoDir_NotPrime = @"http://outhub.online/aphoto/";
        #region Interface implementation
        public string ProviderID { get; }
        public string Supplier { get; set; }
        public string SupplierCode { get; }
        public BoardAddress Address { get; set; }
        public string Side { get; }
        public string Size { get; }
        public string Type { get; }
        public bool Lighting { get; }
        public MediaParameters MediaParameters { get; }
        public string URL_Photo { get; }
        public string URL_Map { get; }
        public Location Location { get; }
        public string Provider { get; }
        public bool IsChecked { get; set; }

        #endregion

        public Board_Outhub(string outhubTextLine)
        {
            var splitted = outhubTextLine.Split(';');

            string providerId = this.ProviderID = splitted[1];

            string supplierName = splitted[4];
            string supplierCode;

            this.Address = new BoardAddress
            {
                City = splitted[10],
                Description = null,//row.description.Trim(),
                District = splitted[14],
                Region = splitted[11],
                Street = splitted[12],
                StreetNumber = null//row.streetnumber.Trim()
            };
            this.Side = splitted[7];
            this.Size = splitted[8];
            this.Type = splitted[6];
            this.Lighting = string.IsNullOrEmpty(splitted[9]) ? false : true;

            if (int.TryParse(splitted[15], out int dix) && dix > 0)
            {
                var mp = new MediaParameters { DoorsID = dix };

                if (int.TryParse(splitted[16], out int ots)
                && float.TryParse(splitted[17], NumberStyles.Any, CultureInfo.InvariantCulture, out float grp)
                && (ots + grp) > 0)
                {
                    mp.GRP = grp;
                    mp.OTS = ots;
                }
                this.MediaParameters = mp;
            }            

            if (double.TryParse(splitted[19], NumberStyles.Any, CultureInfo.InvariantCulture, out double lat) && double.TryParse(splitted[20], NumberStyles.Any, CultureInfo.InvariantCulture, out double lon))
            {
                this.Location = new Location(lat, lon);
            }
            else
            {
                this.Location = new Location(0, 0);
            }
            //double lat = double.Parse(splitted[19], NumberStyles.Any, CultureInfo.InvariantCulture);
            //double lon = double.Parse(splitted[20], NumberStyles.Any, CultureInfo.InvariantCulture);
            
            this.Provider = "Outhub";

            if (supplierName == "OUTHUB")
            {

                this.URL_Photo = PhotoDir_Prime + providerId + ".jpg";
                this.URL_Map = PhotoDir_Prime + providerId + "s.jpg";

                if (IsPrimeCode(providerId))
                {
                    supplierName = "ПРАЙМ";
                    supplierCode = providerId;
                }
                else
                {
                    supplierCode = splitted[2];
                }
            }
            else
            {
                supplierCode = providerId;
                this.URL_Photo = PhotoDir_NotPrime + splitted[27];
                this.URL_Map = PhotoDir_NotPrime + splitted[28];
            }

            this.Supplier = supplierName;
            this.SupplierCode = supplierCode;
        }
        private static bool IsPrimeCode(string code)
        { 
            string restCode = code.Substring(code.Length - 5);
            if (int.TryParse(restCode, out _))
                return false;
            return true;
        }
    }
}
