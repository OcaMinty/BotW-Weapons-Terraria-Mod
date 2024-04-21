using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using OneHitObliterator.Content.BowOfLight;

namespace OneHitObliterator.Content.BowOfLight
{
    public class LightArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A torch but mediocre!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 20;
            Item.height = 40;
            Item.maxStack = 999;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 1.5f;
            Item.value = 10;
            Item.rare = ItemRarityID.Orange;
            Item.shoot = ModContent.ProjectileType<LightArrowProjectile>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 16f; // The speed of the projectile.
            Item.ammo = AmmoID.Arrow; // The ammo class this ammo belongs to.
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IchorArrow, 1)
                .AddIngredient(ItemID.Star, 5)
                .Register();
        }
    }
}