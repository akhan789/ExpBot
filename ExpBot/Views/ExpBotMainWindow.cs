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
            presenter.OnLoad();
        }
        private void ExpBotMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.Close();
        }
        public void CloseView()
        {
            Close();
            Environment.Exit(0);
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
        private void chkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlwaysOnTop.Checked)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }
        private void btnRefreshTargetList_Click(object sender, EventArgs e)
        {
            UpdateTargetList();
        }
        private void lstTargets_DoubleClick(object sender, EventArgs e)
        {
            if (lstTargets.Items.Count <= 0)
            {
                return;
            }
            presenter.AddTarget(lstTargets.SelectedItem.ToString());
        }
        private void lstSelectedTargets_DoubleClick(object sender, EventArgs e)
        {
            if (lstSelectedTargets.Items.Count <= 0)
            {
                return;
            }
            presenter.RemoveTarget(lstSelectedTargets.SelectedItem.ToString());
        }
        public void lstTrustSelections_Click(object sender, EventArgs e)
        {
            if (lstTrustSelections.Items.Count <= 0)
            {
                return;
            }
            if (lstTrustSelections.SelectedItems.Count == 5)
            {
                lstTrustSelections.Enabled = false;
            }
            presenter.SetTrusts(lstTrustSelections.SelectedItems.Cast<String>().ToList());
        }
        private void btnResetTrustList_Click(object sender, EventArgs e)
        {
            if (lstTrustSelections.Items.Count <= 0)
            {
                return;
            }
            lstTrustSelections.SelectedItems.Clear();
            lstTrustSelections.Enabled = true;
        }
        public void UpdatePOLProcessList()
        {
            if (cboProcesses.IsDisposed)
            {
                return;
            }
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
        public void UpdateTargetList()
        {
            if (lstTargets.IsDisposed)
            {
                return;
            }
            lstTargets.Invoke(new MethodInvoker(delegate
            {
                lstTargets.DataSource = null;
                lstTargets.SelectedItem = null;
                lstTargets.ResetText();
                lstTargets.Items.Clear();
                lstTargets.DataSource = model.TargetList;
            }));
        }
        public void UpdateTrustList()
        {
            if (lstTrustSelections.IsDisposed)
            {
                return;
            }
            lstTrustSelections.Invoke(new MethodInvoker(delegate
            {
                lstTrustSelections.DataSource = null;
                lstTrustSelections.SelectedItem = null;
                lstTrustSelections.ResetText();
                lstTrustSelections.Items.Clear();
                lstTrustSelections.DataSource = model.TrustList;
            }));
        }
        public void UpdateSelectedTargets()
        {
            if (lstSelectedTargets.IsDisposed)
            {
                return;
            }
            lstSelectedTargets.Invoke(new MethodInvoker(delegate
            {
                lstSelectedTargets.DataSource = null;
                lstSelectedTargets.SelectedItem = null;
                lstSelectedTargets.ResetText();
                lstSelectedTargets.Items.Clear();
                lstSelectedTargets.DataSource = model.SelectedTargetList;
            }));
        }
        public void UpdatePlayerDetails()
        {
            if (IsDisposed)
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    lblName.Text = model.Player.Name;
                    lblHP.Text = model.Player.HP.ToString() + "/" + model.Player.MaxHP.ToString();
                    lblMP.Text = model.Player.MP.ToString() + "/" + model.Player.MaxMP.ToString();
                    lblTP.Text = model.Player.TP.ToString();
                    lblStatus.Text = model.Player.PlayerStatus.ToString();
                }));
            }
        }
        public void UpdateTargetDetails()
        {
            if (IsDisposed)
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                }));
            }
        }
        public void UpdatePartyDetails()
        {
            if (IsDisposed)
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                }));
            }
        }
    }
}
