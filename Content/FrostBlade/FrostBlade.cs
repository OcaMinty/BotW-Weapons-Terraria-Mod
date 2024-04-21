using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace OneHitObliterator.Content.FrostBlade
{
    public class FrostBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostblade");
            Tooltip.SetDefault("Chris Pratt, he's so cool!");

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
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Frozen, 600);
            target.AddBuff(BuffID.Frostburn, 600);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IceFeather, 5)
                .AddIngredient(ItemID.BorealWood, 3)
                .AddIngredient(ItemID.CobaltBar, 2)
                .Register();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(6))
            { //There is a 1/6 chance of dust occurring. Experiment with the chances by changing the 6
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.IceTorch); //DustID.Electric is the dust that I use, but can be freely changed to another dust that glows
            }
        }
    }
}