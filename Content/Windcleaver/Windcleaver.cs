using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;


namespace OneHitObliterator.Content.Windcleaver
{
    public class Windcleaver : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It cleaves wind, by the way.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 54);

            Item.damage = 26;
            Item.DamageType = DamageClass.Melee;
            Item.width = 34;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 17;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = false;
            Item.knockBack = 2.5f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<WindcleaverProjectile>();
            Item.shootSpeed = 20;
            Item.crit = 4;
            Item.mana = 6;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MeteoriteBar, 5)
                .AddIngredient(ItemID.CloudinaBottle, 1)
                .AddIngredient(ItemID.Ruby, 10)
                .Register();
        }
    }
}