using Ookii.Dialogs;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BindFinder.Dialogs
{
    public partial class GeocoderSettings : Form
    {
        public GeocoderSettings()
        {
            InitializeComponent();
        }

        private void _primaryPanel_Paint(object sender, PaintEventArgs e)
        {
            Ookii.Dialogs.DialogHelper.DrawThemeBackground(e.Graphics, AdditionalVisualStyleElements.TaskDialog.PrimaryPanel, _primaryPanel.ClientRectangle, e.ClipRectangle);
        }

        private void _secondaryPanel_Paint(object sender, PaintEventArgs e)
        {
            Ookii.Dialogs.DialogHelper.DrawThemeBackground(e.Graphics, AdditionalVisualStyleElements.TaskDialog.SecondaryPanel, _secondaryPanel.ClientRectangle, e.ClipRectangle);
        }
        private void GeocoderSettings_Load(object sender, EventArgs e)
        {
            cmbGeocoder.SelectedItem = "Google Maps";
            txtAPIKey.Text = Helpers.GeocoderHelper.GoogleAPIKey;
            string lang = Helpers.GeocoderHelper.QueryLanguage;
            if (lang == "ru")
                radRus.Checked = true;
            else if (lang == "uk")
                radUkr.Checked = true;
            else if (lang == "en")
                radEng.Checked = true;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string message = "Для использования сервиса Google Maps необходимо наличие API ключа. Вы можете зарегистрировать его на сайте Google Clouds.\n\nПерейти на сайт Google Clouds?";
            if (MessageBox.Show(message, "Google Maps API", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Process.Start(@"https://cloud.google.com/maps-platform/");
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            Helpers.GeocoderHelper.GoogleAPIKey = txtAPIKey.Text;
            if (radRus.Checked)
                Helpers.GeocoderHelper.QueryLanguage = "ru";
            if (radUkr.Checked)
                Helpers.GeocoderHelper.QueryLanguage = "uk";
            if (radEng.Checked)
                Helpers.GeocoderHelper.QueryLanguage = "en";

            this.DialogResult = DialogResult.OK;
        }
    }
}
