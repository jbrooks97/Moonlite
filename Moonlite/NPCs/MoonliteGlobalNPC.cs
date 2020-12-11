using Moonlite.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Moonlite.NPCs
{
    public class MoonlightGlobalNPC : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) {
            
            if(player.HasBuff(mod.BuffType("TimelessTranquility"))) {
                maxSpawns = 0;
            }
            if(Main.dayRate == 0) {
                maxSpawns = 0;
            }

            base.EditSpawnRate(player, ref spawnRate, ref maxSpawns);
        }
    }
}