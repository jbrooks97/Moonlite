
using Terraria;
using Terraria.ModLoader;

namespace Moonlite.Buffs
{
	public class TimelessTranquility : ModBuff
	{

		public override void SetDefaults() {
			DisplayName.SetDefault("Timeless Tranquility");
			Description.SetDefault("Enemies will not spawn.");
			canBeCleared = true;
			Main.buffNoTimeDisplay[Type] = true;
		}


        public override void Update(Player player, ref int buffIndex) {
			player.AddBuff(mod.BuffType("TimelessTranquility"), 350);
			//player.enemySpawns = false;
        }
    }
}