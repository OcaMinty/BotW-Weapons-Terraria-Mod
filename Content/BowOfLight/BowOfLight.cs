using OneHitObliterator.Content;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace OneHitObliterator.Content.BowOfLight
{
    public class BowOfLight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bow Of Light");
            Tooltip.SetDefault("Ooh, glowy...");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 34;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 10.0f;
            Item.value = 10000;
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<LightArrowProjectile>();
            Item.shootSpeed = 10;
            Item.crit = 32;
            Item.mana = 11;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemonBow, 1)
                .AddIngredient(ModContent.ItemType<LightArrow>(), 10)
                .AddIngredient(ItemID.ManaCrystal, 15)
                .AddIngredient(ItemID.LightShard, 2)
                .Register();
        }
    }
}