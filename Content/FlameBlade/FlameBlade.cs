using OneHitObliterator.Content;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace OneHitObliterator.Content.FlameBlade
{
    public class FlameBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flameblade");
            Tooltip.SetDefault("Hotter than your mom, even.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.knockBack = 3.6f;
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
            target.AddBuff(BuffID.Burning, 600);
            target.AddBuff(BuffID.OnFire, 600);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Fireblossom, 5)
                .AddIngredient(ItemID.RichMahogany, 3)
                .AddIngredient(ItemID.PalladiumBar, 2)
                .Register();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(6))
            { //There is a 1/6 chance of dust occurring. Experiment with the chances by changing the 6
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch); //DustID.Electric is the dust that I use, but can be freely changed to another dust that glows
            }
        }
    }
}