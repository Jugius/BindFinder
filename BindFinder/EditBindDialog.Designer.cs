namespace BindFinder
{
    partial class EditBindDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRebuildBind = new System.Windows.Forms.Button();
            this.txtError = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOriginalAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.txtPlaceID = new System.Windows.Forms.TextBox();
            this.txtCoordinates = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.txtIntersection = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtStreetNumber = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReloadAddresses = new System.Windows.Forms.Button();
            this.olvAddresses = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn_FormattedAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_Type = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_LocationType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSetBasicAddress = new System.Windows.Forms.ToolStripMenuItem();
            this._primaryPanel = new System.Windows.Forms.Panel();
            this._secondaryPanel = new System.Windows.Forms.Panel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxResults.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvAddresses)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this._primaryPanel.SuspendLayout();
            this._secondaryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRebuildBind);
            this.groupBox1.Controls.Add(this.txtError);
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOriginalAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства точки";
            // 
            // btnRebuildBind
            // 
            this.btnRebuildBind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRebuildBind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRebuildBind.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRebuildBind.Location = new System.Drawing.Point(506, 21);
            this.btnRebuildBind.Name = "btnRebuildBind";
            this.btnRebuildBind.Size = new System.Drawing.Size(30, 23);
            this.btnRebuildBind.TabIndex = 2;
            this.btnRebuildBind.Text = "->";
            this.btnRebuildBind.UseVisualStyleBackColor = true;
            this.btnRebuildBind.Click += new System.EventHandler(this.BtnRebuildBind_Click);
            // 
            // txtError
            // 
            this.txtError.BackColor = System.Drawing.SystemColors.Window;
            this.txtError.Location = new System.Drawing.Point(216, 50);
            this.txtError.Name = "txtError";
            this.txtError.ReadOnly = true;
            this.txtError.Size = new System.Drawing.Size(320, 23);
            this.txtError.TabIndex = 23;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(7, 53);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(53, 15);
            this.lblError.TabIndex = 22;
            this.lblError.Text = "Ошибка";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(216, 79);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(320, 23);
            this.txtDescription.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Описание:";
            // 
            // txtOriginalAddress
            // 
            this.txtOriginalAddress.Location = new System.Drawing.Point(216, 21);
            this.txtOriginalAddress.Name = "txtOriginalAddress";
            this.txtOriginalAddress.Size = new System.Drawing.Size(284, 23);
            this.txtOriginalAddress.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Оригинальная строка запроса:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Place ID:";
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Controls.Add(this.txtPlaceID);
            this.groupBoxResults.Controls.Add(this.txtCoordinates);
            this.groupBoxResults.Controls.Add(this.label16);
            this.groupBoxResults.Controls.Add(this.label3);
            this.groupBoxResults.Controls.Add(this.txtZip);
            this.groupBoxResults.Controls.Add(this.txtIntersection);
            this.groupBoxResults.Controls.Add(this.label11);
            this.groupBoxResults.Controls.Add(this.label12);
            this.groupBoxResults.Controls.Add(this.txtStreetNumber);
            this.groupBoxResults.Controls.Add(this.txtStreet);
            this.groupBoxResults.Controls.Add(this.label7);
            this.groupBoxResults.Controls.Add(this.label8);
            this.groupBoxResults.Controls.Add(this.label10);
            this.groupBoxResults.Controls.Add(this.txtDistrict);
            this.groupBoxResults.Controls.Add(this.txtCity);
            this.groupBoxResults.Controls.Add(this.label4);
            this.groupBoxResults.Controls.Add(this.txtRegion);
            this.groupBoxResults.Controls.Add(this.label5);
            this.groupBoxResults.Controls.Add(this.txtCountry);
            this.groupBoxResults.Controls.Add(this.label6);
            this.groupBoxResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxResults.Location = new System.Drawing.Point(5, 114);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(541, 169);
            this.groupBoxResults.TabIndex = 7;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Результаты поиска:";
            // 
            // txtPlaceID
            // 
            this.txtPlaceID.BackColor = System.Drawing.SystemColors.Window;
            this.txtPlaceID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPlaceID.Location = new System.Drawing.Point(349, 134);
            this.txtPlaceID.Name = "txtPlaceID";
            this.txtPlaceID.ReadOnly = true;
            this.txtPlaceID.Size = new System.Drawing.Size(187, 23);
            this.txtPlaceID.TabIndex = 25;
            // 
            // txtCoordinates
            // 
            this.txtCoordinates.BackColor = System.Drawing.SystemColors.Window;
            this.txtCoordinates.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCoordinates.Location = new System.Drawing.Point(94, 134);
            this.txtCoordinates.Name = "txtCoordinates";
            this.txtCoordinates.ReadOnly = true;
            this.txtCoordinates.Size = new System.Drawing.Size(187, 23);
            this.txtCoordinates.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 137);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 15);
            this.label16.TabIndex = 22;
            this.label16.Text = "Координаты:";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(349, 105);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(187, 23);
            this.txtZip.TabIndex = 21;
            // 
            // txtIntersection
            // 
            this.txtIntersection.Location = new System.Drawing.Point(94, 105);
            this.txtIntersection.Name = "txtIntersection";
            this.txtIntersection.Size = new System.Drawing.Size(187, 23);
            this.txtIntersection.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(287, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 15);
            this.label11.TabIndex = 19;
            this.label11.Text = "Индекс:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Перекресток:";
            // 
            // txtStreetNumber
            // 
            this.txtStreetNumber.Location = new System.Drawing.Point(349, 76);
            this.txtStreetNumber.Name = "txtStreetNumber";
            this.txtStreetNumber.Size = new System.Drawing.Size(187, 23);
            this.txtStreetNumber.TabIndex = 17;
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(94, 76);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(187, 23);
            this.txtStreet.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Дом:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Улица:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(287, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "Регион:";
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(349, 49);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(187, 23);
            this.txtDistrict.TabIndex = 8;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(94, 49);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(187, 23);
            this.txtCity.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Район:";
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(349, 21);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(187, 23);
            this.txtRegion.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Город:";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(94, 21);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(187, 23);
            this.txtCountry.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Страна:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBoxResults);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(551, 559);
            this.panel1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReloadAddresses);
            this.groupBox3.Controls.Add(this.olvAddresses);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(5, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(541, 271);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Адреса, найденные в Google Maps";
            // 
            // btnReloadAddresses
            // 
            this.btnReloadAddresses.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnReloadAddresses.Image = global::BindFinder.Properties.Resources.refresh_48;
            this.btnReloadAddresses.Location = new System.Drawing.Point(242, 107);
            this.btnReloadAddresses.Name = "btnReloadAddresses";
            this.btnReloadAddresses.Size = new System.Drawing.Size(56, 56);
            this.btnReloadAddresses.TabIndex = 2;
            this.btnReloadAddresses.UseVisualStyleBackColor = false;
            this.btnReloadAddresses.Visible = false;
            this.btnReloadAddresses.Click += new System.EventHandler(this.BtnReloadAddresses_Click);
            // 
            // olvAddresses
            // 
            this.olvAddresses.AllColumns.Add(this.olvColumn_FormattedAddress);
            this.olvAddresses.AllColumns.Add(this.olvColumn_Type);
            this.olvAddresses.AllColumns.Add(this.olvColumn_LocationType);
            this.olvAddresses.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.olvAddresses.CellEditUseWholeCell = false;
            this.olvAddresses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn_FormattedAddress,
            this.olvColumn_Type,
            this.olvColumn_LocationType});
            this.olvAddresses.ContextMenuStrip = this.contextMenuStrip1;
            this.olvAddresses.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvAddresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvAddresses.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.olvAddresses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvAddresses.FullRowSelect = true;
            this.olvAddresses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.olvAddresses.HideSelection = false;
            this.olvAddresses.Location = new System.Drawing.Point(3, 19);
            this.olvAddresses.MultiSelect = false;
            this.olvAddresses.Name = "olvAddresses";
            this.olvAddresses.ShowGroups = false;
            this.olvAddresses.Size = new System.Drawing.Size(535, 249);
            this.olvAddresses.TabIndex = 1;
            this.olvAddresses.UseCompatibleStateImageBehavior = false;
            this.olvAddresses.View = System.Windows.Forms.View.Details;
            this.olvAddresses.VirtualMode = true;
            this.olvAddresses.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.OlvAddresses_FormatRow);
            // 
            // olvColumn_FormattedAddress
            // 
            this.olvColumn_FormattedAddress.Text = "Адрес Google";
            this.olvColumn_FormattedAddress.Width = 318;
            // 
            // olvColumn_Type
            // 
            this.olvColumn_Type.Text = "Локация";
            this.olvColumn_Type.Width = 120;
            // 
            // olvColumn_LocationType
            // 
            this.olvColumn_LocationType.Text = "Тип";
            this.olvColumn_LocationType.Width = 92;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetBasicAddress});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(242, 26);
            // 
            // mnuSetBasicAddress
            // 
            this.mnuSetBasicAddress.Name = "mnuSetBasicAddress";
            this.mnuSetBasicAddress.Size = new System.Drawing.Size(241, 22);
            this.mnuSetBasicAddress.Text = "Установить адрес как базовый";
            this.mnuSetBasicAddress.Click += new System.EventHandler(this.MnuSetBasicAddress_Click);
            // 
            // _primaryPanel
            // 
            this._primaryPanel.Controls.Add(this.panel1);
            this._primaryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._primaryPanel.Location = new System.Drawing.Point(0, 0);
            this._primaryPanel.Name = "_primaryPanel";
            this._primaryPanel.Size = new System.Drawing.Size(551, 559);
            this._primaryPanel.TabIndex = 9;
            this._primaryPanel.Paint += new System.Windows.Forms.PaintEventHandler(this._primaryPanel_Paint);
            // 
            // _secondaryPanel
            // 
            this._secondaryPanel.Controls.Add(this._cancelButton);
            this._secondaryPanel.Controls.Add(this._okButton);
            this._secondaryPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._secondaryPanel.Location = new System.Drawing.Point(0, 559);
            this._secondaryPanel.Name = "_secondaryPanel";
            this._secondaryPanel.Size = new System.Drawing.Size(551, 41);
            this._secondaryPanel.TabIndex = 10;
            this._secondaryPanel.Paint += new System.Windows.Forms.PaintEventHandler(this._secondaryPanel_Paint);
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._cancelButton.Location = new System.Drawing.Point(462, 11);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Отмена";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._okButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._okButton.Location = new System.Drawing.Point(381, 11);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // EditBindDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(551, 600);
            this.Controls.Add(this._primaryPanel);
            this.Controls.Add(this._secondaryPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBindDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditBindDialog";
            this.Load += new System.EventHandler(this.EditBindDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxResults.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvAddresses)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this._primaryPanel.ResumeLayout(false);
            this._secondaryPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOriginalAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel _primaryPanel;
        private System.Windows.Forms.Panel _secondaryPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStreetNumber;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.TextBox txtIntersection;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private BrightIdeasSoftware.FastObjectListView olvAddresses;
        private BrightIdeasSoftware.OLVColumn olvColumn_FormattedAddress;
        private BrightIdeasSoftware.OLVColumn olvColumn_Type;
        private BrightIdeasSoftware.OLVColumn olvColumn_LocationType;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSetBasicAddress;
        private System.Windows.Forms.Button btnRebuildBind;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.TextBox txtPlaceID;
        private System.Windows.Forms.TextBox txtCoordinates;
        private System.Windows.Forms.Button btnReloadAddresses;
    }
}