using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent;
using ReLogic.Content;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneHitObliterator.Content.Frostspear
{
	internal class FrostspearThrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thrown Frostspear");
		}

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.width = 14;
			Projectile.height = 50;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;

			Projectile.aiStyle = ProjAIStyleID.Arrow;
			AIType = ProjectileID.WoodenArrowFriendly;

			DrawOffsetX = -6;
			DrawOriginOffsetY = -6;
		}
	}
}