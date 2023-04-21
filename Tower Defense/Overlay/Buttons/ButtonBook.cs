using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class ButtonBook : Button
    {
        public ButtonBook(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            position = new Vector2(1655, 284);
            bounds = new Rectangle((int)position.X, (int)position.Y, buttonWidth, buttonHeight);
            sourceRect = new Rectangle(64, 256, 64, 64);
            sourceRectPressed = new Rectangle(sourceRect.X, sourceRect.Y + buttonHeight, sourceRect.Width, sourceRect.Height);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void OnClick()
        {
            if (Book.IsBookOpen == false)
            {
                Book.bookOpened = false; Book.bookClosed = false;
                Book.IsBookOpen = true;
            }
            else if (Book.IsBookOpen == true && Book.bookClosed == false && Book.bookFlip == 0)
            {
                Book.bookFlip = 3;
                Book.bookClosed = true;
            }
        }

        public override void Draw(GameTime gameTime, Texture2D textureSet)
        {
            base.Draw(gameTime, textureSet);
        }
    }
}
