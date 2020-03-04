
namespace BindFinder.DataManager.Boards.Readers
{
    public class BoardsReadParameters
    {
        public string DataPath { get; }
        internal BoardsReadParameters(string databasePath)
        {
            this.DataPath = databasePath;
        }
    }
    public class BoardsReadParameters_Doors : BoardsReadParameters
    {
        public string Year { get; }
        public BoardsReadParameters_Doors(string databasePath, string year) : base(databasePath)
        {
            this.Year = year;
        }
    }
    public class BoardsReadParameters_Outhub : BoardsReadParameters
    {
        public bool DownloadGrid { get; }
        public BoardsReadParameters_Outhub(string databasePath, bool downloadGrid) : base(databasePath)
        {
            this.DownloadGrid = downloadGrid;
        }
    }
}
