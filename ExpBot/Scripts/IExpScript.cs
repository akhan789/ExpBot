using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ExpBot.Model.EliteAPIWrappers.APIConstants;

namespace ExpBot.Scripts
{
    public interface IExpScript : IScript
    {
        bool KeepWithinMeleeRange { get; set; }
        bool RestMP { get; set; }
        bool UseWeaponSkill { get; set; }
        bool SummonTrusts { get; set; }
        bool UseCapPointEquipment { get; set; }
        bool UseExpPointEquipment { get; set; }
        bool UseAutoHeal { get; set; }
        bool PullWithSpell { get; set; }
        IList<string> TargetNames { get; set; }
        IList<string> TrustNames { get; set; }
        BlackMagicSpellId PullBlackMagicSpellId { get; set; }
        int RestMPP { get; set; }
        TPAbilityId WeaponSkillId { get; set; }
        int WeaponSkillTP { get; set; }
        double MeleeRange { get; set; }
        double PullDistance { get; set; }
        float PullSearchRadius { get; set; }
    }
}