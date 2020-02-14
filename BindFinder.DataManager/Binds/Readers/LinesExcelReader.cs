using BindFinder.AppModels.Binds;
using Geocoding;
using Ookii.Dialogs;
using System.Collections.Generic;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;
namespace BindFinder.DataManager.Binds.Readers
{
    internal class LinesExcelReader : UsingExcel.ExcelApplication, IProcessor
    {
        private ProgressDialog ProgressDialog;
        private readonly string excelFile;
        private readonly IGeocoder _geocoder;
        public LinesExcelReader(string excelFile, Geocoding.IGeocoder coder) 
        {
            this.excelFile = excelFile;
            this._geocoder = coder;
        }
        public void StartProcess(ProgressDialog dialog, DoWorkEventArgs e)
        {
            this.ProgressDialog = dialog;
            List<Bind> binds = new List<Bind>();

            ProgressDialog.ReportProgress(-1, null, "Импорт данных..", null);
            InitializeExcelApplication();
            xlWorkBook = OpenWorkbook(this.excelFile);

            try
            {
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
                Excel.Range workRange = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);

                int lastRow = workRange.Row;
                int firstRow = 1;
                int bindsCount = lastRow - firstRow + 1;
                int done = 0;
                this.ProgressDialog.Maximum = bindsCount;

                for (int i = firstRow; i <= lastRow; i++)
                {
                    if (dialog.CancellationPending)
                        break;

                    string address = xlWorkSheet.Range["A" + i].Value?.ToString();
                    string description = xlWorkSheet.Range["B" + i].Value?.ToString();

                    if (!string.IsNullOrEmpty(address))
                    {
                        Bind bind = StringArrayReader.BuildBind(_geocoder, address);
                        bind.Description = description;
                        binds.Add(bind);
                    }
                    
                    done++;
                    dialog.ReportProgress(done, null, $"Обработано {done} из {bindsCount}.");
                }
                e.Result = binds;
            }
            finally
            {
                xlWorkBook.Close();
                ExitExcelApplication();
            }
        }
    }
}