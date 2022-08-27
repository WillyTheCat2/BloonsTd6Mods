using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
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
    public class Decidueye : ModUpgrade<rowlet>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 1000;

        public override string DisplayName => "Decidueye";
        public override string Description => "shoots arrows further and does more damage";

        public override string Portrait => "rowlet-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range *= 2;
            
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage = 5;
            }
        }
    }
}