using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tower_Defense
{
    public class ButtonMusic
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _textureSet;
        private Rectangle sourceRect, destRect;
        public ButtonMusic(SpriteBatch spriteBatch, Texture2D textureSet)
        {
            _spriteBatch = spriteBatch;
            _textureSet = textureSet;
            sourceRect = new Rectangle(256, 128, 64, 64);
            destRect = new Rectangle(1722, 104, 64, 64);
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
