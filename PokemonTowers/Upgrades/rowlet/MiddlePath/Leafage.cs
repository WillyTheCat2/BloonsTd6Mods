using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace rowlet.Upgrades.MiddlePath
{
    public class Leafage : ModUpgrade<rowlet>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 400;

        public override string DisplayName => "Leafage";
        public override string Description => "Attacks twice as fast";

        public override string Portrait => "rowlet-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.rate *= .5f;
            }
        }
    }
}