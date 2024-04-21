using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using OneHitObliterator.Content;
using Terraria.Testing;
using Microsoft.Xna.Framework;

namespace OneHitObliterator.Content.OneHitWeapon
{
    internal class OneHitObliterator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("One Hit Obliterator");
            Tooltip.SetDefault("A sacred weapon told to slay any foe in one swing\n'Link, wake up..'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 25;
            Item.useAnimation = 20;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 999999999;
            Item.knockBack = 2f;
            Item.crit = 5;

            Item.value = Item.buyPrice(copper: 1);
            Item.rare = ItemRarityID.Purple;

            Item.UseSound = SoundID.Item1;


        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LunarBar, 30)
                .AddIngredient(ItemID.Diamond, 5)
                .AddIngredient(ItemID.SoulofFlight, 1)
                .AddIngredient(ItemID.SoulofMight, 1)
                .AddIngredient(ItemID.SoulofLight, 1)
                .AddIngredient(ItemID.SoulofSight, 1)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
        public override void UpdateInventory(Player player)
        {
            player.statLife = 1;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(6))
            { //There is a 1/6 chance of dust occurring. Experiment with the chances by changing the 6
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.BlueTorch); //DustID.Electric is the dust that I use, but can be freely changed to another dust that glows
            }
        }
    }
}
