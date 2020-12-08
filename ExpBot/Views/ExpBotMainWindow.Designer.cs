
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
            this.tblLayoutExpBotMainWindow = new System.Windows.Forms.TableLayoutPanel();
            this.pnlConsole = new System.Windows.Forms.Panel();
            this.chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.expBotMainWindowMenuStrip.SuspendLayout();
            this.expBotMainWindowPanel.SuspendLayout();
            this.tblLayoutPanelControls.SuspendLayout();
            this.tblLayoutExpBotMainWindow.SuspendLayout();
            this.pnlConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // expBotMainWindowMenuStrip
            // 
            this.tblLayoutPanelControls.SetColumnSpan(this.expBotMainWindowMenuStrip, 4);
            this.expBotMainWindowMenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expBotMainWindowMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.expBotMainWindowMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.expBotMainWindowMenuStrip.Name = "expBotMainWindowMenuStrip";
            this.expBotMainWindowMenuStrip.Size = new System.Drawing.Size(767, 29);
            this.expBotMainWindowMenuStrip.TabIndex = 0;
            this.expBotMainWindowMenuStrip.Text = "expBotMainWindowMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 25);
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
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 25);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cboProcesses
            // 
            this.tblLayoutPanelControls.SetColumnSpan(this.cboProcesses, 3);
            this.cboProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcesses.FormattingEnabled = true;
            this.cboProcesses.Location = new System.Drawing.Point(118, 32);
            this.cboProcesses.Name = "cboProcesses";
            this.cboProcesses.Size = new System.Drawing.Size(646, 21);
            this.cboProcesses.TabIndex = 0;
            this.cboProcesses.SelectedIndexChanged += new System.EventHandler(this.cboProcesses_SelectedIndexChanged);
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.AutoSize = true;
            this.lblCharacterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterName.Location = new System.Drawing.Point(3, 58);
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
            this.lblCharacterHP.Location = new System.Drawing.Point(3, 87);
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
            this.lblCharacterTP.Location = new System.Drawing.Point(3, 145);
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
            this.lblCharacterMP.Location = new System.Drawing.Point(3, 116);
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
            this.lblHP.Location = new System.Drawing.Point(118, 87);
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
            this.lblName.Location = new System.Drawing.Point(118, 58);
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
            this.lblMP.Location = new System.Drawing.Point(118, 116);
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
            this.lblTP.Location = new System.Drawing.Point(118, 145);
            this.lblTP.Name = "lblTP";
            this.lblTP.Size = new System.Drawing.Size(109, 29);
            this.lblTP.TabIndex = 9;
            this.lblTP.Text = "<TP>";
            this.lblTP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(689, 61);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(767, 496);
            this.txtConsole.TabIndex = 3;
            this.txtConsole.WordWrap = false;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(689, 90);
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
            this.expBotMainWindowPanel.Location = new System.Drawing.Point(3, 3);
            this.expBotMainWindowPanel.Name = "expBotMainWindowPanel";
            this.expBotMainWindowPanel.Size = new System.Drawing.Size(769, 212);
            this.expBotMainWindowPanel.TabIndex = 1;
            // 
            // tblLayoutPanelControls
            // 
            this.tblLayoutPanelControls.ColumnCount = 4;
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tblLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutPanelControls.Controls.Add(this.expBotMainWindowMenuStrip, 0, 0);
            this.tblLayoutPanelControls.Controls.Add(this.lblCharacterStatus, 0, 6);
            this.tblLayoutPanelControls.Controls.Add(this.lblStatus, 1, 6);
            this.tblLayoutPanelControls.Controls.Add(this.lblCharacterTP, 0, 5);
            this.tblLayoutPanelControls.Controls.Add(this.lblTP, 1, 5);
            this.tblLayoutPanelControls.Controls.Add(this.lblCharacterMP, 0, 4);
            this.tblLayoutPanelControls.Controls.Add(this.lblMP, 1, 4);
            this.tblLayoutPanelControls.Controls.Add(this.lblCharacterHP, 0, 3);
            this.tblLayoutPanelControls.Controls.Add(this.lblHP, 1, 3);
            this.tblLayoutPanelControls.Controls.Add(this.lblCharacterName, 0, 2);
            this.tblLayoutPanelControls.Controls.Add(this.lblName, 1, 2);
            this.tblLayoutPanelControls.Controls.Add(this.cboProcesses, 1, 1);
            this.tblLayoutPanelControls.Controls.Add(this.lblSelectProcess, 0, 1);
            this.tblLayoutPanelControls.Controls.Add(this.chkAlwaysOnTop, 3, 6);
            this.tblLayoutPanelControls.Controls.Add(this.btnStart, 3, 2);
            this.tblLayoutPanelControls.Controls.Add(this.btnStop, 3, 3);
            this.tblLayoutPanelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutPanelControls.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutPanelControls.Name = "tblLayoutPanelControls";
            this.tblLayoutPanelControls.RowCount = 7;
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayoutPanelControls.Size = new System.Drawing.Size(767, 210);
            this.tblLayoutPanelControls.TabIndex = 1;
            // 
            // lblCharacterStatus
            // 
            this.lblCharacterStatus.AutoSize = true;
            this.lblCharacterStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCharacterStatus.Location = new System.Drawing.Point(3, 174);
            this.lblCharacterStatus.Name = "lblCharacterStatus";
            this.lblCharacterStatus.Size = new System.Drawing.Size(109, 36);
            this.lblCharacterStatus.TabIndex = 13;
            this.lblCharacterStatus.Text = "Character Status:";
            this.lblCharacterStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(118, 174);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(109, 36);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "<Status>";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectProcess
            // 
            this.lblSelectProcess.AutoSize = true;
            this.lblSelectProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectProcess.Location = new System.Drawing.Point(3, 29);
            this.lblSelectProcess.Name = "lblSelectProcess";
            this.lblSelectProcess.Size = new System.Drawing.Size(109, 29);
            this.lblSelectProcess.TabIndex = 15;
            this.lblSelectProcess.Text = "Process:";
            this.lblSelectProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tblLayoutExpBotMainWindow
            // 
            this.tblLayoutExpBotMainWindow.ColumnCount = 1;
            this.tblLayoutExpBotMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutExpBotMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutExpBotMainWindow.Controls.Add(this.pnlConsole, 0, 1);
            this.tblLayoutExpBotMainWindow.Controls.Add(this.expBotMainWindowPanel, 0, 0);
            this.tblLayoutExpBotMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutExpBotMainWindow.Location = new System.Drawing.Point(5, 5);
            this.tblLayoutExpBotMainWindow.Name = "tblLayoutExpBotMainWindow";
            this.tblLayoutExpBotMainWindow.RowCount = 2;
            this.tblLayoutExpBotMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.28169F));
            this.tblLayoutExpBotMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.71831F));
            this.tblLayoutExpBotMainWindow.Size = new System.Drawing.Size(775, 722);
            this.tblLayoutExpBotMainWindow.TabIndex = 2;
            // 
            // pnlConsole
            // 
            this.pnlConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConsole.Controls.Add(this.txtConsole);
            this.pnlConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConsole.Location = new System.Drawing.Point(3, 221);
            this.pnlConsole.Name = "pnlConsole";
            this.pnlConsole.Size = new System.Drawing.Size(769, 498);
            this.pnlConsole.TabIndex = 12;
            // 
            // chkAlwaysOnTop
            // 
            this.chkAlwaysOnTop.AutoSize = true;
            this.chkAlwaysOnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAlwaysOnTop.Location = new System.Drawing.Point(654, 177);
            this.chkAlwaysOnTop.Name = "chkAlwaysOnTop";
            this.chkAlwaysOnTop.Size = new System.Drawing.Size(110, 30);
            this.chkAlwaysOnTop.TabIndex = 16;
            this.chkAlwaysOnTop.Text = "Always on Top";
            this.chkAlwaysOnTop.UseVisualStyleBackColor = true;
            this.chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkAlwaysOnTop_CheckedChanged);
            // 
            // ExpBotMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
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
            this.pnlConsole.ResumeLayout(false);
            this.pnlConsole.PerformLayout();
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
        private Panel pnlConsole;
        private Label lblCharacterStatus;
        private Label lblStatus;
        private TableLayoutPanel tblLayoutPanelControls;
        private Label lblSelectProcess;
        private CheckBox chkAlwaysOnTop;
    }
}