using System.Windows.Forms;

namespace BindFinder.Dialogs
{
    static class Helper
    {
        public static string[] GetBindsStrings()
        {
            using (Ookii.Dialogs.InputDialog dlg = new Ookii.Dialogs.InputDialog
            {
                Multiline = true,
                MaxLength = 0,
                MainInstruction = "Список адресов",
                WindowTitle = "Список адресов",
                Content = "Введите список адресов или координат для поиска в Google Maps." +
                    "\n\nДля лучшего распознавания адресов рекомендуется вводить их в формате: Город, Улица, № дома." +
                    "\nЕсли вы используете координаты, то они должны быть приведены в формат: latitude,longitude. " +
                    "Например: 48.8582573,2.2945111"
            })
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return dlg.InputLines;
                else
                    return null;
            }
        }
        public static string[] GetBoardsIDs()
        {
            using (Ookii.Dialogs.InputDialog dlg = new Ookii.Dialogs.InputDialog
            {
                Multiline = true,
                MaxLength = 0,
                MainInstruction = "Список номеров",
                WindowTitle = "Список номеров плоскостей",
                Content = "Введите список номеров плоскостей, которые необходимо отметить. Для плоскостей из Infopanel используйте коды DOORS, в остальных случаях внутренние номера"
            })
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return dlg.InputLines;
                else
                    return null;
            }
        }
        private static string OpenExcelFile()
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Title = "Открытие документа";
                of.Filter = "Файлы Excel|*.xlsx;*.xls;*.xlsm";
                if (of.ShowDialog() == DialogResult.OK && System.IO.File.Exists(of.FileName))
                {
                    return of.FileName;
                }
                else return null;
            }
        }
        internal static string OpenExcelFile(bool showTaskbar = false)
        {
            if (showTaskbar)
            {
                Ookii.Dialogs.TaskDialog dlg = new Ookii.Dialogs.TaskDialog {
                    AllowDialogCancellation = true,
                    ButtonStyle = Ookii.Dialogs.TaskDialogButtonStyle.CommandLinks,
                    WindowTitle = "Импорт",
                    MainInstruction = "Импорт привязок из Excel файла",
                    Content = "Укажите файл с адресами. В таблице должно быть две колонки. В первой колонке (А) - адрес или координаты точки, во второй (В) - описание."+
                    "\nЧтение начинается с первой строки (таблица без заголовков).",                    
                    VerificationText = "Больше не показывать сообщение"                                    
                };
                Ookii.Dialogs.TaskDialogButton buttOpenFile = new Ookii.Dialogs.TaskDialogButton(Ookii.Dialogs.ButtonType.Custom)
                {
                    CommandLinkNote = "Для лучшего распознавания адресов рекомендуется вводить их в формате: Город, Улица, № дома." +
                    "\nЕсли вы используете координаты, то они должны быть приведены в формат: latitude,longitude. " +
                    "Например: 48.8582573,2.2945111",
                    Text = "Указать файл",
                };
                dlg.Buttons.Add(buttOpenFile);
                dlg.Buttons.Add(new Ookii.Dialogs.TaskDialogButton(Ookii.Dialogs.ButtonType.Cancel));
                var result = dlg.ShowDialog();

                if (dlg.IsVerificationChecked)
                    Properties.Settings.Default.DoNotShowImportExcelMessage = true;

                if(result == buttOpenFile)
                    return OpenExcelFile();

                return null;
            }
            else
            {
                return OpenExcelFile();
            }
        }
        internal static string SaveAsKml()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Файлы Kml|*.kml";
                if (dlg.ShowDialog()== DialogResult.OK)
                {
                    return dlg.FileName;
                }
            }
            return string.Empty;
        }
    }
}
