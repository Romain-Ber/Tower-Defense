using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tower_Defense
{
    public class ButtonMusic : Button
    {
        public ButtonMusic(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            position = new Vector2(1722, 104);
            bounds = new Rectangle((int)position.X, (int)position.Y, buttonWidth, buttonHeight);
            sourceRect = new Rectangle(256, 128, 64, 64);
            sourceRectPressed = new Rectangle(sourceRect.X, sourceRect.Y + buttonHeight, sourceRect.Width, sourceRect.Height);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, Texture2D textureSet)
        {
            base.Draw(gameTime, textureSet);
        }
    }
}
