using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class ButtonSettings: Button
    {
        public ButtonSettings(SpriteBatch spriteBatch, Vector2 position, Rectangle sourceRect) : base(spriteBatch, position, sourceRect)
        {

        }
        public override void Update(GameTime gameTime, MouseState mouseState)
        {
            base.Update(gameTime, mouseState);
        }

        public virtual void Draw(GameTime gameTime, Texture2D textureSet)
        {
            base.Draw(gameTime, textureSet);
        }
    }

}
