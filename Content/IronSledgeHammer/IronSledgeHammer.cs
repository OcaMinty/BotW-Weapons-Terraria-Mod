using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace OneHitObliterator.Content.IronSledgeHammer
{
    public class IronSledgeHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Sledgehammer");
            Tooltip.SetDefault("Some main character dude named 'Terraria' put a spelunker potion inside this very weapon...");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 30);

            Item.damage = 20;
            Item.knockBack = 6f;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 40;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 4;

            Item.pick = 55;
        }
        public override bool? UseItem(Player player)
        {
            player.AddBuff(BuffID.Spelunker, 60);
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IronHammer, 1)
                .AddIngredient(ItemID.MeteoriteBar, 15)
                .Register();
        }
    }
}