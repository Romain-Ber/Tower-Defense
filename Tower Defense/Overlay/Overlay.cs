using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Tower_Defense
{
    public class Overlay
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        public Overlay(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
        }
        public void Load()
        {
            _texture = _content.Load<Texture2D>("GUI/GUI16");
        }
        public void Unload()
        {

        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_texture, new Vector2(0, 0), Color.White);
        }
    }
}
