using ExpBot.Model.EliteAPIWrappers;
using ExpBot.Scripts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using static ExpBot.Model.EliteAPIWrappers.APIConstants;

namespace ExpBot.Model
{
    public interface IExpBotModel
    {
        IList<Process> POLProcesses { get; }
        Process CurrentPOLProcess { get; set; }
        void Unload();
        IScript Script { get; set; }
        bool ChaseTarget { get; set; }
        bool KeepWithinMeleeRange { get; set; }
        bool RestMP { get; set; }
        bool UseWeaponSkill { get; set; }
        bool SummonTrusts { get; set; }
        bool ReturnToIdleLocation { get; set; }
        bool UseCapPointEquipment { get; set; }
        bool UseExpPointEquipment { get; set; }
        bool UseAutoHeal { get; set; }
        bool PullWithSpell { get; set; }
        bool PullWithProvoke { get; set; }
        int RestMPP { get; set; }
        TPAbilityId WeaponSkillId { get; set; }
        BlackMagicSpellId PullBlackMagicSpellId { get; set; }
        int WeaponSkillTP { get; set; }
        double MeleeRange { get; set; }
        double PullDistance { get; set; }
        float PullSearchRadius { get; set; }
        float PullDelay { get; set; }
        float IdleRadius { get; set; }
        IList<string> SelectedTargetList { get; set; }
        IList<string> SelectedTrustList { get; set; }
        PlayerWrapper Player { get; set; }
        TargetWrapper Target { get; set; }
        PartyWrapper Party { get; set; }
    }
}
