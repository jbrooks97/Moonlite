using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Moonlite.Items
{
	public class InvigoratedGem : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("BasicSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Toggles the flow of time.");
		}

		public override void SetDefaults() {

			//item.damage = 50;
			//item.melee = true;
			item.useTurn = true;
			item.width = 20;
			item.height = 20;
			item.useTime = 90;
			item.useAnimation = 90;
			item.useStyle = 4;
			//item.knockBack = 6;
			item.value = 50000;
			item.rare = 8;
			item.UseSound = SoundID.Item117;
			//item.autoReuse = false;
			
		}

        public override bool UseItem(Player player) {

			if(Main.dayRate != 0) {
				//player.AddBuff(mod.BuffType("TimelessTranquility"),350);
				Main.dayRate = 0;
				Main.NewText("The flow of time has stopped.  Enemy spawn rates are reduced.", Colors.RarityYellow, true);
				
            } else {
				//if(player.HasBuff(mod.BuffType("TimelessTranquility"))) {
				//	player.ClearBuff(mod.BuffType("TimelessTranquility"));
				//}
				Main.dayRate = 1;
				Main.NewText("The flow of time has resumed.", Colors.RarityYellow, true);
			}
			return true;
		}

        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amber, 7);
			recipe.AddIngredient(ItemID.Diamond, 7);
			recipe.AddIngredient(ItemID.Ruby, 7);
			recipe.AddIngredient(ItemID.Emerald, 7);
			recipe.AddIngredient(ItemID.Sapphire, 7);
			recipe.AddIngredient(ItemID.Topaz, 7);
			recipe.AddIngredient(ItemID.Amethyst, 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}