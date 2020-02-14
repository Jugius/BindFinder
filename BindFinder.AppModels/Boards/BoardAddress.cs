namespace BindFinder.AppModels.Boards
{
    public class BoardAddress
    {
        public string Region { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Description { get; set; }
        public string FormattedAddress
        {
            get { return $"{City}, {Street}, {StreetNumber}".TrimEnd(','); }
        }
    }
}
