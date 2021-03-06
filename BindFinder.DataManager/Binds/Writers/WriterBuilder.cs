﻿using BindFinder.AppModels.Binds;
using System.Collections.Generic;


namespace BindFinder.DataManager.Binds.Writers
{
    public class WriterBuilder
    {
        private IProcessor Writer;
        public Ookii.Dialogs.ProgressDialog Build(List<Bind> binds)
        {
            this.Writer = new ExcelBindsWriter(binds);
            return CreateDialog();
        }
        public Ookii.Dialogs.ProgressDialog Build(List<Bind> binds, string kmlPath)
        {
            this.Writer = new KmlBindsWriter(binds, kmlPath);
            return CreateDialog();
        }

        private Ookii.Dialogs.ProgressDialog CreateDialog()
        {
            Ookii.Dialogs.ProgressDialog progress = new Ookii.Dialogs.ProgressDialog
            {
                ShowCancelButton = false,
                WindowTitle = "Экспорт точек",
                Text = "Экспорт привязок",
                ShowTimeRemaining = true
            };
            progress.DoWork += Progress_DoWork;

            return progress;
        }
        private void Progress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (this.Writer == null) return;

            if (this.Writer is System.IDisposable)
            {
                using (this.Writer as System.IDisposable)
                {
                    this.Writer.StartProcess(sender as Ookii.Dialogs.ProgressDialog, e);
                }
            }
            else
            {
                this.Writer.StartProcess(sender as Ookii.Dialogs.ProgressDialog, e);
            }
        }       
    }
}
