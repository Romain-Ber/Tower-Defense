using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class ButtonSlower
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _textureSet;
        private Rectangle sourceRect, destRect;
        public ButtonSlower(SpriteBatch spriteBatch, Texture2D textureSet)
        {
            _spriteBatch = spriteBatch;
            _textureSet = textureSet;
            sourceRect = new Rectangle(192, 256, 64, 64);
            destRect = new Rectangle(1655, 464, 64, 64);
        }

        public void Load()
        {

        }

        public void Unload()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void OnButtonClick()
        {

        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_textureSet, destRect, sourceRect, Color.White);
        }
    }
}
