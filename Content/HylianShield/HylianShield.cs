using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace OneHitObliterator.Content.HylianShield
{
	[AutoloadEquip(EquipType.Shield)] // Load the spritesheet you create as a shield for the player when it is equipped.
	public class HylianShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hylian Shield Replica");
			Tooltip.SetDefault("Well excuuuuseee me, princess!");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = Item.buyPrice(gold: 2, silver: 75);
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;

			Item.defense = 7;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.endurance = 1f - (0.1f * (1f - player.endurance));  // The percentage of damage reduction
            player.hasPaladinShield = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PaladinsShield, 1)
                .AddIngredient(ItemID.MeteoriteBar, 15)
                .Register();
        }
    }
}