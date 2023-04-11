using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public abstract class Button
    {
        private SpriteBatch _spriteBatch;
        private MouseState lastMouseState;
        private Vector2 position;
        private Rectangle bounds;
        private int buttonWidth, buttonHeight;
        private Rectangle sourceRect, sourceRectPressed;
        private bool buttonPressed;

        public Button(SpriteBatch spriteBatch, Vector2 position, Rectangle sourceRect)
        {
            _spriteBatch = spriteBatch;
            buttonWidth = 64;
            buttonHeight = 64;
            this.position = position;
            this.sourceRect = sourceRect;
            this.sourceRectPressed = new Rectangle(sourceRect.X, sourceRect.Y + buttonHeight, sourceRect.Width, sourceRect.Height);
            this.bounds = new Rectangle((int)position.X, (int)position.Y, buttonWidth, buttonHeight);
            this.buttonPressed = false;
        }

        public virtual void Update(GameTime gameTime, MouseState mouseState)
        {
            if (bounds.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
            {
                buttonPressed = true;
            }
            else
            {
                buttonPressed = false;
            }
            lastMouseState = mouseState;
        }

        public virtual void Draw(GameTime gameTime, Texture2D textureSet)
        {
            if (buttonPressed)
            {
                _spriteBatch.Draw(textureSet, sourceRectPressed, bounds, Color.White);
            }
            else
            {
                _spriteBatch.Draw(textureSet, sourceRect, bounds, Color.White);
            }
        }
    }
}
