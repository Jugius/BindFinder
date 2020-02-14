using Ookii.Dialogs;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BindFinder.Dialogs
{
    public partial class BoardsReadSettings : Form
    {
        public BoardsReadSettings()
        {
            InitializeComponent();
        }

        private void BoardsReadSettings_Load(object sender, EventArgs e)
        {
            txtDoorsDataPath.Text = Helpers.DoorsHelper.DoorsDataPath;
            txtDoorsReadingYear.Text = Helpers.DoorsHelper.DoorsReadingYear;
        }
        private void _primaryPanel_Paint(object sender, PaintEventArgs e)
        {
            Ookii.Dialogs.DialogHelper.DrawThemeBackground(e.Graphics, AdditionalVisualStyleElements.TaskDialog.PrimaryPanel, _primaryPanel.ClientRectangle, e.ClipRectangle);
        }

        private void _secondaryPanel_Paint(object sender, PaintEventArgs e)
        {
            Ookii.Dialogs.DialogHelper.DrawThemeBackground(e.Graphics, AdditionalVisualStyleElements.TaskDialog.SecondaryPanel, _secondaryPanel.ClientRectangle, e.ClipRectangle);
        }
        private void BtnDoorsDataPath_Click(object sender, EventArgs e)
        {
            Ookii.Dialogs.VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog { Description = "Укажите папку DATA" };
            if (!string.IsNullOrEmpty(txtDoorsDataPath.Text) && System.IO.Directory.Exists(txtDoorsDataPath.Text))
                dlg.SelectedPath = txtDoorsDataPath.Text;

            if (dlg.ShowDialog() == DialogResult.OK)
                txtDoorsDataPath.Text = dlg.SelectedPath;
            else
                txtDoorsDataPath.Text = null;
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            Helpers.DoorsHelper.DoorsReadingYear = txtDoorsReadingYear.Text;
            Helpers.DoorsHelper.DoorsDataPath = txtDoorsDataPath.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
