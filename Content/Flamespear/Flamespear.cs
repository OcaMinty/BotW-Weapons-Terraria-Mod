using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace OneHitObliterator.Content.Flamespear
{
    public class Flamespear : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Makeshift Tongs?\n(Right Click to Throw)");

            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(silver: 50);

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 12;
            Item.useTime = 18;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;

            Item.damage = 45;
            Item.knockBack = 5.0f;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.noMelee = false;

            Item.shootSpeed = 3.7f;
            Item.shoot = ModContent.ProjectileType<FlamespearProjectile>();

            Item.pick = 100;
        }

        public override bool AltFunctionUse(Player player)//You use this to allow the item to be right clicked
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)//Sets what happens on right click(special ability)
            {
                Item.damage = 100;
                Item.noMelee = true;
                Item.width = 14;
                Item.height = 50;
                Item.useTime = 5;
                Item.useAnimation = 5;
                Item.noUseGraphic = true;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.knockBack = 5;
                Item.crit = 10;
                Item.shoot = ModContent.ProjectileType<FlamespearThrow>();
                Item.shootSpeed = 10f;
            }
            else //Sets what happens on left click(normal use)
            {
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.useAnimation = 17;
                Item.useTime = 20;
                Item.UseSound = SoundID.Item71;
                Item.autoReuse = true;

                Item.damage = 45;
                Item.knockBack = 5.0f;
                Item.noUseGraphic = true;
                Item.DamageType = DamageClass.MeleeNoSpeed;
                Item.noMelee = false;

                Item.shootSpeed = 3.7f;
                Item.shoot = ModContent.ProjectileType<FlamespearProjectile>();
            }
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

        public override bool? UseItem(Player player)
        {
            if (!Main.dedServ && Item.UseSound.HasValue)
            {
                SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
            }

            return null;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Burning, 600);
            target.AddBuff(BuffID.OnFire, 600);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Fireblossom, 7)
                .AddIngredient(ItemID.RichMahogany, 6)
                .AddIngredient(ItemID.PalladiumBar, 5)
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