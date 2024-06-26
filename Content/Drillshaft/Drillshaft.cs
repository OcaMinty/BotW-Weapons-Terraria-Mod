﻿using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace OneHitObliterator.Content.Drillshaft
{
    public class Drillshaft : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Dollar Tree drill.");

            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.sellPrice(silver: 3);

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 12;
            Item.useTime = 34;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;

            Item.damage = 90;
            Item.knockBack = 6.5f;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.noMelee = false;

            Item.shootSpeed = 3.7f;
            Item.shoot = ModContent.ProjectileType<DrillshaftProjectile>();
            Item.crit = 4;

            Item.pick = 100;
        }

        public override bool CanUseItem(Player player)
        {
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
                .AddIngredient(ItemID.MeteoriteBar, 15)
                .AddIngredient(ItemID.HallowedBar, 10)
                .Register();
        }
    }
}