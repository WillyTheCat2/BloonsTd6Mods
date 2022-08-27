using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace rowlet.Upgrades.MiddlePath
{
    public class Dartrix : ModUpgrade<rowlet>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 1600;

        public override string DisplayName => "Evolve into Dartrix";
        public override string Description => "Dartrix's trickshots allow for increased range and popping lead bloons";

        public override string Portrait => "rowlet-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {

            
            tower.range += 10;
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            }
        }

       
    }
}