using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;

namespace OneHitObliterator.Content.ZComplex.Menu
{
    public class MenuBackgroundBotW : ModMenu
    {
        public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>("OneHitObliterator/Content/ZComplex/Menu/TitleIcon");

        public override Asset<Texture2D> SunTexture => ModContent.Request<Texture2D>("OneHitObliterator/Content/ZComplex/Menu/Sun");

        public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>("OneHitObliterator/Content/ZComplex/Menu/BloodMoon");

        public override int Music => MusicID.Boss2;

        public override ModSurfaceBackgroundStyle MenuBackgroundStyle => null;

        public override string DisplayName => "Breath of the Wild";
    }
}