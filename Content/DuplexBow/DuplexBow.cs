using OneHitObliterator.Content;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace OneHitObliterator.Content.DuplexBow
{
	public class DuplexBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duplex Bow");
			Tooltip.SetDefault("2 in 1 they say...");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 16);

			Item.damage = 40;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 26;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0f;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.IchorArrow;
			Item.shootSpeed = 10;
			Item.crit = 4;
			Item.useAmmo = AmmoID.Arrow;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float numberProjectiles = 2;
			float rotation = MathHelper.ToRadians(2);
			position += Vector2.Normalize(velocity) * 20f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 20f; 
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
		}
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TendonBow, 2)
                .AddIngredient(ItemID.CursedArrow, 20)
                .AddIngredient(ItemID.GoldBar, 15)
                .Register();
        }
    }
}