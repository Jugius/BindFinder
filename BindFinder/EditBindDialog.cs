using BindFinder.AppModels.Binds;
using BindFinder.DataManager;
using BindFinder.Helpers;
using Geocoding;
using Geocoding.Google;
using Ookii.Dialogs;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BindFinder
{
    internal partial class EditBindDialog : Form
    {
        public Bind Bind { get; private set; }
        private Bind BindAlternative = null;
        public EditBindDialog(Bind bind)
        {
            this.Bind = bind;
            InitializeComponent();
            InitializeObjectListView();
        }
        private void UpdateBindInfo(Bind bind)
        {
            olvAddresses.ClearObjects();
            foreach (var control in groupBoxResults.Controls)
            {
                if (control is TextBox)
                    (control as TextBox).Text = null;
            }

            txtOriginalAddress.Text = bind.OriginalAddress;
            txtDescription.Text = bind.Description;
            if (bind.Error != null)
            {
                lblError.Text = "Ошибка:";
                txtError.Text = bind.Error.Message;
                return;
            }
            lblError.Text = "Адрес вывода:";
            txtError.Text = bind.Address.FormattedAddress;
            txtCountry.Text = bind.Address.Country;
            txtRegion.Text = bind.Address.Region;
            txtCity.Text = bind.Address.City;
            txtDistrict.Text = bind.Address.District;
            txtStreet.Text = bind.Address.Street;
            txtStreetNumber.Text = bind.Address.StreetNumber;
            txtIntersection.Text = bind.Address.Intersection;
            txtZip.Text = bind.Address.Zip;
            txtCoordinates.Text = bind.Address.Coordinates.ToString();
            txtPlaceID.Text = bind.Address.PlaceId;

            if (bind.Addresses != null && bind.Addresses.Count > 0)
            {
                olvAddresses.SetObjects(bind.Addresses);
                btnReloadAddresses.Visible = false;
            }
            else
            {
                btnReloadAddresses.Visible = true;
            }

        }

        private void InitializeObjectListView()
        {
            olvColumn_FormattedAddress.AspectGetter = delegate (object row)
            {
                return (row as Address).FormattedAddress;
            };
            olvColumn_Type.AspectGetter = delegate (object row)
            {
                return (row as GoogleAddress).Type.ToString();
            };
            olvColumn_LocationType.AspectGetter = delegate (object row)
            {
                return (row as GoogleAddress).LocationType.ToString();
            };
        }
        private void _primaryPanel_Paint(object sender, PaintEventArgs e)
        {
            Ookii.Dialogs.DialogHelper.DrawThemeBackground(e.Graphics, AdditionalVisualStyleElements.TaskDialog.PrimaryPanel, _primaryPanel.ClientRectangle, e.ClipRectangle);
        }

        private void _secondaryPanel_Paint(object sender, PaintEventArgs e)
        {
            Ookii.Dialogs.DialogHelper.DrawThemeBackground(e.Graphics, AdditionalVisualStyleElements.TaskDialog.SecondaryPanel, _secondaryPanel.ClientRectangle, e.ClipRectangle);
        }

        private void EditBindDialog_Load(object sender, System.EventArgs e)
        {
            this.Text = "Свойства: " + (string.IsNullOrEmpty(this.Bind.Description) ? this.Bind.OriginalAddress : $"{this.Bind.Description} ({this.Bind.OriginalAddress})");
            UpdateBindInfo(this.Bind);
        }

        private void OlvAddresses_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            GoogleAddress address = e.Model as GoogleAddress;
            if (address.PlaceId == txtPlaceID.Text)
                e.Item.BackColor = Color.LightGreen;
        }

        private void MnuSetBasicAddress_Click(object sender, System.EventArgs e)
        {
            if (olvAddresses.SelectedObject == null) return;

            GoogleAddress basicAddress = olvAddresses.SelectedObject as GoogleAddress;
            var allAddresses = olvAddresses.CollectCheckedObjects<Address>(ObjectListViewHelper.ObjectListViewCollector.All);            
            Bind sourceBind = this.BindAlternative ?? this.Bind;

            BindAddress newBindAddress = BindAddress.Create(allAddresses, basicAddress);

            Bind newBind = new Bind { Address = newBindAddress, Addresses = allAddresses, Description = sourceBind.Description, OriginalAddress = sourceBind.OriginalAddress };

            this.BindAlternative = newBind;

            UpdateBindInfo(newBind);
        }

        private void BtnRebuildBind_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOriginalAddress.Text)) return;

            Bind _bind = this.BindAlternative ?? this.Bind;
            
            string message = "Все данные по этой точке будут перезаписаны согласно результатов нового запроса.\n\nВы хотите продолжить?";
            if (MessageBox.Show(message, "Новый запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var coder = Helpers.GeocoderHelper.GetGeocoder();
            if (coder == null) return;

            var newBind = coder.BuildBind(txtOriginalAddress.Text);
            newBind.Description = txtDescription.Text;

            this.BindAlternative = newBind;
            UpdateBindInfo(newBind);
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            Bind _bind = this.BindAlternative ?? this.Bind;
            if (_bind.Error != null)
            {
                MessageBox.Show("Поиск точки завешен с ошибкой. Точка не может быть сохранена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.BindAlternative != null)
                this.Bind.SetPropertiesFrom(this.BindAlternative);

            this.Bind.Description = txtDescription.Text;
            this.Bind.Address.Country = txtCountry.Text;
            this.Bind.Address.Region = txtRegion.Text;
            this.Bind.Address.City = txtCity.Text;
            this.Bind.Address.District = txtDistrict.Text;
            this.Bind.Address.Street = txtStreet.Text;

            this.Bind.Address.StreetNumber = txtStreetNumber.Text;
            this.Bind.Address.Intersection = txtIntersection.Text;
            this.Bind.Address.Zip = txtZip.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void BtnReloadAddresses_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOriginalAddress.Text)) return;

            Bind _bind = this.BindAlternative ?? this.Bind;
            var coder = Helpers.GeocoderHelper.GetGeocoder();
            if (coder == null) return;
            var addresses = coder.Geocode(txtOriginalAddress.Text).ToList();
            olvAddresses.SetObjects(addresses);
            _bind.Addresses = addresses;
            btnReloadAddresses.Visible = false;

        }
    }
}
