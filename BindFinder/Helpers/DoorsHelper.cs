using BindFinder.AppModels.DataReaders;
using BindFinder.DataManager;
using System;


namespace BindFinder.Helpers
{
    static class DoorsHelper
    {
        private const string noDoorsPath = "Необходимо указать путь к папке, в которой лежат файлы базы DOORS на вашем компьютере.\nОбычно это папка DATA, которая находится внутри папки Infopanel.\n\nЭто можно сделать в настройках программы.";
        private static IBoardsReader DoorsReader = null;
        public static string DoorsReadingYear
        {
            get => string.IsNullOrEmpty(Properties.Settings.Default.DoorsReadingYear) ? DateTime.Now.Year.ToString() : Properties.Settings.Default.DoorsReadingYear;
            set
            {
                Properties.Settings.Default.DoorsReadingYear = (string.IsNullOrEmpty(value) || value == DateTime.Now.Year.ToString()) ? null : value;
                Properties.Settings.Default.Save();
            }
        }
        public static string DoorsDataPath
        {
            get => Properties.Settings.Default.DoorsDataPath;
            set
            {
                if (string.IsNullOrEmpty(value))
                    DoorsReader = null;
                else
                {
                    try
                    {
                        DataManager.Boards.Readers.ReaderBuilder b = new DataManager.Boards.Readers.ReaderBuilder();
                        DataManager.Boards.Readers.BoardsReadParameters_Doors p = new DataManager.Boards.Readers.BoardsReadParameters_Doors(value, DoorsReadingYear);
                        DoorsReader = b.Build(p);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Ошибка подключения к Infopanel: \n" + ex.Message, "Ошибка", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return;
                    }                   
                }
                Properties.Settings.Default.DoorsDataPath = value;
                Properties.Settings.Default.Save();
            }
        }
        public static IBoardsReader GetDataReader(bool pathRequest = true)
        {
            if (DoorsReader == null)
            {
                if (string.IsNullOrEmpty(DoorsDataPath))
                {
                    if (pathRequest)
                        System.Windows.Forms.MessageBox.Show(noDoorsPath, "База данных Infopanel", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

                    return null;
                }

                try
                {
                    DataManager.Boards.Readers.ReaderBuilder b = new DataManager.Boards.Readers.ReaderBuilder();
                    DataManager.Boards.Readers.BoardsReadParameters_Doors p = new DataManager.Boards.Readers.BoardsReadParameters_Doors(DoorsDataPath, DoorsReadingYear);
                    DoorsReader = b.Build(p);
                }
                catch (Exception ex)
                {
                    if (pathRequest)
                        System.Windows.Forms.MessageBox.Show("Ошибка подключения к Infopanel: \n" + ex.Message, "Ошибка", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return null;
                }
                
            }
            return DoorsReader;
        }
    }
}
