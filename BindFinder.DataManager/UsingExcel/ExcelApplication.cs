using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace BindFinder.DataManager.UsingExcel
{
    class ExcelApplication : IDisposable
    {
        protected Excel.Application xlApp = null;
        protected Excel.Workbook xlWorkBook = null;
        private System.Globalization.CultureInfo oldCultureInfo;
        protected virtual void InitializeExcelApplication()
        {
            try
            {
                oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                this.xlApp = new Excel.Application();
                this.xlApp.UserControl = false;
                this.xlApp.ScreenUpdating = false;
                this.xlApp.EnableEvents = false;
                this.xlApp.DisplayAlerts = false;
                this.xlApp.Visible = false;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка инициализации приложения Excel", ex);
            }
        }
        protected virtual void ExitExcelApplication(bool quit = true)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCultureInfo;
            xlApp.UserControl = true;
            xlApp.ScreenUpdating = true;
            xlApp.EnableEvents = true;
            xlApp.DisplayAlerts = true;

            if (quit)
                xlApp.Quit();
            else
                this.xlApp.Visible = true;
        }
        protected Excel.Workbook OpenWorkbook(string filePath, bool readOnly = true)
        {
            if (this.xlApp == null)
                throw new Exception("Ошибка чтения файла Excel. Приложение не инициализировано (xlApp = null)");

            Excel.Workbook book = null;
            try
            {
                book = xlApp.Workbooks.Open(filePath, ReadOnly: readOnly);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка чтения файла Excel.", ex);
            }
            if (book == null)
                throw new Exception("Ошибка чтения файла Excel (xlWorkBook = null).");

            return book;
        }
        #region Disposing Logic
        private bool iDisposed = false;
        public void Dispose()
        {
            if (!iDisposed)
            {
                iDisposed = true;
                ReleaseUnmanaged();
                GC.SuppressFinalize(this); //говорим сборщику мусора, что наш объект уже освободил ресурсы
            }
        }
        protected void ReleaseUnmanaged()
        {
            //Release(xlWorkSheet);
            Release(xlWorkBook);
            Release(xlApp);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void Release(object sender)
        {
            try
            {
                if (sender != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sender);
                    sender = null;
                }
            }
            catch (Exception) { sender = null; }
        }

        #endregion
    }
}
