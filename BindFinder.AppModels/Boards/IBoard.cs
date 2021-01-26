using Geocoding;

namespace BindFinder.AppModels.Boards
{
    public interface IBoard
    {
        string ProviderID { get; }
        string Supplier { get; set; }
        string SupplierCode { get; }
        BoardAddress Address { get; set; }
        Location Location { get; }
        string Side { get; }
        string Size { get; }
        string Type { get; }
        bool Lighting { get; }
        MediaParameters MediaParameters { get; }
        string URL_Photo { get; }
        string URL_Map { get; }
        string Provider { get; }
        bool IsChecked { get; set; }
    }
}
