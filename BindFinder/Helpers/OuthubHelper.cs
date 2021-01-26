using BindFinder.AppModels.DataReaders;


namespace BindFinder.Helpers
{
    static class OuthubHelper
    {
        private const string noGridInCash = "База плоскостей OUTHUB будет загружена с сервера.\nЭто займет некоторое время, пожалуйста, наберитесь терпения.";
        private static readonly string OuthubGridFile = System.IO.Path.Combine(ConfigHelper.RoamingDirectory, "OuthubGrid.json");
        private static IBoardsReader OuthubReader = null;
        public static IBoardsReader GetDataReader(bool messageRequest = true)
        {
            if (OuthubReader == null)
            {
                bool notExist = !System.IO.File.Exists(OuthubGridFile);
                DataManager.Boards.Readers.BoardsReadParameters_Outhub p = new DataManager.Boards.Readers.BoardsReadParameters_Outhub(OuthubGridFile, notExist);
                p.OuthubOnly = true;
                if (notExist && messageRequest)
                    System.Windows.Forms.MessageBox.Show(noGridInCash, "База данных OUTHUB", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                DataManager.Boards.Readers.ReaderBuilder b = new DataManager.Boards.Readers.ReaderBuilder();
                OuthubReader = b.Build(p);    
            }
            return OuthubReader;
        }
    }
}
