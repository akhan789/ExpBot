using ExpBot.Logging;
using ExpBot.Model;
using ExpBot.ViewModel;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static ExpBot.Model.EliteAPIWrappers.APIConstants;

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
            model.KeepWithinMeleeRange = chkMeleeRange.Checked;
            model.RestMP = chkRestMPP.Checked;
            model.UseWeaponSkill = chkUseWSTP.Checked;
            model.SummonTrusts = chkSummonTrusts.Checked;
            model.ReturnToIdleLocation = chkReturnToIdleLocation.Checked;
            model.UseCapPointEquipment = chkUseCapPointEquip.Checked;
            model.UseExpPointEquipment = chkUseExpPointEquip.Checked;
            model.UseAutoHeal = chkAutoHeal.Checked;
            model.PullWithSpell = chkPullWithBlackMagicSpell.Checked;
            //model.SelectedTargetList = ;
            //model.SelectedTrustList = ;
            model.PullDistance = Convert.ToDouble(numPullDistance.Value);
            model.PullSearchRadius = Convert.ToSingle(numPullSearchRadius.Value);
            model.MeleeRange = Convert.ToDouble(numMeleeRange.Value);
            model.RestMPP = Convert.ToInt32(numRestMPP.Value);
            model.IdleRadius = Convert.ToSingle(numIdleRadius.Value);
            model.WeaponSkillTP = Convert.ToInt32(numUseWSTP.Value);
            object weaponSkillId;
            if ((weaponSkillId = cboWeaponSkills.SelectedItem) != null)
            {
                model.WeaponSkillId = (TPAbilityId)weaponSkillId;
            }
            object blackMagicSpellId;
            if ((blackMagicSpellId = cboPullSpells.SelectedItem) != null)
            {
                model.PullBlackMagicSpellId = (BlackMagicSpellId)blackMagicSpellId;
            }
            if (!presenter.StartBot())
            {
                MessageBox.Show("Load Final Fantasy XI before attempting to start the script");
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate
            {
                presenter.StopBot();
            })).Start();
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
            if (lstTargets.SelectedItem != null)
            {
                presenter.AddTarget(lstTargets.SelectedItem.ToString());
            }
        }
        private void lstSelectedTargets_DoubleClick(object sender, EventArgs e)
        {
            if (lstSelectedTargets.Items.Count <= 0)
            {
                return;
            }
            presenter.RemoveTarget(lstSelectedTargets.SelectedItem.ToString());
        }
        private void lstTrustSelections_Click(object sender, EventArgs e)
        {
            if (lstTrustSelections.Items.Count <= 0)
            {
                return;
            }
            if (lstTrustSelections.SelectedItems.Count == 5)
            {
                lstTrustSelections.Enabled = false;
            }
            model.SelectedTrustList = lstTrustSelections.SelectedItems.Cast<String>().ToList();
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
        private void chkMeleeRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMeleeRange.Checked)
            {
                model.KeepWithinMeleeRange = true;
            }
            else
            {
                model.KeepWithinMeleeRange = false;
            }
        }
        private void chkRestMPP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestMPP.Checked)
            {
                model.RestMP = true;
            }
            else
            {
                model.RestMP = false;
            }
        }
        private void chkUseWSTP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseWSTP.Checked)
            {
                model.UseWeaponSkill = true;
            }
            else
            {
                model.UseWeaponSkill = false;
            }
        }
        private void chkSummonTrusts_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSummonTrusts.Checked)
            {
                model.SummonTrusts = true;
            }
            else
            {
                model.SummonTrusts = false;
            }
        }
        private void chkReturnToIdleLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReturnToIdleLocation.Checked)
            {
                model.ReturnToIdleLocation = true;
            }
            else
            {
                model.ReturnToIdleLocation = false;
            }
        }
        private void chkUseCapPointEquip_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseCapPointEquip.Checked)
            {
                model.UseCapPointEquipment = true;
            }
            else
            {
                model.UseCapPointEquipment = false;
            }
        }
        private void chkUseExpPointEquip_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseExpPointEquip.Checked)
            {
                model.UseExpPointEquipment = true;
            }
            else
            {
                model.UseExpPointEquipment = false;
            }
        }
        private void chkAutoHeal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoHeal.Checked)
            {
                model.UseAutoHeal = true;
            }
            else
            {
                model.UseAutoHeal = false;
            }
        }
        private void chkPullWithBlackMagicSpell_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseExpPointEquip.Checked)
            {
                model.PullWithSpell = true;
            }
            else
            {
                model.PullWithSpell = false;
            }
        }
        private void numPullDistance_ValueChanged(object sender, EventArgs e)
        {
            model.PullDistance = Convert.ToDouble(numPullDistance.Value);
        }
        private void numPullSearchRadius_ValueChanged(object sender, EventArgs e)
        {
            model.PullSearchRadius = Convert.ToSingle(numPullSearchRadius.Value);
        }
        private void numMeleeRange_ValueChanged(object sender, EventArgs e)
        {
            model.MeleeRange = Convert.ToDouble(numMeleeRange.Value);
        }
        private void numRestMPP_ValueChanged(object sender, EventArgs e)
        {
            model.RestMPP = Convert.ToInt32(numRestMPP.Value);
        }
        private void numUseWSTP_ValueChanged(object sender, EventArgs e)
        {
            model.WeaponSkillTP = Convert.ToInt32(numUseWSTP.Value);
        }
        private void numIdleRadius_ValueChanged(object sender, EventArgs e)
        {
            model.IdleRadius = Convert.ToSingle(numIdleRadius.Value);
        }
        private void cboWeaponSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem;
            if ((selectedItem = cboWeaponSkills.SelectedItem) != null)
            {
                model.WeaponSkillId = (TPAbilityId)selectedItem;
            }
        }
        private void cboPullSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem;
            if ((selectedItem = cboPullSpells.SelectedItem) != null)
            {
                model.PullBlackMagicSpellId = (BlackMagicSpellId)selectedItem;
            }
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
                lstTargets.DataSource = model.Player.GetAllAvailableTargets();
                lstTargets.SelectedItem = null;
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
                lstTrustSelections.DataSource = model.Player.GetAllAvailableTrusts();
                lstTrustSelections.SelectedItem = null;
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
        public void UpdatePlayerWeaponSkillList()
        {
            if (cboWeaponSkills.IsDisposed)
            {
                return;
            }
            cboWeaponSkills.Invoke(new MethodInvoker(delegate
            {
                IList<TPAbilityId> currentWeaponSkills = new List<TPAbilityId>();
                foreach (TPAbilityId tpAbilityId in cboWeaponSkills.Items)
                {
                    currentWeaponSkills.Add(tpAbilityId);
                }
                if (!Enumerable.SequenceEqual(currentWeaponSkills, model.Player.GetWeaponSkills()))
                {
                    cboWeaponSkills.DataSource = null;
                    cboWeaponSkills.SelectedItem = null;
                    cboWeaponSkills.ResetText();
                    cboWeaponSkills.Items.Clear();
                    cboWeaponSkills.DataSource = model.Player.GetWeaponSkills();
                }
            }));
        }
        public void UpdatePullBlackMagicSpellsList()
        {
            if (cboPullSpells.IsDisposed)
            {
                return;
            }
            cboPullSpells.Invoke(new MethodInvoker(delegate
            {
                IList<BlackMagicSpellId> currentBlackMagicSpells = new List<BlackMagicSpellId>();
                foreach (BlackMagicSpellId blackMagicSpellId in cboPullSpells.Items)
                {
                    currentBlackMagicSpells.Add(blackMagicSpellId);
                }
                if (!Enumerable.SequenceEqual(currentBlackMagicSpells, model.Player.GetBlackMagicSpells()))
                {
                    cboPullSpells.DataSource = null;
                    cboPullSpells.SelectedItem = null;
                    cboPullSpells.ResetText();
                    cboPullSpells.Items.Clear();
                    cboPullSpells.DataSource = model.Player.GetBlackMagicSpells();
                }
            }));
        }
        public void UpdatePlayerStatusEffectsListView()
        {
            IList<short> currentStatusEffects = new List<short>();
            foreach (ListViewItem statusEffect in lstViewStatusEffects.Items)
            {
                if (!statusEffect.Equals("-1"))
                {
                    currentStatusEffects.Add(Convert.ToInt16(statusEffect.Text));
                }
            }
            IList<short> statusEffects = new List<short>();
            foreach (short statusEffect in model.Player.StatusEffects)
            {
                if (statusEffect != -1)
                {
                    statusEffects.Add(statusEffect);
                }
            }
            if (!Enumerable.SequenceEqual(currentStatusEffects, statusEffects))
            {
                lstViewStatusEffects.Items.Clear();
                for (int i = 0; i < statusEffects.Count; i++)
                {
                    lstViewStatusEffects.Items.Add(new ListViewItem(statusEffects[i].ToString()));
                    lstViewStatusEffects.Items[i].SubItems.Add(Enum.GetName(typeof(StatusEffect), statusEffects[i]));
                }
            }
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
                    UpdatePlayerStatusEffectsListView();
                    UpdatePlayerWeaponSkillList();
                    UpdatePullBlackMagicSpellsList();
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
                    // TODO: 
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
                    //TODO:
                }));
            }
        }
        public void UpdateScriptDetails()
        {
            if (IsDisposed)
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    if (model?.Script.Running == false)
                    {
                        btnStart.Enabled = true;
                        btnStop.Enabled = false;
                        tabctrlBotControls.Enabled = true;
                    }
                    else if (model?.Script.Running == true)
                    {
                        btnStart.Enabled = false;
                        btnStop.Enabled = true;
                        tabctrlBotControls.Enabled = false;
                    }
                }));
            }
            else
            {
                if (model?.Script.Running == false)
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    tabctrlBotControls.Enabled = true;
                }
                else if (model?.Script.Running == true)
                {
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    tabctrlBotControls.Enabled = false;
                }
            }
        }
    }
}