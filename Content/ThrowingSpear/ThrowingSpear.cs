using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace OneHitObliterator.Content.ThrowingSpear
{
    public class ThrowingSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Throw it real good!\n(Right Click to Throw)");

            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 20, copper: 10);

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 12;
            Item.useTime = 18;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;

            Item.damage = 10;
            Item.knockBack = 5.0f;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.noMelee = false;

            Item.shootSpeed = 3.7f;
            Item.shoot = ModContent.ProjectileType<ThrowingSpearProjectile>();
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
                Item.useTime = 25;
                Item.useAnimation = 20;
                Item.noUseGraphic = true;
                Item.useStyle = ItemUseStyleID.Swing;
                Item.knockBack = 5;
                Item.crit = 4;
                Item.shoot = ModContent.ProjectileType<ThrowingSpearThrow>();
                Item.shootSpeed = 90f;
            }
            else //Sets what happens on left click(normal use)
            {
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.useAnimation = 24;
                Item.useTime = 28;
                Item.UseSound = SoundID.Item71;
                Item.autoReuse = true;

                Item.damage = 5;
                Item.knockBack = 6.0f;
                Item.noUseGraphic = true;
                Item.DamageType = DamageClass.MeleeNoSpeed;
                Item.noMelee = false;

                Item.shootSpeed = 3.7f;
                Item.shoot = ModContent.ProjectileType<ThrowingSpearProjectile>();
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
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 5)
                .AddIngredient(ItemID.CopperBar, 5)
                .AddIngredient(ItemID.ThrowingKnife, 1)
                .Register();
        }
    }
}