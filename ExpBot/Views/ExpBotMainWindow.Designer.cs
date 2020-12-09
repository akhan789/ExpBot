
using System;
using System.Windows.Forms;

namespace ExpBot.Views
{
    partial class ExpBotMainWindow
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpBotMainWindow));
            this.expBotMainWindowMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboProcesses = new System.Windows.Forms.ComboBox();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.lblCharacterHP = new System.Windows.Forms.Label();
            this.lblCharacterTP = new System.Windows.Forms.Label();
            this.lblCharacterMP = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMP = new System.Windows.Forms.Label();
            this.lblTP = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.expBotMainWindowPanel = new System.Windows.Forms.Panel();
            this.tblLayoutPanelControls = new System.Windows.Forms.TableLayoutPanel();
            this.lblCharacterStatus = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSelectProcess = new System.Windows.Forms.Label();
            this.chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.tblLayoutExpBotMainWindow = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBotSettings = new System.Windows.Forms.Panel();
            this.tabctrlBotControls = new System.Windows.Forms.TabControl();
            this.tabPageBasicSettings = new System.Windows.Forms.TabPage();
            this.tblLayoutBasicSettings = new System.Windows.Forms.TableLayoutPanel();
            this.grpBoxTargetsList = new System.Windows.Forms.GroupBox();
            this.lstTargets = new System.Windows.Forms.ListBox();
            this.grpBoxSelectedTargets = new System.Windows.Forms.GroupBox();
            this.lstSelectedTargets = new System.Windows.Forms.ListBox();
            this.grpBoxControls = new System.Windows.Forms.GroupBox();
            this.btnRefreshTargetList = new System.Windows.Forms.Button();
            this.tabPageCombatSettings = new System.Windows.Forms.TabPage();
            this.tblLayoutCombatSettings = new System.Windows.Forms.TableLayoutPanel();
            this.grpBoxTrustSelect = new System.Windows.Forms.GroupBox();
            this.tblLayoutTrustSelection = new System.Windows.Forms.TableLayoutPanel();
            this.lblTrustSelectionNotice = new System.Windows.Forms.Label();
            this.lstTrustSelections = new System.Windows.Forms.ListBox();
            this.btnResetTrustList = new System.Windows.Forms.Button();
            this.grpBoxGeneral = new System.Windows.Forms.GroupBox();
            this.pnlConsole = new System.Windows.Forms.Panel();
            this.grpBoxConsole = new System.Windows.Forms.GroupBox();
            this.expBotMainWindowMenuStrip.SuspendLayout();
            this.expBotMainWindowPanel.SuspendLayout();
            this.tblLayoutPanelControls.SuspendLayout();
            this.tblLayoutExpBotMainWindow.SuspendLayout();
            this.pnlBotSettings.SuspendLayout();
            this.tabctrlBotControls.SuspendLayout();
            this.tabPageBasicSettings.SuspendLayout();
            this.tblLayoutBasicSettings.SuspendLayout();
            this.grpBoxTargetsList.SuspendLayout();
            this.grpBoxSelectedTargets.SuspendLayout();
            this.grpBoxControls.SuspendLayout();
            this.tabPageCombatSettings.SuspendLayout();
            this.tblLayoutCombatSettings.SuspendLayout();
            this.grpBoxTrustSelect.SuspendLayout();
            this.tblLayoutTrustSelection.SuspendLayout();
            this.pnlConsole.SuspendLayout();
            this.grpBoxConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // expBotMainWindowMenuStrip
            // 
            this.expBotMainWindowMenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expBotMainWindowMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.expBotMainWindowMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.expBotMainWindowMenuStrip.Name = "expBotMainWindowMenuStrip";
            this.expBotMainWindowMenuStrip.Size = new System.Drawing.Size(775, 34);
            this.expBotMainWindowMenuStrip.TabIndex = 0;
            this.expBotMainWindowMenuStrip.Text = "expBotMainWindowMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 30);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 30);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cboProcesses
            // 
            this.tblLayoutPanelControls.SetColumnSpan(this.cboProcesses, 3);
            this.cboProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcesses.FormattingEnabled = true;
            this.cboProcesses.Location = new System.Drawing.Point(118, 3);
            this.cboProcesses.Name = "cboProcesses";
            this.cboProcesses.Size = new System.Drawing.Size(646, 21);
            this.cboProcesses.TabIndex = 0;
            this.cboProcesses.SelectedIndexChanged += new System.EventHandler(this.cboProcesses_SelectedIndexChanged);
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.AutoSize = true;
            this.lblCharacterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterName.Location = new System.Drawing.Point(3, 29);
            this.lblCharacterName.Name = "lblCharacterName";
            this.lblCharacterName.Size = new System.Drawing.Size(109, 29);
            this.lblCharacterName.TabIndex = 1;
            this.lblCharacterName.Text = "Character Name:";
            this.lblCharacterName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCharacterHP
            // 
            this.lblCharacterHP.AutoSize = true;
            this.lblCharacterHP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterHP.Location = new System.Drawing.Point(3, 58);
            this.lblCharacterHP.Name = "lblCharacterHP";
            this.lblCharacterHP.Size = new System.Drawing.Size(109, 29);
            this.lblCharacterHP.TabIndex = 2;
            this.lblCharacterHP.Text = "Character HP:";
            this.lblCharacterHP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCharacterTP
            // 
            this.lblCharacterTP.AutoSize = true;
            this.lblCharacterTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterTP.Location = new System.Drawing.Point(3, 116);
            this.lblCharacterTP.Name = "lblCharacterTP";
            this.lblCharacterTP.Size = new System.Drawing.Size(109, 29);
            this.lblCharacterTP.TabIndex = 4;
            this.lblCharacterTP.Text = "Character TP:";
            this.lblCharacterTP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCharacterMP
            // 
            this.lblCharacterMP.AutoSize = true;
            this.lblCharacterMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterMP.Location = new System.Drawing.Point(3, 87);
            this.lblCharacterMP.Name = "lblCharacterMP";
            this.lblCharacterMP.Size = new System.Drawing.Size(109, 29);
            this.lblCharacterMP.TabIndex = 5;
            this.lblCharacterMP.Text = "Character MP:";
            this.lblCharacterMP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHP.Location = new System.Drawing.Point(118, 58);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(109, 29);
            this.lblHP.TabIndex = 6;
            this.lblHP.Text = "<HP>";
            this.lblHP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(118, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 29);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "<Name>";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMP
            // 
            this.lblMP.AutoSize = true;
            this.lblMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMP.Location = new System.Drawing.Point(118, 87);
            this.lblMP.Name = "lblMP";
            this.lblMP.Size = new System.Drawing.Size(109, 29);
            this.lblMP.TabIndex = 8;
            this.lblMP.Text = "<MP>";
            this.lblMP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTP
            // 
            this.lblTP.AutoSize = true;
            this.lblTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTP.Location = new System.Drawing.Point(118, 116);
            this.lblTP.Name = "lblTP";
            this.lblTP.Size = new System.Drawing.Size(109, 29);
            this.lblTP.TabIndex = 9;
            this.lblTP.Text = "<TP>";
            this.lblTP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(689, 32);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(3, 16);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(761, 202);
            this.txtConsole.TabIndex = 3;
            this.txtConsole.WordWrap = false;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(689, 61);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // expBotMainWindowPanel
            // 
            this.expBotMainWindowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.expBotMainWindowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expBotMainWindowPanel.Controls.Add(this.tblLayoutPanelControls);
            this.expBotMainWindowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expBotMainWindowPanel.Location = new System.Drawing.Point(3, 37);
            this.expBotMainWindowPanel.Name = "expBotMainWindowPanel";
            this.expBotMainWindowPanel.Size = new System.Drawing.Size(769, 179);
            this.expBotMainWindowPanel.TabIndex = 1;
            // 
            // tblLayoutPanelControls
            // 
            this.tblLayoutPanelControls.ColumnCount = 4;
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutPanelControls.Controls.Add(this.lblCharacterStatus, 0, 5);
            this.tblLayoutPanelControls.Controls.Add(this.lblStatus, 1, 5);
            this.tblLayoutPanelControls.Controls.Add(this.lblCharacterTP, 0, 4);
            this.tblLayoutPanelControls.Controls.Add(this.lblTP, 1, 4);
            this.tblLayoutPanelControls.Controls.Add(this.lblCharacterMP, 0, 3);
            this.tblLayoutPanelControls.Controls.Add(this.lblMP, 1, 3);
            this.tblLayoutPanelControls.Controls.Add(this.lblCharacterHP, 0, 2);
            this.tblLayoutPanelControls.Controls.Add(this.lblHP, 1, 2);
            this.tblLayoutPanelControls.Controls.Add(this.lblCharacterName, 0, 1);
            this.tblLayoutPanelControls.Controls.Add(this.lblName, 1, 1);
            this.tblLayoutPanelControls.Controls.Add(this.cboProcesses, 1, 0);
            this.tblLayoutPanelControls.Controls.Add(this.lblSelectProcess, 0, 0);
            this.tblLayoutPanelControls.Controls.Add(this.chkAlwaysOnTop, 3, 5);
            this.tblLayoutPanelControls.Controls.Add(this.btnStart, 3, 1);
            this.tblLayoutPanelControls.Controls.Add(this.btnStop, 3, 2);
            this.tblLayoutPanelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutPanelControls.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutPanelControls.Name = "tblLayoutPanelControls";
            this.tblLayoutPanelControls.RowCount = 6;
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutPanelControls.Size = new System.Drawing.Size(767, 177);
            this.tblLayoutPanelControls.TabIndex = 1;
            // 
            // lblCharacterStatus
            // 
            this.lblCharacterStatus.AutoSize = true;
            this.lblCharacterStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterStatus.Location = new System.Drawing.Point(3, 145);
            this.lblCharacterStatus.Name = "lblCharacterStatus";
            this.lblCharacterStatus.Size = new System.Drawing.Size(109, 32);
            this.lblCharacterStatus.TabIndex = 13;
            this.lblCharacterStatus.Text = "Character Status:";
            this.lblCharacterStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(118, 145);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(109, 32);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "<Status>";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectProcess
            // 
            this.lblSelectProcess.AutoSize = true;
            this.lblSelectProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectProcess.Location = new System.Drawing.Point(3, 0);
            this.lblSelectProcess.Name = "lblSelectProcess";
            this.lblSelectProcess.Size = new System.Drawing.Size(109, 29);
            this.lblSelectProcess.TabIndex = 15;
            this.lblSelectProcess.Text = "Process:";
            this.lblSelectProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAlwaysOnTop
            // 
            this.chkAlwaysOnTop.AutoSize = true;
            this.chkAlwaysOnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAlwaysOnTop.Location = new System.Drawing.Point(654, 148);
            this.chkAlwaysOnTop.Name = "chkAlwaysOnTop";
            this.chkAlwaysOnTop.Size = new System.Drawing.Size(110, 26);
            this.chkAlwaysOnTop.TabIndex = 16;
            this.chkAlwaysOnTop.Text = "Always on Top";
            this.chkAlwaysOnTop.UseVisualStyleBackColor = true;
            this.chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkAlwaysOnTop_CheckedChanged);
            // 
            // tblLayoutExpBotMainWindow
            // 
            this.tblLayoutExpBotMainWindow.ColumnCount = 1;
            this.tblLayoutExpBotMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutExpBotMainWindow.Controls.Add(this.expBotMainWindowMenuStrip, 0, 0);
            this.tblLayoutExpBotMainWindow.Controls.Add(this.expBotMainWindowPanel, 0, 1);
            this.tblLayoutExpBotMainWindow.Controls.Add(this.pnlBotSettings, 0, 2);
            this.tblLayoutExpBotMainWindow.Controls.Add(this.pnlConsole, 0, 3);
            this.tblLayoutExpBotMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutExpBotMainWindow.Location = new System.Drawing.Point(5, 5);
            this.tblLayoutExpBotMainWindow.Name = "tblLayoutExpBotMainWindow";
            this.tblLayoutExpBotMainWindow.RowCount = 4;
            this.tblLayoutExpBotMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.tblLayoutExpBotMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.65717F));
            this.tblLayoutExpBotMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.01064F));
            this.tblLayoutExpBotMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.57029F));
            this.tblLayoutExpBotMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutExpBotMainWindow.Size = new System.Drawing.Size(775, 722);
            this.tblLayoutExpBotMainWindow.TabIndex = 2;
            // 
            // pnlBotSettings
            // 
            this.pnlBotSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBotSettings.Controls.Add(this.tabctrlBotControls);
            this.pnlBotSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotSettings.Location = new System.Drawing.Point(3, 222);
            this.pnlBotSettings.Name = "pnlBotSettings";
            this.pnlBotSettings.Size = new System.Drawing.Size(769, 268);
            this.pnlBotSettings.TabIndex = 14;
            // 
            // tabctrlBotControls
            // 
            this.tabctrlBotControls.Controls.Add(this.tabPageBasicSettings);
            this.tabctrlBotControls.Controls.Add(this.tabPageCombatSettings);
            this.tabctrlBotControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabctrlBotControls.Location = new System.Drawing.Point(0, 0);
            this.tabctrlBotControls.Name = "tabctrlBotControls";
            this.tabctrlBotControls.SelectedIndex = 0;
            this.tabctrlBotControls.Size = new System.Drawing.Size(767, 266);
            this.tabctrlBotControls.TabIndex = 13;
            // 
            // tabPageBasicSettings
            // 
            this.tabPageBasicSettings.Controls.Add(this.tblLayoutBasicSettings);
            this.tabPageBasicSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageBasicSettings.Name = "tabPageBasicSettings";
            this.tabPageBasicSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasicSettings.Size = new System.Drawing.Size(759, 240);
            this.tabPageBasicSettings.TabIndex = 0;
            this.tabPageBasicSettings.Text = "Basic Settings";
            this.tabPageBasicSettings.UseVisualStyleBackColor = true;
            // 
            // tblLayoutBasicSettings
            // 
            this.tblLayoutBasicSettings.ColumnCount = 3;
            this.tblLayoutBasicSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblLayoutBasicSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblLayoutBasicSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayoutBasicSettings.Controls.Add(this.grpBoxTargetsList, 1, 0);
            this.tblLayoutBasicSettings.Controls.Add(this.grpBoxSelectedTargets, 0, 0);
            this.tblLayoutBasicSettings.Controls.Add(this.grpBoxControls, 2, 0);
            this.tblLayoutBasicSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutBasicSettings.Location = new System.Drawing.Point(3, 3);
            this.tblLayoutBasicSettings.Name = "tblLayoutBasicSettings";
            this.tblLayoutBasicSettings.RowCount = 2;
            this.tblLayoutBasicSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblLayoutBasicSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblLayoutBasicSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tblLayoutBasicSettings.Size = new System.Drawing.Size(753, 234);
            this.tblLayoutBasicSettings.TabIndex = 1;
            // 
            // grpBoxTargetsList
            // 
            this.grpBoxTargetsList.Controls.Add(this.lstTargets);
            this.grpBoxTargetsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxTargetsList.Location = new System.Drawing.Point(304, 3);
            this.grpBoxTargetsList.Name = "grpBoxTargetsList";
            this.tblLayoutBasicSettings.SetRowSpan(this.grpBoxTargetsList, 3);
            this.grpBoxTargetsList.Size = new System.Drawing.Size(295, 228);
            this.grpBoxTargetsList.TabIndex = 5;
            this.grpBoxTargetsList.TabStop = false;
            this.grpBoxTargetsList.Text = "Targets List";
            // 
            // lstTargets
            // 
            this.lstTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTargets.FormattingEnabled = true;
            this.lstTargets.Location = new System.Drawing.Point(3, 16);
            this.lstTargets.Name = "lstTargets";
            this.lstTargets.Size = new System.Drawing.Size(289, 209);
            this.lstTargets.TabIndex = 0;
            this.lstTargets.DoubleClick += new System.EventHandler(this.lstTargets_DoubleClick);
            // 
            // grpBoxSelectedTargets
            // 
            this.grpBoxSelectedTargets.Controls.Add(this.lstSelectedTargets);
            this.grpBoxSelectedTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxSelectedTargets.Location = new System.Drawing.Point(3, 3);
            this.grpBoxSelectedTargets.Name = "grpBoxSelectedTargets";
            this.tblLayoutBasicSettings.SetRowSpan(this.grpBoxSelectedTargets, 3);
            this.grpBoxSelectedTargets.Size = new System.Drawing.Size(295, 228);
            this.grpBoxSelectedTargets.TabIndex = 3;
            this.grpBoxSelectedTargets.TabStop = false;
            this.grpBoxSelectedTargets.Text = "Selected Targets";
            // 
            // lstSelectedTargets
            // 
            this.lstSelectedTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelectedTargets.FormattingEnabled = true;
            this.lstSelectedTargets.Location = new System.Drawing.Point(3, 16);
            this.lstSelectedTargets.Name = "lstSelectedTargets";
            this.lstSelectedTargets.Size = new System.Drawing.Size(289, 209);
            this.lstSelectedTargets.TabIndex = 2;
            this.lstSelectedTargets.DoubleClick += new System.EventHandler(this.lstSelectedTargets_DoubleClick);
            // 
            // grpBoxControls
            // 
            this.grpBoxControls.Controls.Add(this.btnRefreshTargetList);
            this.grpBoxControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxControls.Location = new System.Drawing.Point(605, 3);
            this.grpBoxControls.Name = "grpBoxControls";
            this.tblLayoutBasicSettings.SetRowSpan(this.grpBoxControls, 3);
            this.grpBoxControls.Size = new System.Drawing.Size(145, 228);
            this.grpBoxControls.TabIndex = 6;
            this.grpBoxControls.TabStop = false;
            // 
            // btnRefreshTargetList
            // 
            this.btnRefreshTargetList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRefreshTargetList.Location = new System.Drawing.Point(6, 102);
            this.btnRefreshTargetList.Name = "btnRefreshTargetList";
            this.btnRefreshTargetList.Size = new System.Drawing.Size(133, 23);
            this.btnRefreshTargetList.TabIndex = 1;
            this.btnRefreshTargetList.Text = "Refresh";
            this.btnRefreshTargetList.UseVisualStyleBackColor = true;
            this.btnRefreshTargetList.Click += new System.EventHandler(this.btnRefreshTargetList_Click);
            // 
            // tabPageCombatSettings
            // 
            this.tabPageCombatSettings.Controls.Add(this.tblLayoutCombatSettings);
            this.tabPageCombatSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageCombatSettings.Name = "tabPageCombatSettings";
            this.tabPageCombatSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCombatSettings.Size = new System.Drawing.Size(759, 240);
            this.tabPageCombatSettings.TabIndex = 1;
            this.tabPageCombatSettings.Text = "Combat Settings";
            this.tabPageCombatSettings.UseVisualStyleBackColor = true;
            // 
            // tblLayoutCombatSettings
            // 
            this.tblLayoutCombatSettings.ColumnCount = 2;
            this.tblLayoutCombatSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutCombatSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutCombatSettings.Controls.Add(this.grpBoxTrustSelect, 1, 0);
            this.tblLayoutCombatSettings.Controls.Add(this.grpBoxGeneral, 0, 0);
            this.tblLayoutCombatSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutCombatSettings.Location = new System.Drawing.Point(3, 3);
            this.tblLayoutCombatSettings.Name = "tblLayoutCombatSettings";
            this.tblLayoutCombatSettings.RowCount = 1;
            this.tblLayoutCombatSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutCombatSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tblLayoutCombatSettings.Size = new System.Drawing.Size(753, 234);
            this.tblLayoutCombatSettings.TabIndex = 0;
            // 
            // grpBoxTrustSelect
            // 
            this.grpBoxTrustSelect.Controls.Add(this.tblLayoutTrustSelection);
            this.grpBoxTrustSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxTrustSelect.Location = new System.Drawing.Point(379, 3);
            this.grpBoxTrustSelect.Name = "grpBoxTrustSelect";
            this.grpBoxTrustSelect.Size = new System.Drawing.Size(371, 228);
            this.grpBoxTrustSelect.TabIndex = 0;
            this.grpBoxTrustSelect.TabStop = false;
            this.grpBoxTrustSelect.Text = "Trust Selection";
            // 
            // tblLayoutTrustSelection
            // 
            this.tblLayoutTrustSelection.ColumnCount = 2;
            this.tblLayoutTrustSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.17318F));
            this.tblLayoutTrustSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.82682F));
            this.tblLayoutTrustSelection.Controls.Add(this.lblTrustSelectionNotice, 1, 0);
            this.tblLayoutTrustSelection.Controls.Add(this.lstTrustSelections, 0, 0);
            this.tblLayoutTrustSelection.Controls.Add(this.btnResetTrustList, 1, 1);
            this.tblLayoutTrustSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutTrustSelection.Location = new System.Drawing.Point(3, 16);
            this.tblLayoutTrustSelection.Name = "tblLayoutTrustSelection";
            this.tblLayoutTrustSelection.RowCount = 2;
            this.tblLayoutTrustSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tblLayoutTrustSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblLayoutTrustSelection.Size = new System.Drawing.Size(365, 209);
            this.tblLayoutTrustSelection.TabIndex = 0;
            // 
            // lblTrustSelectionNotice
            // 
            this.lblTrustSelectionNotice.AutoSize = true;
            this.lblTrustSelectionNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrustSelectionNotice.Location = new System.Drawing.Point(226, 0);
            this.lblTrustSelectionNotice.Name = "lblTrustSelectionNotice";
            this.lblTrustSelectionNotice.Size = new System.Drawing.Size(136, 139);
            this.lblTrustSelectionNotice.TabIndex = 0;
            this.lblTrustSelectionNotice.Text = "Please select up to 5 trusts from the list box.";
            this.lblTrustSelectionNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstTrustSelections
            // 
            this.lstTrustSelections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTrustSelections.FormattingEnabled = true;
            this.lstTrustSelections.Location = new System.Drawing.Point(3, 3);
            this.lstTrustSelections.Name = "lstTrustSelections";
            this.tblLayoutTrustSelection.SetRowSpan(this.lstTrustSelections, 2);
            this.lstTrustSelections.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTrustSelections.Size = new System.Drawing.Size(217, 203);
            this.lstTrustSelections.TabIndex = 1;
            this.lstTrustSelections.Click += new System.EventHandler(this.lstTrustSelections_Click);
            // 
            // btnResetTrustList
            // 
            this.btnResetTrustList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnResetTrustList.Location = new System.Drawing.Point(256, 142);
            this.btnResetTrustList.Name = "btnResetTrustList";
            this.btnResetTrustList.Size = new System.Drawing.Size(75, 23);
            this.btnResetTrustList.TabIndex = 2;
            this.btnResetTrustList.Text = "Reset";
            this.btnResetTrustList.UseVisualStyleBackColor = true;
            this.btnResetTrustList.Click += new System.EventHandler(this.btnResetTrustList_Click);
            // 
            // grpBoxGeneral
            // 
            this.grpBoxGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxGeneral.Location = new System.Drawing.Point(3, 3);
            this.grpBoxGeneral.Name = "grpBoxGeneral";
            this.grpBoxGeneral.Size = new System.Drawing.Size(370, 228);
            this.grpBoxGeneral.TabIndex = 1;
            this.grpBoxGeneral.TabStop = false;
            this.grpBoxGeneral.Text = "General";
            // 
            // pnlConsole
            // 
            this.pnlConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConsole.Controls.Add(this.grpBoxConsole);
            this.pnlConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConsole.Location = new System.Drawing.Point(3, 496);
            this.pnlConsole.Name = "pnlConsole";
            this.pnlConsole.Size = new System.Drawing.Size(769, 223);
            this.pnlConsole.TabIndex = 16;
            // 
            // grpBoxConsole
            // 
            this.grpBoxConsole.Controls.Add(this.txtConsole);
            this.grpBoxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxConsole.Location = new System.Drawing.Point(0, 0);
            this.grpBoxConsole.Name = "grpBoxConsole";
            this.grpBoxConsole.Size = new System.Drawing.Size(767, 221);
            this.grpBoxConsole.TabIndex = 15;
            this.grpBoxConsole.TabStop = false;
            this.grpBoxConsole.Text = "Console";
            // 
            // ExpBotMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnStop;
            this.ClientSize = new System.Drawing.Size(785, 732);
            this.Controls.Add(this.tblLayoutExpBotMainWindow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.expBotMainWindowMenuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 39);
            this.Name = "ExpBotMainWindow";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Experience Farming Bot by SoLiDwAtEr";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExpBotMainWindow_FormClosed);
            this.expBotMainWindowMenuStrip.ResumeLayout(false);
            this.expBotMainWindowMenuStrip.PerformLayout();
            this.expBotMainWindowPanel.ResumeLayout(false);
            this.tblLayoutPanelControls.ResumeLayout(false);
            this.tblLayoutPanelControls.PerformLayout();
            this.tblLayoutExpBotMainWindow.ResumeLayout(false);
            this.tblLayoutExpBotMainWindow.PerformLayout();
            this.pnlBotSettings.ResumeLayout(false);
            this.tabctrlBotControls.ResumeLayout(false);
            this.tabPageBasicSettings.ResumeLayout(false);
            this.tblLayoutBasicSettings.ResumeLayout(false);
            this.grpBoxTargetsList.ResumeLayout(false);
            this.grpBoxSelectedTargets.ResumeLayout(false);
            this.grpBoxControls.ResumeLayout(false);
            this.tabPageCombatSettings.ResumeLayout(false);
            this.tblLayoutCombatSettings.ResumeLayout(false);
            this.grpBoxTrustSelect.ResumeLayout(false);
            this.tblLayoutTrustSelection.ResumeLayout(false);
            this.tblLayoutTrustSelection.PerformLayout();
            this.pnlConsole.ResumeLayout(false);
            this.grpBoxConsole.ResumeLayout(false);
            this.grpBoxConsole.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.MenuStrip expBotMainWindowMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private ComboBox cboProcesses;
        private Label lblCharacterName;
        private Label lblCharacterHP;
        private Label lblCharacterTP;
        private Label lblCharacterMP;
        private Label lblHP;
        private Label lblName;
        private Label lblMP;
        private Label lblTP;
        private Button btnStart;
        private TextBox txtConsole;
        private Button btnStop;
        private Panel expBotMainWindowPanel;
        private TableLayoutPanel tblLayoutExpBotMainWindow;
        private Label lblCharacterStatus;
        private Label lblStatus;
        private TableLayoutPanel tblLayoutPanelControls;
        private Label lblSelectProcess;
        private CheckBox chkAlwaysOnTop;
        private TabControl tabctrlBotControls;
        private Panel pnlBotSettings;
        private TabPage tabPageBasicSettings;
        private ListBox lstTargets;
        private TableLayoutPanel tblLayoutBasicSettings;
        private Button btnRefreshTargetList;
        private ListBox lstSelectedTargets;
        private GroupBox grpBoxSelectedTargets;
        private GroupBox grpBoxTargetsList;
        private TabPage tabPageCombatSettings;
        private TableLayoutPanel tblLayoutCombatSettings;
        private GroupBox grpBoxControls;
        private GroupBox grpBoxConsole;
        private Panel pnlConsole;
        private GroupBox grpBoxTrustSelect;
        private TableLayoutPanel tblLayoutTrustSelection;
        private GroupBox grpBoxGeneral;
        private Label lblTrustSelectionNotice;
        private ListBox lstTrustSelections;
        private Button btnResetTrustList;
    }
}