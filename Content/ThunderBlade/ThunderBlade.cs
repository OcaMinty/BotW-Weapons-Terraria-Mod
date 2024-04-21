using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace OneHitObliterator.Content.ThunderBlade
{
    public class ThunderBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thunderblade");
            Tooltip.SetDefault("Shocking, isn't it?");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.knockBack = 3.0f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.useTime = 21;
            Item.width = 64;
            Item.height = 64;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noUseGraphic = false;
            Item.noMelee = false;
            Item.mana = 4;
            Item.crit = 4;

            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(silver: 30);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LightningBug, 30)
                .AddIngredient(ItemID.PalmWood, 3)
                .AddIngredient(ItemID.GoldBar, 75)
                .Register();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(6))
            { //There is a 1/6 chance of dust occurring. Experiment with the chances by changing the 6
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.YellowTorch); //DustID.Electric is the dust that I use, but can be freely changed to another dust that glows
            }
        }
    }
}