using OneHitObliterator.Content;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using OneHitObliterator.Content.DuplexBow;

namespace OneHitObliterator.Content.LynelBow
{
    public class LynelBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Savage Lynel Bow");
            Tooltip.SetDefault("3 is better than 2, they say.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(silver: 16);

            Item.damage = 32;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 80;
            Item.useTime = 26;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 0f;
            Item.value = 10000;
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.IchorArrow;
            Item.shootSpeed = 10;
            Item.crit = 4;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3;
            float rotation = MathHelper.ToRadians(6);
            position += Vector2.Normalize(velocity) * 40f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 40f;
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<DuplexBow.DuplexBow>(), 2)
                .AddIngredient(ItemID.TitaniumBar, 15)
                .Register();
        }
    }
}