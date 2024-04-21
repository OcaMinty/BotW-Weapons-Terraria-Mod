using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using OneHitObliterator.Content;

namespace OneHitObliterator.Content.TreeBranch
{
    internal class TreeBranch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tree Branch");
            Tooltip.SetDefault("'Your Tree Branch is bad damaged.'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 60;
            Item.useAnimation = 13;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 1;
            Item.knockBack = 4f;
            Item.crit = 4;

            Item.value = Item.buyPrice(copper: 1);
            Item.rare = ItemRarityID.Gray;

            Item.UseSound = SoundID.Item1;


        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 2)
                .Register();
        }
    }
}
