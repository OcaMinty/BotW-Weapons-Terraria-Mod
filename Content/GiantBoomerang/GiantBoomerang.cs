using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace OneHitObliterator.Content.GiantBoomerang
{
    internal class GiantBoomerang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giant Boomerang");
            Tooltip.SetDefault("I like it big. I like it chunky, Chunkyyy~");
            SacrificeTotal = 1;

            ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 35;
            Item.useTime = 45;
            Item.knockBack = 7.75f;
            Item.width = 30;
            Item.height = 10;
            Item.damage = 60;
            Item.knockBack = 4.0f;
            Item.crit = 4;
            Item.scale = 1.1f;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<GiantBoomerangProjectile>();
            Item.shootSpeed = 12f;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 1);
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 20)
                .AddIngredient(ItemID.TitaniumBar, 15)
                .Register();
        }
    }
}