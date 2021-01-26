using System;

namespace BindFinder.DataManager.Boards.Readers
{
    public class ReaderBuilder
    {
        
        
        public AppModels.DataReaders.IBoardsReader Build(BoardsReadParameters p)
        {
            if (p is BoardsReadParameters_Doors)
            {
                BoardsReadParameters_Doors b = p as BoardsReadParameters_Doors;
                string dbFile = $"_{b.Year}nos.dbf";
                if (!System.IO.File.Exists(System.IO.Path.Combine(b.DataPath, dbFile)))
                    throw new Exception($"Файл {dbFile} не найден в папке: {b.DataPath}");

                dbFile = "cities.dbf";
                if (!System.IO.File.Exists(System.IO.Path.Combine(b.DataPath, dbFile)))
                    throw new Exception($"Файл {dbFile} не найден в папке: {b.DataPath}");

                BoardsReader_Doors r = new BoardsReader_Doors
                {
                    ConnectionString = $"Provider = VFPOLEDB.1; Data Source = {b.DataPath}",
                    Year = b.Year
                };
                return r;
            }
            else if (p is BoardsReadParameters_Outhub)
            {
                BoardsReadParameters_Outhub b = p as BoardsReadParameters_Outhub;
                BoardsReader_Outhub r = new BoardsReader_Outhub
                {
                    FilePath = b.DataPath,
                    DownloadGrid = b.DownloadGrid,
                    OuthubOnly = b.OuthubOnly                    
                };
                return r;
            }
            return null;
        }
      
    }
}
