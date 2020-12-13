
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
            this.grpBoxStatusEffects = new System.Windows.Forms.GroupBox();
            this.lstViewStatusEffects = new System.Windows.Forms.ListView();
            this.lstViewStatusEffectsId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstViewStatusEffectsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.tblLayoutCombatSettingsGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.chkSummonTrusts = new System.Windows.Forms.CheckBox();
            this.lblPullDistance = new System.Windows.Forms.Label();
            this.numPullDistance = new System.Windows.Forms.NumericUpDown();
            this.lblPullSearchRadius = new System.Windows.Forms.Label();
            this.numPullSearchRadius = new System.Windows.Forms.NumericUpDown();
            this.chkMeleeRange = new System.Windows.Forms.CheckBox();
            this.numMeleeRange = new System.Windows.Forms.NumericUpDown();
            this.chkRestMPP = new System.Windows.Forms.CheckBox();
            this.numUseWSTP = new System.Windows.Forms.NumericUpDown();
            this.numRestMPP = new System.Windows.Forms.NumericUpDown();
            this.chkUseWSTP = new System.Windows.Forms.CheckBox();
            this.lblWeaponSkill = new System.Windows.Forms.Label();
            this.cboWeaponSkills = new System.Windows.Forms.ComboBox();
            this.chkUseExpPointEquip = new System.Windows.Forms.CheckBox();
            this.chkUseCapPointEquip = new System.Windows.Forms.CheckBox();
            this.chkAutoHeal = new System.Windows.Forms.CheckBox();
            this.cboPullSpells = new System.Windows.Forms.ComboBox();
            this.chkPullWithBlackMagicSpell = new System.Windows.Forms.CheckBox();
            this.pnlConsole = new System.Windows.Forms.Panel();
            this.grpBoxConsole = new System.Windows.Forms.GroupBox();
            this.expBotMainWindowMenuStrip.SuspendLayout();
            this.expBotMainWindowPanel.SuspendLayout();
            this.tblLayoutPanelControls.SuspendLayout();
            this.grpBoxStatusEffects.SuspendLayout();
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
            this.grpBoxGeneral.SuspendLayout();
            this.tblLayoutCombatSettingsGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPullDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPullSearchRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeleeRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUseWSTP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestMPP)).BeginInit();
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
            this.cboProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayoutPanelControls.SetColumnSpan(this.cboProcesses, 4);
            this.cboProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcesses.FormattingEnabled = true;
            this.cboProcesses.Location = new System.Drawing.Point(108, 13);
            this.cboProcesses.Name = "cboProcesses";
            this.cboProcesses.Size = new System.Drawing.Size(646, 21);
            this.cboProcesses.TabIndex = 0;
            this.cboProcesses.SelectedIndexChanged += new System.EventHandler(this.cboProcesses_SelectedIndexChanged);
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.AutoSize = true;
            this.lblCharacterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterName.Location = new System.Drawing.Point(13, 36);
            this.lblCharacterName.Name = "lblCharacterName";
            this.lblCharacterName.Size = new System.Drawing.Size(89, 26);
            this.lblCharacterName.TabIndex = 1;
            this.lblCharacterName.Text = "Character Name:";
            this.lblCharacterName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCharacterHP
            // 
            this.lblCharacterHP.AutoSize = true;
            this.lblCharacterHP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterHP.Location = new System.Drawing.Point(13, 62);
            this.lblCharacterHP.Name = "lblCharacterHP";
            this.lblCharacterHP.Size = new System.Drawing.Size(89, 26);
            this.lblCharacterHP.TabIndex = 2;
            this.lblCharacterHP.Text = "Character HP:";
            this.lblCharacterHP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCharacterTP
            // 
            this.lblCharacterTP.AutoSize = true;
            this.lblCharacterTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterTP.Location = new System.Drawing.Point(13, 114);
            this.lblCharacterTP.Name = "lblCharacterTP";
            this.lblCharacterTP.Size = new System.Drawing.Size(89, 26);
            this.lblCharacterTP.TabIndex = 4;
            this.lblCharacterTP.Text = "Character TP:";
            this.lblCharacterTP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCharacterMP
            // 
            this.lblCharacterMP.AutoSize = true;
            this.lblCharacterMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterMP.Location = new System.Drawing.Point(13, 88);
            this.lblCharacterMP.Name = "lblCharacterMP";
            this.lblCharacterMP.Size = new System.Drawing.Size(89, 26);
            this.lblCharacterMP.TabIndex = 5;
            this.lblCharacterMP.Text = "Character MP:";
            this.lblCharacterMP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHP.Location = new System.Drawing.Point(108, 62);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(49, 26);
            this.lblHP.TabIndex = 6;
            this.lblHP.Text = "<HP>";
            this.lblHP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(108, 36);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 26);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "<Name>";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMP
            // 
            this.lblMP.AutoSize = true;
            this.lblMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMP.Location = new System.Drawing.Point(108, 88);
            this.lblMP.Name = "lblMP";
            this.lblMP.Size = new System.Drawing.Size(49, 26);
            this.lblMP.TabIndex = 8;
            this.lblMP.Text = "<MP>";
            this.lblMP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTP
            // 
            this.lblTP.AutoSize = true;
            this.lblTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTP.Location = new System.Drawing.Point(108, 114);
            this.lblTP.Name = "lblTP";
            this.lblTP.Size = new System.Drawing.Size(49, 26);
            this.lblTP.TabIndex = 9;
            this.lblTP.Text = "<TP>";
            this.lblTP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(652, 39);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 20);
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
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(652, 65);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(102, 20);
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
            this.tblLayoutPanelControls.ColumnCount = 5;
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
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
            this.tblLayoutPanelControls.Controls.Add(this.chkAlwaysOnTop, 4, 5);
            this.tblLayoutPanelControls.Controls.Add(this.btnStart, 4, 1);
            this.tblLayoutPanelControls.Controls.Add(this.btnStop, 4, 2);
            this.tblLayoutPanelControls.Controls.Add(this.grpBoxStatusEffects, 2, 1);
            this.tblLayoutPanelControls.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutPanelControls.Name = "tblLayoutPanelControls";
            this.tblLayoutPanelControls.Padding = new System.Windows.Forms.Padding(10);
            this.tblLayoutPanelControls.RowCount = 6;
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblLayoutPanelControls.Size = new System.Drawing.Size(767, 177);
            this.tblLayoutPanelControls.TabIndex = 1;
            // 
            // lblCharacterStatus
            // 
            this.lblCharacterStatus.AutoSize = true;
            this.lblCharacterStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterStatus.Location = new System.Drawing.Point(13, 140);
            this.lblCharacterStatus.Name = "lblCharacterStatus";
            this.lblCharacterStatus.Size = new System.Drawing.Size(89, 27);
            this.lblCharacterStatus.TabIndex = 13;
            this.lblCharacterStatus.Text = "Character Status:";
            this.lblCharacterStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(108, 140);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 27);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "<Status>";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectProcess
            // 
            this.lblSelectProcess.AutoSize = true;
            this.lblSelectProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectProcess.Location = new System.Drawing.Point(13, 10);
            this.lblSelectProcess.Name = "lblSelectProcess";
            this.lblSelectProcess.Size = new System.Drawing.Size(89, 26);
            this.lblSelectProcess.TabIndex = 15;
            this.lblSelectProcess.Text = "Process:";
            this.lblSelectProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAlwaysOnTop
            // 
            this.chkAlwaysOnTop.AutoSize = true;
            this.chkAlwaysOnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAlwaysOnTop.Location = new System.Drawing.Point(652, 143);
            this.chkAlwaysOnTop.Name = "chkAlwaysOnTop";
            this.chkAlwaysOnTop.Size = new System.Drawing.Size(102, 21);
            this.chkAlwaysOnTop.TabIndex = 16;
            this.chkAlwaysOnTop.Text = "Always on Top";
            this.chkAlwaysOnTop.UseVisualStyleBackColor = true;
            this.chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkAlwaysOnTop_CheckedChanged);
            // 
            // grpBoxStatusEffects
            // 
            this.grpBoxStatusEffects.Controls.Add(this.lstViewStatusEffects);
            this.grpBoxStatusEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxStatusEffects.Location = new System.Drawing.Point(163, 39);
            this.grpBoxStatusEffects.Name = "grpBoxStatusEffects";
            this.tblLayoutPanelControls.SetRowSpan(this.grpBoxStatusEffects, 5);
            this.grpBoxStatusEffects.Size = new System.Drawing.Size(236, 125);
            this.grpBoxStatusEffects.TabIndex = 17;
            this.grpBoxStatusEffects.TabStop = false;
            this.grpBoxStatusEffects.Text = "Status Effects";
            // 
            // lstViewStatusEffects
            // 
            this.lstViewStatusEffects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstViewStatusEffects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstViewStatusEffectsId,
            this.lstViewStatusEffectsName});
            this.lstViewStatusEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstViewStatusEffects.HideSelection = false;
            this.lstViewStatusEffects.Location = new System.Drawing.Point(3, 16);
            this.lstViewStatusEffects.MultiSelect = false;
            this.lstViewStatusEffects.Name = "lstViewStatusEffects";
            this.lstViewStatusEffects.Size = new System.Drawing.Size(230, 106);
            this.lstViewStatusEffects.TabIndex = 1;
            this.lstViewStatusEffects.UseCompatibleStateImageBehavior = false;
            this.lstViewStatusEffects.View = System.Windows.Forms.View.Details;
            // 
            // lstViewStatusEffectsId
            // 
            this.lstViewStatusEffectsId.Tag = "";
            this.lstViewStatusEffectsId.Text = "Id";
            // 
            // lstViewStatusEffectsName
            // 
            this.lstViewStatusEffectsName.Tag = "";
            this.lstViewStatusEffectsName.Text = "Name";
            this.lstViewStatusEffectsName.Width = 120;
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
            this.tblLayoutCombatSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61F));
            this.tblLayoutCombatSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39F));
            this.tblLayoutCombatSettings.Controls.Add(this.grpBoxTrustSelect, 1, 0);
            this.tblLayoutCombatSettings.Controls.Add(this.grpBoxGeneral, 0, 0);
            this.tblLayoutCombatSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutCombatSettings.Location = new System.Drawing.Point(3, 3);
            this.tblLayoutCombatSettings.Name = "tblLayoutCombatSettings";
            this.tblLayoutCombatSettings.RowCount = 1;
            this.tblLayoutCombatSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutCombatSettings.Size = new System.Drawing.Size(753, 234);
            this.tblLayoutCombatSettings.TabIndex = 0;
            // 
            // grpBoxTrustSelect
            // 
            this.grpBoxTrustSelect.Controls.Add(this.tblLayoutTrustSelection);
            this.grpBoxTrustSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxTrustSelect.Location = new System.Drawing.Point(462, 3);
            this.grpBoxTrustSelect.Name = "grpBoxTrustSelect";
            this.grpBoxTrustSelect.Size = new System.Drawing.Size(288, 228);
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
            this.tblLayoutTrustSelection.Size = new System.Drawing.Size(282, 209);
            this.tblLayoutTrustSelection.TabIndex = 0;
            // 
            // lblTrustSelectionNotice
            // 
            this.lblTrustSelectionNotice.AutoSize = true;
            this.lblTrustSelectionNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrustSelectionNotice.Location = new System.Drawing.Point(175, 0);
            this.lblTrustSelectionNotice.Name = "lblTrustSelectionNotice";
            this.lblTrustSelectionNotice.Size = new System.Drawing.Size(104, 139);
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
            this.lstTrustSelections.Size = new System.Drawing.Size(166, 203);
            this.lstTrustSelections.TabIndex = 1;
            this.lstTrustSelections.Click += new System.EventHandler(this.lstTrustSelections_Click);
            // 
            // btnResetTrustList
            // 
            this.btnResetTrustList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnResetTrustList.Location = new System.Drawing.Point(189, 142);
            this.btnResetTrustList.Name = "btnResetTrustList";
            this.btnResetTrustList.Size = new System.Drawing.Size(75, 23);
            this.btnResetTrustList.TabIndex = 2;
            this.btnResetTrustList.Text = "Reset";
            this.btnResetTrustList.UseVisualStyleBackColor = true;
            this.btnResetTrustList.Click += new System.EventHandler(this.btnResetTrustList_Click);
            // 
            // grpBoxGeneral
            // 
            this.grpBoxGeneral.Controls.Add(this.tblLayoutCombatSettingsGeneral);
            this.grpBoxGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxGeneral.Location = new System.Drawing.Point(3, 3);
            this.grpBoxGeneral.Name = "grpBoxGeneral";
            this.grpBoxGeneral.Padding = new System.Windows.Forms.Padding(10);
            this.grpBoxGeneral.Size = new System.Drawing.Size(453, 228);
            this.grpBoxGeneral.TabIndex = 1;
            this.grpBoxGeneral.TabStop = false;
            this.grpBoxGeneral.Text = "General";
            // 
            // tblLayoutCombatSettingsGeneral
            // 
            this.tblLayoutCombatSettingsGeneral.ColumnCount = 3;
            this.tblLayoutCombatSettingsGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblLayoutCombatSettingsGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutCombatSettingsGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.chkSummonTrusts, 2, 0);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.lblPullDistance, 0, 0);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.numPullDistance, 1, 0);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.lblPullSearchRadius, 0, 1);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.numPullSearchRadius, 1, 1);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.chkMeleeRange, 0, 2);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.numMeleeRange, 1, 2);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.chkRestMPP, 0, 3);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.numUseWSTP, 1, 4);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.numRestMPP, 1, 3);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.chkUseWSTP, 0, 4);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.lblWeaponSkill, 0, 5);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.cboWeaponSkills, 1, 5);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.chkUseExpPointEquip, 2, 2);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.chkUseCapPointEquip, 2, 1);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.chkAutoHeal, 2, 3);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.cboPullSpells, 1, 6);
            this.tblLayoutCombatSettingsGeneral.Controls.Add(this.chkPullWithBlackMagicSpell, 0, 6);
            this.tblLayoutCombatSettingsGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutCombatSettingsGeneral.Location = new System.Drawing.Point(10, 23);
            this.tblLayoutCombatSettingsGeneral.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutCombatSettingsGeneral.Name = "tblLayoutCombatSettingsGeneral";
            this.tblLayoutCombatSettingsGeneral.RowCount = 7;
            this.tblLayoutCombatSettingsGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.80818F));
            this.tblLayoutCombatSettingsGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.81094F));
            this.tblLayoutCombatSettingsGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.81094F));
            this.tblLayoutCombatSettingsGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.80817F));
            this.tblLayoutCombatSettingsGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.80817F));
            this.tblLayoutCombatSettingsGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.80817F));
            this.tblLayoutCombatSettingsGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.14541F));
            this.tblLayoutCombatSettingsGeneral.Size = new System.Drawing.Size(433, 195);
            this.tblLayoutCombatSettingsGeneral.TabIndex = 0;
            // 
            // chkSummonTrusts
            // 
            this.chkSummonTrusts.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkSummonTrusts.AutoSize = true;
            this.chkSummonTrusts.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSummonTrusts.Checked = true;
            this.chkSummonTrusts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSummonTrusts.Location = new System.Drawing.Point(331, 4);
            this.chkSummonTrusts.Name = "chkSummonTrusts";
            this.chkSummonTrusts.Size = new System.Drawing.Size(99, 17);
            this.chkSummonTrusts.TabIndex = 16;
            this.chkSummonTrusts.Text = "Summon Trusts";
            this.chkSummonTrusts.UseVisualStyleBackColor = true;
            this.chkSummonTrusts.CheckedChanged += new System.EventHandler(this.chkSummonTrusts_CheckedChanged);
            // 
            // lblPullDistance
            // 
            this.lblPullDistance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPullDistance.AutoSize = true;
            this.lblPullDistance.Location = new System.Drawing.Point(76, 6);
            this.lblPullDistance.Name = "lblPullDistance";
            this.lblPullDistance.Size = new System.Drawing.Size(72, 13);
            this.lblPullDistance.TabIndex = 10;
            this.lblPullDistance.Text = "Pull Distance:";
            // 
            // numPullDistance
            // 
            this.numPullDistance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numPullDistance.DecimalPlaces = 1;
            this.numPullDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPullDistance.Location = new System.Drawing.Point(154, 3);
            this.numPullDistance.Name = "numPullDistance";
            this.numPullDistance.Size = new System.Drawing.Size(58, 20);
            this.numPullDistance.TabIndex = 7;
            this.numPullDistance.Value = new decimal(new int[] {
            180,
            0,
            0,
            65536});
            this.numPullDistance.ValueChanged += new System.EventHandler(this.numPullDistance_ValueChanged);
            // 
            // lblPullSearchRadius
            // 
            this.lblPullSearchRadius.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPullSearchRadius.AutoSize = true;
            this.lblPullSearchRadius.Location = new System.Drawing.Point(48, 32);
            this.lblPullSearchRadius.Name = "lblPullSearchRadius";
            this.lblPullSearchRadius.Size = new System.Drawing.Size(100, 13);
            this.lblPullSearchRadius.TabIndex = 11;
            this.lblPullSearchRadius.Text = "Pull Search Radius:";
            // 
            // numPullSearchRadius
            // 
            this.numPullSearchRadius.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numPullSearchRadius.DecimalPlaces = 1;
            this.numPullSearchRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPullSearchRadius.Location = new System.Drawing.Point(154, 29);
            this.numPullSearchRadius.Name = "numPullSearchRadius";
            this.numPullSearchRadius.Size = new System.Drawing.Size(58, 20);
            this.numPullSearchRadius.TabIndex = 9;
            this.numPullSearchRadius.Value = new decimal(new int[] {
            500,
            0,
            0,
            65536});
            this.numPullSearchRadius.ValueChanged += new System.EventHandler(this.numPullSearchRadius_ValueChanged);
            // 
            // chkMeleeRange
            // 
            this.chkMeleeRange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkMeleeRange.AutoSize = true;
            this.chkMeleeRange.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMeleeRange.Checked = true;
            this.chkMeleeRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMeleeRange.Location = new System.Drawing.Point(55, 56);
            this.chkMeleeRange.Name = "chkMeleeRange";
            this.chkMeleeRange.Size = new System.Drawing.Size(93, 17);
            this.chkMeleeRange.TabIndex = 4;
            this.chkMeleeRange.Text = "Melee Range:";
            this.chkMeleeRange.UseVisualStyleBackColor = true;
            this.chkMeleeRange.CheckedChanged += new System.EventHandler(this.chkMeleeRange_CheckedChanged);
            // 
            // numMeleeRange
            // 
            this.numMeleeRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numMeleeRange.DecimalPlaces = 1;
            this.numMeleeRange.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMeleeRange.Location = new System.Drawing.Point(154, 55);
            this.numMeleeRange.Name = "numMeleeRange";
            this.numMeleeRange.Size = new System.Drawing.Size(58, 20);
            this.numMeleeRange.TabIndex = 5;
            this.numMeleeRange.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            this.numMeleeRange.ValueChanged += new System.EventHandler(this.numMeleeRange_ValueChanged);
            // 
            // chkRestMPP
            // 
            this.chkRestMPP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkRestMPP.AutoSize = true;
            this.chkRestMPP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRestMPP.Checked = true;
            this.chkRestMPP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRestMPP.Location = new System.Drawing.Point(61, 82);
            this.chkRestMPP.Name = "chkRestMPP";
            this.chkRestMPP.Size = new System.Drawing.Size(87, 17);
            this.chkRestMPP.TabIndex = 0;
            this.chkRestMPP.Text = "Rest MP (%):";
            this.chkRestMPP.UseVisualStyleBackColor = true;
            this.chkRestMPP.CheckedChanged += new System.EventHandler(this.chkRestMPP_CheckedChanged);
            // 
            // numUseWSTP
            // 
            this.numUseWSTP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numUseWSTP.Location = new System.Drawing.Point(154, 107);
            this.numUseWSTP.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numUseWSTP.Name = "numUseWSTP";
            this.numUseWSTP.Size = new System.Drawing.Size(58, 20);
            this.numUseWSTP.TabIndex = 3;
            this.numUseWSTP.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUseWSTP.ValueChanged += new System.EventHandler(this.numUseWSTP_ValueChanged);
            // 
            // numRestMPP
            // 
            this.numRestMPP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numRestMPP.Location = new System.Drawing.Point(154, 81);
            this.numRestMPP.Name = "numRestMPP";
            this.numRestMPP.Size = new System.Drawing.Size(58, 20);
            this.numRestMPP.TabIndex = 1;
            this.numRestMPP.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numRestMPP.ValueChanged += new System.EventHandler(this.numRestMPP_ValueChanged);
            // 
            // chkUseWSTP
            // 
            this.chkUseWSTP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkUseWSTP.AutoSize = true;
            this.chkUseWSTP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseWSTP.Checked = true;
            this.chkUseWSTP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseWSTP.Location = new System.Drawing.Point(5, 108);
            this.chkUseWSTP.Name = "chkUseWSTP";
            this.chkUseWSTP.Size = new System.Drawing.Size(143, 17);
            this.chkUseWSTP.TabIndex = 2;
            this.chkUseWSTP.Text = "Use Weapon Skill at TP:";
            this.chkUseWSTP.UseVisualStyleBackColor = true;
            this.chkUseWSTP.CheckedChanged += new System.EventHandler(this.chkUseWSTP_CheckedChanged);
            // 
            // lblWeaponSkill
            // 
            this.lblWeaponSkill.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblWeaponSkill.AutoSize = true;
            this.lblWeaponSkill.Location = new System.Drawing.Point(75, 136);
            this.lblWeaponSkill.Name = "lblWeaponSkill";
            this.lblWeaponSkill.Size = new System.Drawing.Size(73, 13);
            this.lblWeaponSkill.TabIndex = 12;
            this.lblWeaponSkill.Text = "Weapon Skill:";
            // 
            // cboWeaponSkills
            // 
            this.cboWeaponSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayoutCombatSettingsGeneral.SetColumnSpan(this.cboWeaponSkills, 2);
            this.cboWeaponSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeaponSkills.FormattingEnabled = true;
            this.cboWeaponSkills.Location = new System.Drawing.Point(154, 133);
            this.cboWeaponSkills.Name = "cboWeaponSkills";
            this.cboWeaponSkills.Size = new System.Drawing.Size(276, 21);
            this.cboWeaponSkills.TabIndex = 13;
            this.cboWeaponSkills.SelectedIndexChanged += new System.EventHandler(this.cboWeaponSkills_SelectedIndexChanged);
            // 
            // chkUseExpPointEquip
            // 
            this.chkUseExpPointEquip.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkUseExpPointEquip.AutoSize = true;
            this.chkUseExpPointEquip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseExpPointEquip.Location = new System.Drawing.Point(246, 56);
            this.chkUseExpPointEquip.Name = "chkUseExpPointEquip";
            this.chkUseExpPointEquip.Size = new System.Drawing.Size(184, 17);
            this.chkUseExpPointEquip.TabIndex = 15;
            this.chkUseExpPointEquip.Text = "Use Experience Point Equipment:";
            this.chkUseExpPointEquip.UseVisualStyleBackColor = true;
            this.chkUseExpPointEquip.CheckedChanged += new System.EventHandler(this.chkUseExpPointEquip_CheckedChanged);
            // 
            // chkUseCapPointEquip
            // 
            this.chkUseCapPointEquip.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkUseCapPointEquip.AutoSize = true;
            this.chkUseCapPointEquip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseCapPointEquip.Location = new System.Drawing.Point(258, 30);
            this.chkUseCapPointEquip.Name = "chkUseCapPointEquip";
            this.chkUseCapPointEquip.Size = new System.Drawing.Size(172, 17);
            this.chkUseCapPointEquip.TabIndex = 14;
            this.chkUseCapPointEquip.Text = "Use Capacity Point Equipment:";
            this.chkUseCapPointEquip.UseVisualStyleBackColor = true;
            this.chkUseCapPointEquip.CheckedChanged += new System.EventHandler(this.chkUseCapPointEquip_CheckedChanged);
            // 
            // chkAutoHeal
            // 
            this.chkAutoHeal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkAutoHeal.AutoSize = true;
            this.chkAutoHeal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoHeal.Location = new System.Drawing.Point(354, 82);
            this.chkAutoHeal.Name = "chkAutoHeal";
            this.chkAutoHeal.Size = new System.Drawing.Size(76, 17);
            this.chkAutoHeal.TabIndex = 15;
            this.chkAutoHeal.Text = "Auto Heal:";
            this.chkAutoHeal.UseVisualStyleBackColor = true;
            this.chkAutoHeal.CheckedChanged += new System.EventHandler(this.chkAutoHeal_CheckedChanged);
            // 
            // cboPullSpells
            // 
            this.cboPullSpells.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayoutCombatSettingsGeneral.SetColumnSpan(this.cboPullSpells, 2);
            this.cboPullSpells.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPullSpells.FormattingEnabled = true;
            this.cboPullSpells.Location = new System.Drawing.Point(154, 165);
            this.cboPullSpells.Name = "cboPullSpells";
            this.cboPullSpells.Size = new System.Drawing.Size(276, 21);
            this.cboPullSpells.TabIndex = 13;
            this.cboPullSpells.SelectedIndexChanged += new System.EventHandler(this.cboWeaponSkills_SelectedIndexChanged);
            // 
            // chkPullWithBlackMagicSpell
            // 
            this.chkPullWithBlackMagicSpell.AutoSize = true;
            this.chkPullWithBlackMagicSpell.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPullWithBlackMagicSpell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkPullWithBlackMagicSpell.Location = new System.Drawing.Point(3, 159);
            this.chkPullWithBlackMagicSpell.Name = "chkPullWithBlackMagicSpell";
            this.chkPullWithBlackMagicSpell.Size = new System.Drawing.Size(145, 33);
            this.chkPullWithBlackMagicSpell.TabIndex = 15;
            this.chkPullWithBlackMagicSpell.Text = "Pull with Black Magic Spell:";
            this.chkPullWithBlackMagicSpell.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPullWithBlackMagicSpell.UseVisualStyleBackColor = true;
            this.chkPullWithBlackMagicSpell.CheckedChanged += new System.EventHandler(this.chkPullWithBlackMagicSpell_CheckedChanged);
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
            this.grpBoxStatusEffects.ResumeLayout(false);
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
            this.grpBoxGeneral.ResumeLayout(false);
            this.tblLayoutCombatSettingsGeneral.ResumeLayout(false);
            this.tblLayoutCombatSettingsGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPullDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPullSearchRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMeleeRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUseWSTP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestMPP)).EndInit();
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
        private GroupBox grpBoxStatusEffects;
        private ListView lstViewStatusEffects;
        private ColumnHeader lstViewStatusEffectsId;
        private ColumnHeader lstViewStatusEffectsName;
        private TableLayoutPanel tblLayoutCombatSettingsGeneral;
        private CheckBox chkRestMPP;
        private NumericUpDown numRestMPP;
        private CheckBox chkUseWSTP;
        private NumericUpDown numUseWSTP;
        private CheckBox chkMeleeRange;
        private NumericUpDown numMeleeRange;
        private NumericUpDown numPullDistance;
        private NumericUpDown numPullSearchRadius;
        private Label lblPullDistance;
        private Label lblPullSearchRadius;
        private Label lblWeaponSkill;
        private ComboBox cboWeaponSkills;
        private CheckBox chkUseCapPointEquip;
        private CheckBox chkUseExpPointEquip;
        private CheckBox chkSummonTrusts;
        private CheckBox chkAutoHeal;
        private ComboBox cboPullSpells;
        private CheckBox chkPullWithBlackMagicSpell;
    }
}