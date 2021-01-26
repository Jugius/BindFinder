using Microsoft.Win32;
using System.Linq;


namespace BindFinder.Helpers
{
    static class DialogsProvider
    {
        public static string[] GetBindsStrings()
        {
            libControls.Dialogs.InputBoxDialog dlg = new libControls.Dialogs.InputBoxDialog
            {
                Title = "Список адресов",
                MainInstruction = "Список адресов",
                Content = "Введите список адресов или координат для поиска в Google Maps." +
                    "\n\nДля лучшего распознавания адресов рекомендуется вводить их в формате: Город, Улица, № дома." +
                    "\nЕсли вы используете координаты, то они должны быть приведены в формат: latitude,longitude. " +
                    "Например: 48.8582573,2.2945111",
                Multiline = true
            };

            if(dlg.ShowDialog())
                return dlg.InputLines.ToArray();
            else
                return null;            
        }
        public static string ShowSaveAsFileDialog(string initialDirectory = null)
        {

            FileDialog dlg = new SaveFileDialog();
            dlg.Title = "Сохранить как";
            dlg.RestoreDirectory = true;
            dlg.ValidateNames = true;

            dlg.Filter = "Файл Json|*.json|Файл Excel|*.xlsx|Файл Google Map|*.kmz";

            if(initialDirectory != null)
                dlg.InitialDirectory = initialDirectory;

            if(dlg.ShowDialog() == true)
                return dlg.FileName;

            return null;
        }
        public static string ShowOpenFileDialog(string initialDirectory = null)
        {

            FileDialog dlg = new OpenFileDialog();
            dlg.Title = "Открыть файл";
            dlg.RestoreDirectory = true;
            dlg.ValidateNames = true;

            dlg.Filter = "Файлы Json и Excel|*.json;*.xlsx";

            if(initialDirectory != null)
                dlg.InitialDirectory = initialDirectory;

            if(dlg.ShowDialog() == true)
                return dlg.FileName;

            return null;
        }
    }
}
