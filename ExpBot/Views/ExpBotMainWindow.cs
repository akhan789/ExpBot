using ExpBot.Logging;
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
        //private ILog log = LogManager.GetLogger(typeof(ExpBotMainWindow));
        private IExpBotPresenter presenter;
        private IExpBotModel model;
        public ExpBotMainWindow()
        {
            InitializeComponent();
            //ExpBotTextBoxLogAppender.ConfigureExpBotTextBoxLogAppender(txtConsole);
            model = new ExpBotDefaultModel();
            presenter = new ExpBotDefaultPresenter(this, model);
            //log.Info("ExpBotMainWindow: launching Exp Bot");
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

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (presenter.StartStopBot())
            {
                btnStartStop.Text = "Stop";
            }
            else
            {
                btnStartStop.Text = "Start";
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
