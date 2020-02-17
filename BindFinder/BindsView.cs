using BindFinder.AppModels.Binds;
using BindFinder.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BindFinder
{
    public partial class BindsView : Form, Updater.IUpdatableApplication
    {
        private readonly Updater.Updater _updater;
        public BindsView()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Map_Marker_Grey_Green_Icon;
            InitializeListView();
            radShowStaticMap.Checked = Properties.Settings.Default.ShowStaticMap;
            _updater = new Updater.Updater(this);
        }
        private void InitializeListView()
        {
            olvColumn_Address.AspectGetter = delegate (object row)
            {
                Bind bind = row as Bind;
                if (bind.Error != null)
                    return bind.Error.Message;
                else
                    return bind.Address.ToString();
            };
            olvColumn_Description.AspectGetter = delegate (object row) { return (row as Bind).Description; };
            olvColumn_OriginalAddress.AspectGetter = delegate (object row) { return (row as Bind).OriginalAddress; };
        }
        private void OlvBinds_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            if ((e.Model as Bind).Error != null)
                e.Item.BackColor = Color.LightCoral;
        }

        private void SetupMapToPictureBox(Bind bind)
        {
            pictureSchema.Image = null;

            if (radShowStaticMap.Checked)
            {
                lblOpenMap.Visible = false;
                lbltOpenMap.Visible = true;

                if (bind == null || bind.Error != null) return;

                if (string.IsNullOrEmpty(Helpers.GeocoderHelper.GoogleAPIKey)) return;
                var stMap = new Geocoding.Google.GoogleStaticMap(Helpers.GeocoderHelper.GoogleAPIKey) { Scale = 2, Zoom = 19 };
                stMap.Language = Helpers.GeocoderHelper.QueryLanguage;
                var uri = stMap.BuildUri(bind.Address.Coordinates);
                pictureSchema.Image = Helpers.ImageHelper.GetImage(uri);
            }
            else
            {
                lblOpenMap.Visible = true;
                lbltOpenMap.Visible = false;
            }
        }
        private void BindsView_Shown(object sender, EventArgs e)
        {
            var reader = Helpers.DoorsHelper.GetDataReader(false);
            if (reader != null)
            {
                reader.ReadDataAsync();
            }
            _updater.DoUpdate(Updater.UpdateMethod.DownloadAndUpdateOnRequest);
        }
        private void BindsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.ShowStaticMap != radShowStaticMap.Checked)
            {
                Properties.Settings.Default.ShowStaticMap = radShowStaticMap.Checked;
                Properties.Settings.Default.Save();
            }
        }
        private void MnuAddBindsInputBox_Click(object sender, EventArgs e)
        {
            var lines = Dialogs.Helper.GetBindsStrings();
            if (lines == null || lines.Length == 0) return;

            var coder = Helpers.GeocoderHelper.GetGeocoder();
            if (coder == null) return;

            lines = lines.Where(a => !string.IsNullOrEmpty(a)).Distinct().ToArray();
            var dialog = new DataManager.Binds.Readers.ReaderBuilder().Build(lines, coder);
            dialog.RunWorkerCompleted += Coder_RunWorkerCompleted;
            dialog.ShowDialog(this);
        }
        private void MnuSaveBindsToExcel_Click(object sender, EventArgs e)
        {
            var binds = olvBinds.CollectCheckedObjects<Bind>(ObjectListViewHelper.ObjectListViewCollector.All)
                .Where(a => a.Error == null).ToList();
            if (binds.Count == 0) return;

            var progress = new DataManager.Binds.Writers.WriterBuilder().Build(binds);
            progress.RunWorkerCompleted += Progress_RunWorkerCompleted;
            progress.ShowDialog(this, binds);
        }
        private void Coder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Ошибка импорта адресов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (e.Cancelled)
            { }
            else
            {
                List<Bind> binds = e.Result as List<Bind>;
                olvBinds.ClearObjects();
                olvBinds.SetObjects(binds);
                lblBindsCount.Visible = true;
                lblBindsCount.Text = $"Количество адресов в датасете - {binds.Count}";
            }
        }
        private void Progress_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (e.Result != null)
            {
                System.Diagnostics.Process.Start(e.Result.ToString());
            }
        }

        #region IUpdatableApplication Interface
        public string ApplicationName => "BindFinder";
        public string ApplicationID => "BindFinder";
        public System.Reflection.Assembly ApplicationAssembly => System.Reflection.Assembly.GetExecutingAssembly();
        public Icon ApplicationIcon => Properties.Resources.Map_Marker_Grey_Green_Icon;
        public Image ApplicationImage => Properties.Resources.Map_Marker_Grey_Green_96;
        public Uri UpdateXmlLocation { get; } = new Uri("http://oohelp.net/software/versions.xml");
        public Form Context => this;
        public Version Version => new Version(System.Diagnostics.FileVersionInfo.GetVersionInfo(ApplicationAssembly.Location).FileVersion);




        #endregion

        private void PanelBindInfo_Resize(object sender, EventArgs e)
        {
            panelBindMap.Height = panelBindMap.Width;
        }

        private void OlvBinds_SelectionChanged(object sender, EventArgs e)
        {
            lblBindCoordinates.Text = null;
            if (olvBinds.SelectedObject == null) return;
            Bind b = olvBinds.SelectedObject as Bind;
            SetupMapToPictureBox(b);

            if (b.Error != null)
            {
                lblBindCoordinates.Text = "Ошибка: ";
                if (b.Error is Geocoding.Google.GoogleGeocodingException)
                    lblBindCoordinates.Text += $"Status: {(b.Error as Geocoding.Google.GoogleGeocodingException).Status}";
                else
                    lblBindCoordinates.Text += b.Error.Message + (b.Error.InnerException == null ? null : $"\nInner: {b.Error.InnerException}");
            }
            else
            {
                lblBindCoordinates.Text = $"Lat: {b.Address.Coordinates.Latitude.ToString()}\nLon: {b.Address.Coordinates.Longitude.ToString()}";
            }
        }

        private void RadShowStaticMap_CheckedChanged(object sender, EventArgs e)
        {
            lblBindCoordinates.Text = null;
            Bind b = null;
            if (olvBinds.SelectedObject != null)
                b = olvBinds.SelectedObject as Bind;              
            SetupMapToPictureBox(b);
        }

        private void MnuStartXMLRequest_Click(object sender, EventArgs e)
        {
            if (olvBinds.SelectedObject == null) return;
            var _geocoder = GeocoderHelper.GetGeocoder() as Geocoding.Google.GoogleGeocoder;
            if (_geocoder == null) return;
            _geocoder.Language = Helpers.GeocoderHelper.QueryLanguage;
            System.Diagnostics.Process.Start(_geocoder.BuildWebRequest((olvBinds.SelectedObject as Bind).OriginalAddress));
        }

        private void MnuEditBind_Click(object sender, EventArgs e)
        {
            if (olvBinds.SelectedObject == null) return;

            using (EditBindDialog dlg = new EditBindDialog(olvBinds.SelectedObject as Bind) { Icon = this.Icon, ShowInTaskbar = false })
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    olvBinds.UpdateObject(dlg.Bind);
            }
        }

        private void MnuLoadSavedBinds_Click(object sender, EventArgs e)
        {
            string file = Dialogs.Helper.OpenExcelFile();
            if (string.IsNullOrEmpty(file)) return;

            var coder = new DataManager.Binds.Readers.ReaderBuilder().Build(file);
            coder.RunWorkerCompleted += Coder_RunWorkerCompleted;
            coder.ShowDialog(this);
        }

        private void MnuGotoBoardsSeach_Click(object sender, EventArgs e)
        {
            BoardsView boardView = new BoardsView();
            var binds = olvBinds.CollectCheckedObjects<Bind>(ObjectListViewHelper.ObjectListViewCollector.All).Where(a=>a.Error == null).ToList();
            boardView.SetBinds(binds);
            boardView.Show();
        }

        private void PictureSchema_DoubleClick(object sender, EventArgs e)
        {
            if(olvBinds.SelectedObject == null || pictureSchema.Image == null) return;
            Bind bind = olvBinds.SelectedObject as Bind;

            using (Ookii.Dialogs.ImageViewDialog dlg = new Ookii.Dialogs.ImageViewDialog())
            {
                dlg.Image = pictureSchema.Image;
                dlg.WindowTitle = dlg.Content = bind.Address.FormattedAddress;
                dlg.ShowDialog(this);
            }
        }

        private void MnuGeocodingSettings_Click(object sender, EventArgs e)
        {
            using (Dialogs.GeocoderSettings geocoderSettings = new Dialogs.GeocoderSettings())
            {
                geocoderSettings.ShowDialog();
            }
        }

        private void MnuBoardsReadSettings_Click(object sender, EventArgs e)
        {
            using (var dlg = new Dialogs.BoardsReadSettings())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AppModels.DataReaders.IBoardsReader reader = Helpers.DoorsHelper.GetDataReader(false);
                    if (reader != null)
                    {
                        reader.ReadDataAsync();
                    }                    
                }
            }
        }

        private void LblOpenMap_LinkClicked(object sender, EventArgs e)
        {
            if (olvBinds.SelectedObject == null) return;

            if (olvBinds.SelectedObject is Bind bind && bind.Error == null)
            {
                string link = @"https://www.google.com/maps/search/" + bind.Address.Coordinates.ToString();
                System.Diagnostics.Process.Start(link);
            }
        }

        private void MnuCheckUpdates_Click(object sender, EventArgs e) => _updater.DoUpdate(Updater.UpdateMethod.Manual);

        private void MnuShowAbout_Click(object sender, EventArgs e)
        {
            using (About dlg = new About())
                dlg.ShowDialog(this);
        }

        private void MnuAddBindsExcel_Click(object sender, EventArgs e)
        {
            var excel = Dialogs.Helper.OpenExcelFile(!Properties.Settings.Default.DoNotShowImportExcelMessage);
            if (string.IsNullOrEmpty(excel)) return;

            var coder = Helpers.GeocoderHelper.GetGeocoder();
            if (coder == null) return;
            
            var dialog = new DataManager.Binds.Readers.ReaderBuilder().Build(excel, coder);
            dialog.RunWorkerCompleted += Coder_RunWorkerCompleted;
            dialog.ShowDialog(this);
        }

        private void MnuSaveBindsToKml_Click(object sender, EventArgs e)
        {
            var binds = olvBinds.CollectCheckedObjects<Bind>(ObjectListViewHelper.ObjectListViewCollector.All)
                .Where(a => a.Error == null).ToList();
            if (binds.Count == 0) return;

            string path = Dialogs.Helper.SaveAsKml();
            if (string.IsNullOrEmpty(path)) return;

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            var progress = new DataManager.Binds.Writers.WriterBuilder().Build(binds, path);
            progress.RunWorkerCompleted += Progress_RunWorkerCompleted;
            progress.ShowDialog(this, binds);
        }
    }
}
