using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
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
    public class Spirit_Shackle : ModUpgrade<rowlet>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 10000;

        public override string DisplayName => "Spirit Shackle";
        public override string Description => "decidueyes signature move does massive damage";

        public override string Portrait => "rowlet-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)

        {
            var abilityModel = new AbilityModel("AbilityModel_SpiritShackle", "Spririt Shackle",
                "uses its signature move", 1, 0,
                GetSpriteReference(Icon), 44f, null, false, false, null,
                0, 0, 9999999, false, false);
            towerModel.AddBehavior(abilityModel);

            var activateAttackModel = new ActivateAttackModel("ActivateAttackModel_SpiritShackle", 0, true,
                new Il2CppReferenceArray<AttackModel>(1), true, false, false, false, false);
            abilityModel.AddBehavior(activateAttackModel);

            var attackModel = activateAttackModel.attacks[0] =
                Game.instance.model.GetTower(TowerType.BoomerangMonkey, 4).GetAttackModel().Duplicate();
            activateAttackModel.AddChildDependant(attackModel);

            attackModel.behaviors = attackModel.behaviors
               .RemoveItemOfType<Model, RotateToTargetModel>()
               .RemoveItemOfType<Model, TargetStrongModel>()
               .RemoveItemOfType<Model, TargetLastModel>()
               .RemoveItemOfType<Model, TargetCloseModel>();

            var targetFirstModel = attackModel.GetBehavior<TargetFirstModel>();
            targetFirstModel.isSelectable = false;
            attackModel.targetProvider = targetFirstModel;

            attackModel.range = 2000;
            attackModel.attackThroughWalls = true;



            foreach (var weaponModel in towerModel.GetWeapons())
            {

                weaponModel.projectile.GetDamageModel().damage *= 2;
            }
        }
    }
}