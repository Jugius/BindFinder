using Geocoding;

namespace BindFinder.AppModels.Boards
{
    public interface IBoard
    {
        string ID { get; }
        string Supplier { get; }
        string Code { get; }
        BoardAddress Address { get; }
        Location Location { get; }
        string Side { get; }
        string Size { get; }
        string Type { get; }
        bool Lighting { get; }
        BoardMetrics Metrics { get; }
        string URL_Photo { get; }
        string URL_Map { get; }
        string Provider { get; }
        bool IsChecked { get; set; }
    }
}
