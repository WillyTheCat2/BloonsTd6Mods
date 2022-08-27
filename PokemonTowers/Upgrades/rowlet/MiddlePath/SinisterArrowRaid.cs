using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using UnhollowerBaseLib;

namespace rowlet.Upgrades.MiddlePath
{
    public class SinisterArrowRaid : ModUpgrade<rowlet>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 100;

        public override string DisplayName => "Sinister Arrow Raid";
        public override string Description => "decidueyes Z-Move unleashes huge damage";

        public override string Portrait => "rowlet-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)

        {
            var abilityModel = towerModel.GetAbility();
            abilityModel.resetCooldownOnTierUpgrade = true;
            abilityModel.icon = GetSpriteReference(Icon);
            var projectileModel = abilityModel.GetDescendant<ProjectileModel>();
            projectileModel.GetDamageModel().damage = 1000;
            projectileModel.pierce = 100000;
            foreach (var damageModifierForTagModel in projectileModel.GetBehaviors<DamageModifierForTagModel>())
            {
                damageModifierForTagModel.damageAddative = 2000;
            }

            projectileModel.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                1, 2000, false, false));




        }
    }
}