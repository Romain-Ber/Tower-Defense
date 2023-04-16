using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class ButtonPause : Button
    {
        private bool IsPaused;
        private int lastIndex;
        public ButtonPause(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            position = new Vector2(1722, 464);
            bounds = new Rectangle((int)position.X, (int)position.Y, buttonWidth, buttonHeight);
            sourceRect = new Rectangle(256, 256, 64, 64);
            //sourceRect2 = new Rectangle(64, 0, 64, 64);
            sourceRectPressed = new Rectangle(sourceRect.X, sourceRect.Y + buttonHeight, sourceRect.Width, sourceRect.Height);
            IsPaused = false;
            lastIndex = MainGame.gameSpeedIndex;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void OnClick()
        {
            if (IsPaused)
            {
                MainGame.gameSpeedIndex = lastIndex;
                sourceRect = new Rectangle(256, 256, 64, 64);
                sourceRectPressed = new Rectangle(sourceRect.X, sourceRect.Y + buttonHeight, sourceRect.Width, sourceRect.Height);
            }
            else
            {
                lastIndex = MainGame.gameSpeedIndex;
                MainGame.gameSpeedIndex = 0;
                sourceRect = new Rectangle(64, 0, 64, 64);
                sourceRectPressed = new Rectangle(sourceRect.X, sourceRect.Y + buttonHeight, sourceRect.Width, sourceRect.Height);
            }
            IsPaused = !IsPaused;
        }

        public override void Draw(GameTime gameTime, Texture2D textureSet)
        {
            base.Draw(gameTime, textureSet);
        }
    }
}
