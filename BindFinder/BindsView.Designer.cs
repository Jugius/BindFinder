namespace BindFinder
{
    partial class BindsView
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
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton4 = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuAddBindsInputBox = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddBindsExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveBindsToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadSavedBinds = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveBindsToKml = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGotoBoardsSeach = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.MnuGeocodingSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuBoardsReadSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuCheckUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.olvBinds = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn_Address = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_OriginalAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn_Description = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextBinds = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuStartXMLRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditBind = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblBindsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelBindInfo = new System.Windows.Forms.Panel();
            this.lblBindCoordinates = new System.Windows.Forms.Label();
            this.panelMap_Link = new System.Windows.Forms.Panel();
            this.radShowGoogleMap = new System.Windows.Forms.RadioButton();
            this.radShowStaticMap = new System.Windows.Forms.RadioButton();
            this.panelBindMap = new System.Windows.Forms.Panel();
            this.lblOpenMap = new System.Windows.Forms.LinkLabel();
            this.pictureSchema = new System.Windows.Forms.PictureBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.lbltOpenMap = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvBinds)).BeginInit();
            this.contextBinds.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelBindInfo.SuspendLayout();
            this.panelMap_Link.SuspendLayout();
            this.panelBindMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSchema)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolMain
            // 
            this.toolMain.AutoSize = false;
            this.toolMain.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton4,
            this.toolStripSeparator2,
            this.mnuGotoBoardsSeach,
            this.toolStripSeparator3,
            this.toolStripSplitButton1,
            this.toolStripSeparator5,
            this.toolStripSplitButton2});
            this.toolMain.Location = new System.Drawing.Point(0, 0);
            this.toolMain.Name = "toolMain";
            this.toolMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolMain.Size = new System.Drawing.Size(1091, 32);
            this.toolMain.TabIndex = 5;
            this.toolMain.Text = "toolStrip1";
            // 
            // toolStripSplitButton4
            // 
            this.toolStripSplitButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddBindsInputBox,
            this.mnuAddBindsExcel,
            this.toolStripSeparator1,
            this.mnuSaveBindsToExcel,
            this.mnuLoadSavedBinds,
            this.toolStripSeparator6,
            this.mnuSaveBindsToKml});
            this.toolStripSplitButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripSplitButton4.Image = global::BindFinder.Properties.Resources.Map_Marker_Grey_Green_24;
            this.toolStripSplitButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripSplitButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton4.Name = "toolStripSplitButton4";
            this.toolStripSplitButton4.Size = new System.Drawing.Size(161, 29);
            this.toolStripSplitButton4.Text = "Адреса и привязки";
            this.toolStripSplitButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuAddBindsInputBox
            // 
            this.mnuAddBindsInputBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mnuAddBindsInputBox.Image = global::BindFinder.Properties.Resources.TextBox_24;
            this.mnuAddBindsInputBox.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuAddBindsInputBox.Name = "mnuAddBindsInputBox";
            this.mnuAddBindsInputBox.Size = new System.Drawing.Size(337, 30);
            this.mnuAddBindsInputBox.Text = "Импорт - Поле ввода";
            this.mnuAddBindsInputBox.Click += new System.EventHandler(this.MnuAddBindsInputBox_Click);
            // 
            // mnuAddBindsExcel
            // 
            this.mnuAddBindsExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mnuAddBindsExcel.Image = global::BindFinder.Properties.Resources.Excel_24;
            this.mnuAddBindsExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuAddBindsExcel.Name = "mnuAddBindsExcel";
            this.mnuAddBindsExcel.Size = new System.Drawing.Size(337, 30);
            this.mnuAddBindsExcel.Text = "Импорт из файла Excel";
            this.mnuAddBindsExcel.Click += new System.EventHandler(this.MnuAddBindsExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(334, 6);
            // 
            // mnuSaveBindsToExcel
            // 
            this.mnuSaveBindsToExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mnuSaveBindsToExcel.Name = "mnuSaveBindsToExcel";
            this.mnuSaveBindsToExcel.Size = new System.Drawing.Size(337, 30);
            this.mnuSaveBindsToExcel.Text = "Сохранить привязки в Excel";
            this.mnuSaveBindsToExcel.Click += new System.EventHandler(this.MnuSaveBindsToExcel_Click);
            // 
            // mnuLoadSavedBinds
            // 
            this.mnuLoadSavedBinds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mnuLoadSavedBinds.Name = "mnuLoadSavedBinds";
            this.mnuLoadSavedBinds.Size = new System.Drawing.Size(337, 30);
            this.mnuLoadSavedBinds.Text = "Загрузить сохраненный Excel";
            this.mnuLoadSavedBinds.Click += new System.EventHandler(this.MnuLoadSavedBinds_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(334, 6);
            // 
            // mnuSaveBindsToKml
            // 
            this.mnuSaveBindsToKml.Image = global::BindFinder.Properties.Resources.GoogleEarth_24;
            this.mnuSaveBindsToKml.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSaveBindsToKml.Name = "mnuSaveBindsToKml";
            this.mnuSaveBindsToKml.Size = new System.Drawing.Size(337, 30);
            this.mnuSaveBindsToKml.Text = "Сохранить привязки в KMZ (Google Earth)";
            this.mnuSaveBindsToKml.Click += new System.EventHandler(this.MnuSaveBindsToKml_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // mnuGotoBoardsSeach
            // 
            this.mnuGotoBoardsSeach.Image = global::BindFinder.Properties.Resources.Billboard_24;
            this.mnuGotoBoardsSeach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuGotoBoardsSeach.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuGotoBoardsSeach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuGotoBoardsSeach.Name = "mnuGotoBoardsSeach";
            this.mnuGotoBoardsSeach.Size = new System.Drawing.Size(211, 29);
            this.mnuGotoBoardsSeach.Text = "Перейти к поиску плоскостей";
            this.mnuGotoBoardsSeach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuGotoBoardsSeach.Click += new System.EventHandler(this.MnuGotoBoardsSeach_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuGeocodingSettings,
            this.MnuBoardsReadSettings});
            this.toolStripSplitButton1.Image = global::BindFinder.Properties.Resources.Settings_24;
            this.toolStripSplitButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripSplitButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(111, 29);
            this.toolStripSplitButton1.Text = "Настройки";
            this.toolStripSplitButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MnuGeocodingSettings
            // 
            this.MnuGeocodingSettings.Image = global::BindFinder.Properties.Resources.Map_Marker_24;
            this.MnuGeocodingSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MnuGeocodingSettings.Name = "MnuGeocodingSettings";
            this.MnuGeocodingSettings.Size = new System.Drawing.Size(299, 30);
            this.MnuGeocodingSettings.Text = "Настройки службы геокодирования";
            this.MnuGeocodingSettings.Click += new System.EventHandler(this.MnuGeocodingSettings_Click);
            // 
            // MnuBoardsReadSettings
            // 
            this.MnuBoardsReadSettings.Image = global::BindFinder.Properties.Resources.Database_24;
            this.MnuBoardsReadSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MnuBoardsReadSettings.Name = "MnuBoardsReadSettings";
            this.MnuBoardsReadSettings.Size = new System.Drawing.Size(299, 30);
            this.MnuBoardsReadSettings.Text = "Настройки чтения плоскостей";
            this.MnuBoardsReadSettings.Click += new System.EventHandler(this.MnuBoardsReadSettings_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCheckUpdates,
            this.mnuShowAbout});
            this.toolStripSplitButton2.Image = global::BindFinder.Properties.Resources.About_24;
            this.toolStripSplitButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripSplitButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(98, 29);
            this.toolStripSplitButton2.Text = "Справка";
            this.toolStripSplitButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuCheckUpdates
            // 
            this.mnuCheckUpdates.Name = "mnuCheckUpdates";
            this.mnuCheckUpdates.Size = new System.Drawing.Size(219, 22);
            this.mnuCheckUpdates.Text = "Проверить обновления";
            this.mnuCheckUpdates.Click += new System.EventHandler(this.MnuCheckUpdates_Click);
            // 
            // mnuShowAbout
            // 
            this.mnuShowAbout.Name = "mnuShowAbout";
            this.mnuShowAbout.Size = new System.Drawing.Size(219, 22);
            this.mnuShowAbout.Text = "О программе...";
            this.mnuShowAbout.Click += new System.EventHandler(this.MnuShowAbout_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.olvBinds);
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelBindInfo);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(1091, 531);
            this.splitContainer1.SplitterDistance = 819;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 6;
            // 
            // olvBinds
            // 
            this.olvBinds.AllColumns.Add(this.olvColumn_Address);
            this.olvBinds.AllColumns.Add(this.olvColumn_OriginalAddress);
            this.olvBinds.AllColumns.Add(this.olvColumn_Description);
            this.olvBinds.AllowColumnReorder = true;
            this.olvBinds.AlternateRowBackColor = System.Drawing.Color.WhiteSmoke;
            this.olvBinds.BackColor = System.Drawing.Color.White;
            this.olvBinds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.olvBinds.CellEditUseWholeCell = false;
            this.olvBinds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn_Address,
            this.olvColumn_OriginalAddress,
            this.olvColumn_Description});
            this.olvBinds.ContextMenuStrip = this.contextBinds;
            this.olvBinds.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvBinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvBinds.EmptyListMsg = "";
            this.olvBinds.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.olvBinds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvBinds.FullRowSelect = true;
            this.olvBinds.GridLines = true;
            this.olvBinds.HideSelection = false;
            this.olvBinds.Location = new System.Drawing.Point(0, 0);
            this.olvBinds.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.olvBinds.MultiSelect = false;
            this.olvBinds.Name = "olvBinds";
            this.olvBinds.ShowGroups = false;
            this.olvBinds.ShowImagesOnSubItems = true;
            this.olvBinds.Size = new System.Drawing.Size(819, 509);
            this.olvBinds.TabIndex = 0;
            this.olvBinds.UseCompatibleStateImageBehavior = false;
            this.olvBinds.UseExplorerTheme = true;
            this.olvBinds.View = System.Windows.Forms.View.Details;
            this.olvBinds.VirtualMode = true;
            this.olvBinds.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.OlvBinds_FormatRow);
            this.olvBinds.SelectionChanged += new System.EventHandler(this.OlvBinds_SelectionChanged);
            this.olvBinds.DoubleClick += new System.EventHandler(this.MnuEditBind_Click);
            // 
            // olvColumn_Address
            // 
            this.olvColumn_Address.Text = "Найденный адрес";
            this.olvColumn_Address.Width = 291;
            // 
            // olvColumn_OriginalAddress
            // 
            this.olvColumn_OriginalAddress.Text = "Оригинальный адрес";
            this.olvColumn_OriginalAddress.Width = 280;
            // 
            // olvColumn_Description
            // 
            this.olvColumn_Description.Text = "Описание";
            this.olvColumn_Description.Width = 239;
            // 
            // contextBinds
            // 
            this.contextBinds.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStartXMLRequest,
            this.toolStripSeparator4,
            this.mnuEditBind});
            this.contextBinds.Name = "contextBinds";
            this.contextBinds.Size = new System.Drawing.Size(225, 54);
            // 
            // mnuStartXMLRequest
            // 
            this.mnuStartXMLRequest.Name = "mnuStartXMLRequest";
            this.mnuStartXMLRequest.Size = new System.Drawing.Size(224, 22);
            this.mnuStartXMLRequest.Text = "Открыть запрос в браузере";
            this.mnuStartXMLRequest.Click += new System.EventHandler(this.MnuStartXMLRequest_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuEditBind
            // 
            this.mnuEditBind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mnuEditBind.Name = "mnuEditBind";
            this.mnuEditBind.Size = new System.Drawing.Size(224, 22);
            this.mnuEditBind.Text = "Свойства";
            this.mnuEditBind.Click += new System.EventHandler(this.MnuEditBind_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBindsCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 509);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(819, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblBindsCount
            // 
            this.lblBindsCount.Name = "lblBindsCount";
            this.lblBindsCount.Size = new System.Drawing.Size(0, 17);
            // 
            // panelBindInfo
            // 
            this.panelBindInfo.Controls.Add(this.lblBindCoordinates);
            this.panelBindInfo.Controls.Add(this.panelMap_Link);
            this.panelBindInfo.Controls.Add(this.panelBindMap);
            this.panelBindInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBindInfo.Location = new System.Drawing.Point(0, 0);
            this.panelBindInfo.Name = "panelBindInfo";
            this.panelBindInfo.Size = new System.Drawing.Size(267, 509);
            this.panelBindInfo.TabIndex = 3;
            this.panelBindInfo.Resize += new System.EventHandler(this.PanelBindInfo_Resize);
            // 
            // lblBindCoordinates
            // 
            this.lblBindCoordinates.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBindCoordinates.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBindCoordinates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBindCoordinates.Location = new System.Drawing.Point(0, 0);
            this.lblBindCoordinates.Name = "lblBindCoordinates";
            this.lblBindCoordinates.Size = new System.Drawing.Size(267, 74);
            this.lblBindCoordinates.TabIndex = 1;
            this.lblBindCoordinates.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panelMap_Link
            // 
            this.panelMap_Link.BackColor = System.Drawing.Color.Transparent;
            this.panelMap_Link.Controls.Add(this.radShowGoogleMap);
            this.panelMap_Link.Controls.Add(this.radShowStaticMap);
            this.panelMap_Link.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMap_Link.Location = new System.Drawing.Point(0, 203);
            this.panelMap_Link.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelMap_Link.Name = "panelMap_Link";
            this.panelMap_Link.Size = new System.Drawing.Size(267, 44);
            this.panelMap_Link.TabIndex = 6;
            // 
            // radShowGoogleMap
            // 
            this.radShowGoogleMap.AutoSize = true;
            this.radShowGoogleMap.Checked = true;
            this.radShowGoogleMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radShowGoogleMap.Location = new System.Drawing.Point(124, 12);
            this.radShowGoogleMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radShowGoogleMap.Name = "radShowGoogleMap";
            this.radShowGoogleMap.Size = new System.Drawing.Size(126, 21);
            this.radShowGoogleMap.TabIndex = 5;
            this.radShowGoogleMap.TabStop = true;
            this.radShowGoogleMap.Text = "Google Map Link";
            this.radShowGoogleMap.UseVisualStyleBackColor = true;
            // 
            // radShowStaticMap
            // 
            this.radShowStaticMap.AutoSize = true;
            this.radShowStaticMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radShowStaticMap.Location = new System.Drawing.Point(17, 12);
            this.radShowStaticMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radShowStaticMap.Name = "radShowStaticMap";
            this.radShowStaticMap.Size = new System.Drawing.Size(88, 21);
            this.radShowStaticMap.TabIndex = 4;
            this.radShowStaticMap.Text = "Static Map";
            this.radShowStaticMap.UseVisualStyleBackColor = true;
            this.radShowStaticMap.CheckedChanged += new System.EventHandler(this.RadShowStaticMap_CheckedChanged);
            // 
            // panelBindMap
            // 
            this.panelBindMap.Controls.Add(this.lblOpenMap);
            this.panelBindMap.Controls.Add(this.pictureSchema);
            this.panelBindMap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBindMap.Location = new System.Drawing.Point(0, 247);
            this.panelBindMap.Name = "panelBindMap";
            this.panelBindMap.Size = new System.Drawing.Size(267, 262);
            this.panelBindMap.TabIndex = 4;
            // 
            // lblOpenMap
            // 
            this.lblOpenMap.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblOpenMap.BackColor = System.Drawing.Color.LightSlateGray;
            this.lblOpenMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOpenMap.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblOpenMap.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.lblOpenMap.Location = new System.Drawing.Point(0, 0);
            this.lblOpenMap.Name = "lblOpenMap";
            this.lblOpenMap.Size = new System.Drawing.Size(267, 262);
            this.lblOpenMap.TabIndex = 4;
            this.lblOpenMap.TabStop = true;
            this.lblOpenMap.Text = "Открыть карту Google";
            this.lblOpenMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOpenMap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblOpenMap_LinkClicked);
            // 
            // pictureSchema
            // 
            this.pictureSchema.BackColor = System.Drawing.Color.LightSlateGray;
            this.pictureSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureSchema.Location = new System.Drawing.Point(0, 0);
            this.pictureSchema.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureSchema.Name = "pictureSchema";
            this.pictureSchema.Size = new System.Drawing.Size(267, 262);
            this.pictureSchema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSchema.TabIndex = 0;
            this.pictureSchema.TabStop = false;
            this.pictureSchema.DoubleClick += new System.EventHandler(this.PictureSchema_DoubleClick);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbltOpenMap});
            this.statusStrip2.Location = new System.Drawing.Point(0, 509);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip2.Size = new System.Drawing.Size(267, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // lbltOpenMap
            // 
            this.lbltOpenMap.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbltOpenMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbltOpenMap.IsLink = true;
            this.lbltOpenMap.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lbltOpenMap.Name = "lbltOpenMap";
            this.lbltOpenMap.Size = new System.Drawing.Size(141, 17);
            this.lbltOpenMap.Text = "Открыть карту Google";
            this.lbltOpenMap.Click += new System.EventHandler(this.LblOpenMap_LinkClicked);
            // 
            // BindsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 563);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BindsView";
            this.Text = "Поиск адресов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BindsView_FormClosing);
            this.Shown += new System.EventHandler(this.BindsView_Shown);
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvBinds)).EndInit();
            this.contextBinds.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelBindInfo.ResumeLayout(false);
            this.panelMap_Link.ResumeLayout(false);
            this.panelMap_Link.PerformLayout();
            this.panelBindMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSchema)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private BrightIdeasSoftware.FastObjectListView olvBinds;
        private BrightIdeasSoftware.OLVColumn olvColumn_Address;
        private BrightIdeasSoftware.OLVColumn olvColumn_OriginalAddress;
        private BrightIdeasSoftware.OLVColumn olvColumn_Description;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.LinkLabel lblOpenMap;
        private System.Windows.Forms.Label lblBindCoordinates;
        private System.Windows.Forms.Panel panelMap_Link;
        private System.Windows.Forms.RadioButton radShowGoogleMap;
        private System.Windows.Forms.RadioButton radShowStaticMap;
        private System.Windows.Forms.PictureBox pictureSchema;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripMenuItem mnuAddBindsInputBox;
        private System.Windows.Forms.ToolStripMenuItem mnuAddBindsExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveBindsToExcel;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadSavedBinds;
        private System.Windows.Forms.ToolStripStatusLabel lblBindsCount;
        private System.Windows.Forms.Panel panelBindMap;
        private System.Windows.Forms.Panel panelBindInfo;
        private System.Windows.Forms.ToolStripStatusLabel lbltOpenMap;
        private System.Windows.Forms.ContextMenuStrip contextBinds;
        private System.Windows.Forms.ToolStripMenuItem mnuStartXMLRequest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuEditBind;
        private System.Windows.Forms.ToolStripButton mnuGotoBoardsSeach;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem MnuGeocodingSettings;
        private System.Windows.Forms.ToolStripMenuItem MnuBoardsReadSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckUpdates;
        private System.Windows.Forms.ToolStripMenuItem mnuShowAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveBindsToKml;
    }
}