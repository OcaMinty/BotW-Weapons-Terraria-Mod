using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using OneHitObliterator.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OneHitObliterator.Content.Torch
{
    internal class Torch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Torch");
            Tooltip.SetDefault("Set Ablaze!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 1;
            Item.knockBack = 4f;
            Item.crit = 4;

            Item.value = Item.buyPrice(copper: 1);
            Item.rare = ItemRarityID.White;

            Item.UseSound = SoundID.Item1;


        }


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 10)
                .AddIngredient(ItemID.Gel, 10)
                .Register();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(1))
            { //There is a 1/6 chance of dust occurring. Experiment with the chances by changing the 6
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch); //DustID.Electric is the dust that I use, but can be freely changed to another dust that glows
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Burning, 600);
            target.AddBuff(BuffID.OnFire, 600);
        }
    }
}
