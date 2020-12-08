﻿using ExpBot.Logging;
using ExpBot.Model;
using ExpBot.ViewModel;
using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ExpBot.Views
{
    public partial class ExpBotMainWindow : Form, IExpBotView
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ExpBotMainWindow));
        private IExpBotPresenter presenter;
        private IExpBotModel model;
        public ExpBotMainWindow()
        {
            InitializeComponent();
            ExpBotTextBoxLogAppender.ConfigureExpBotTextBoxLogAppender(txtConsole);
            model = new ExpBotDefaultModel();
            presenter = new ExpBotDefaultPresenter(this, model);
        }

        protected override void OnLoad(EventArgs e)
        {
            //lblCharacterHP.DataBindings.Add(new Binding("Text", model, nameof(model.Player)));
            presenter.OnLoad();
        }

        private void ExpBotMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            presenter.Close();
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.Close();
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ExpBotAboutBox().ShowDialog();
        }

        private void cboProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!presenter.Initialised)
            {
                presenter.Initialise((Process)cboProcesses.SelectedItem);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            log.Info("ExpBotMainWindow: Starting Exp Bot");
            if (presenter.StartStopBot())
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                MessageBox.Show("Load Final Fantasy XI before attempting to start the script");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!presenter.StartStopBot())
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        public void UpdatePOLProcessList()
        {
            cboProcesses.Invoke(new MethodInvoker(delegate
            {
                cboProcesses.DataSource = null;
                cboProcesses.SelectedItem = null;
                cboProcesses.ResetText();
                cboProcesses.Items.Clear();
                cboProcesses.DataSource = model.POLProcesses;
                cboProcesses.DisplayMember = "MainWindowTitle";
                cboProcesses.ValueMember = "Id";
            }));
        }
    }
}
