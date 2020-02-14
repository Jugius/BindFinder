using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindFinder.DataManager.Binds.Readers
{
    public class ReaderBuilder
    {        
        private IProcessor Reader;
        public Ookii.Dialogs.ProgressDialog Build(string excelFile)
        {
            this.Reader = new SavedExcelReader(excelFile);
            var progress = CreateProgress();
            progress.Text = "Импорт привязок из Excel";            
            return progress;
        }
        public Ookii.Dialogs.ProgressDialog Build(string excelFile, Geocoding.IGeocoder coder)
        {
            this.Reader = new LinesExcelReader(excelFile, coder);
            var progress = CreateProgress();
            progress.Text = "Импорт привязок из Excel";
            return progress;
        }
        public Ookii.Dialogs.ProgressDialog Build(string[] strings, Geocoding.IGeocoder coder)
        {
            this.Reader = new StringArrayReader(strings, coder);
            var progress = CreateProgress();
            progress.Text = "Определение адресов в Google Maps";
            return progress;
        }

        private void Progress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (this.Reader == null) return;

            if (this.Reader is System.IDisposable)
            {
                using (this.Reader as System.IDisposable)
                {
                    this.Reader.StartProcess(sender as Ookii.Dialogs.ProgressDialog, e);
                }
            }
            else
            {
                this.Reader.StartProcess(sender as Ookii.Dialogs.ProgressDialog, e);
            }
        }
        private Ookii.Dialogs.ProgressDialog CreateProgress()
        {
            var progress = new Ookii.Dialogs.ProgressDialog
            {
                ShowCancelButton = true,
                WindowTitle = "Импорт адресов",
                ShowTimeRemaining = true
            };
            progress.DoWork += Progress_DoWork;
            return progress;
        }
    }
}
