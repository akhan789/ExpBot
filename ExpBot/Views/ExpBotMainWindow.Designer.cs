
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
            this.expBotMainWindowPanel = new System.Windows.Forms.Panel();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblTP = new System.Windows.Forms.Label();
            this.lblMP = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblCharacterMP = new System.Windows.Forms.Label();
            this.lblCharacterTP = new System.Windows.Forms.Label();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.lblCharacterHP = new System.Windows.Forms.Label();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.cboProcesses = new System.Windows.Forms.ComboBox();
            this.expBotMainWindowMenuStrip.SuspendLayout();
            this.expBotMainWindowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // expBotMainWindowMenuStrip
            // 
            this.expBotMainWindowMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.expBotMainWindowMenuStrip.Location = new System.Drawing.Point(5, 5);
            this.expBotMainWindowMenuStrip.Name = "expBotMainWindowMenuStrip";
            this.expBotMainWindowMenuStrip.Size = new System.Drawing.Size(614, 24);
            this.expBotMainWindowMenuStrip.TabIndex = 0;
            this.expBotMainWindowMenuStrip.Text = "expBotMainWindowMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // expBotMainWindowPanel
            // 
            this.expBotMainWindowPanel.AutoSize = true;
            this.expBotMainWindowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.expBotMainWindowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expBotMainWindowPanel.Controls.Add(this.btnStartStop);
            this.expBotMainWindowPanel.Controls.Add(this.lblTP);
            this.expBotMainWindowPanel.Controls.Add(this.lblMP);
            this.expBotMainWindowPanel.Controls.Add(this.lblName);
            this.expBotMainWindowPanel.Controls.Add(this.lblHP);
            this.expBotMainWindowPanel.Controls.Add(this.lblCharacterMP);
            this.expBotMainWindowPanel.Controls.Add(this.lblCharacterTP);
            this.expBotMainWindowPanel.Controls.Add(this.txtConsole);
            this.expBotMainWindowPanel.Controls.Add(this.lblCharacterHP);
            this.expBotMainWindowPanel.Controls.Add(this.lblCharacterName);
            this.expBotMainWindowPanel.Controls.Add(this.cboProcesses);
            this.expBotMainWindowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expBotMainWindowPanel.Location = new System.Drawing.Point(5, 29);
            this.expBotMainWindowPanel.Name = "expBotMainWindowPanel";
            this.expBotMainWindowPanel.Size = new System.Drawing.Size(614, 227);
            this.expBotMainWindowPanel.TabIndex = 1;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(534, 61);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 10;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lblTP
            // 
            this.lblTP.AutoSize = true;
            this.lblTP.Location = new System.Drawing.Point(84, 66);
            this.lblTP.Name = "lblTP";
            this.lblTP.Size = new System.Drawing.Size(33, 13);
            this.lblTP.TabIndex = 9;
            this.lblTP.Text = "<TP>";
            // 
            // lblMP
            // 
            this.lblMP.AutoSize = true;
            this.lblMP.Location = new System.Drawing.Point(84, 53);
            this.lblMP.Name = "lblMP";
            this.lblMP.Size = new System.Drawing.Size(35, 13);
            this.lblMP.TabIndex = 8;
            this.lblMP.Text = "<MP>";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(84, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "<Name>";
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Location = new System.Drawing.Point(84, 40);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(34, 13);
            this.lblHP.TabIndex = 6;
            this.lblHP.Text = "<HP>";
            // 
            // lblCharacterMP
            // 
            this.lblCharacterMP.AutoSize = true;
            this.lblCharacterMP.Location = new System.Drawing.Point(3, 53);
            this.lblCharacterMP.Name = "lblCharacterMP";
            this.lblCharacterMP.Size = new System.Drawing.Size(75, 13);
            this.lblCharacterMP.TabIndex = 5;
            this.lblCharacterMP.Text = "Character MP:";
            // 
            // lblCharacterTP
            // 
            this.lblCharacterTP.AutoSize = true;
            this.lblCharacterTP.Location = new System.Drawing.Point(3, 66);
            this.lblCharacterTP.Name = "lblCharacterTP";
            this.lblCharacterTP.Size = new System.Drawing.Size(73, 13);
            this.lblCharacterTP.TabIndex = 4;
            this.lblCharacterTP.Text = "Character TP:";
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(3, 86);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(607, 137);
            this.txtConsole.TabIndex = 3;
            // 
            // lblCharacterHP
            // 
            this.lblCharacterHP.AutoSize = true;
            this.lblCharacterHP.Location = new System.Drawing.Point(3, 40);
            this.lblCharacterHP.Name = "lblCharacterHP";
            this.lblCharacterHP.Size = new System.Drawing.Size(74, 13);
            this.lblCharacterHP.TabIndex = 2;
            this.lblCharacterHP.Text = "Character HP:";
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.AutoSize = true;
            this.lblCharacterName.Location = new System.Drawing.Point(3, 27);
            this.lblCharacterName.Name = "lblCharacterName";
            this.lblCharacterName.Size = new System.Drawing.Size(87, 13);
            this.lblCharacterName.TabIndex = 1;
            this.lblCharacterName.Text = "Character Name:";
            // 
            // cboProcesses
            // 
            this.cboProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcesses.FormattingEnabled = true;
            this.cboProcesses.Location = new System.Drawing.Point(3, 3);
            this.cboProcesses.Name = "cboProcesses";
            this.cboProcesses.Size = new System.Drawing.Size(607, 21);
            this.cboProcesses.TabIndex = 0;
            this.cboProcesses.SelectedIndexChanged += new System.EventHandler(this.cboProcesses_SelectedIndexChanged);
            // 
            // ExpBotMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(624, 261);
            this.Controls.Add(this.expBotMainWindowPanel);
            this.Controls.Add(this.expBotMainWindowMenuStrip);
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
            this.expBotMainWindowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip expBotMainWindowMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel expBotMainWindowPanel;
        private System.Windows.Forms.ComboBox cboProcesses;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Label lblCharacterHP;
        private System.Windows.Forms.Label lblCharacterName;
        private System.Windows.Forms.Label lblCharacterTP;
        private System.Windows.Forms.Label lblCharacterMP;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTP;
        private System.Windows.Forms.Label lblMP;
        private System.Windows.Forms.Button btnStartStop;
    }
}