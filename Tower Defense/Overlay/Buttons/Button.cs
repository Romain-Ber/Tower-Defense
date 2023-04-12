using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Tower_Defense
{
    public abstract class Button
    {
        private SpriteBatch _spriteBatch;
        private MouseState mouseState, mouseStatePrevious;
        protected Vector2 position;
        protected Rectangle bounds;
        protected int buttonWidth, buttonHeight;
        protected Rectangle sourceRect, sourceRectPressed;
        protected bool buttonPressed;

        public Button(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            buttonWidth = 64;
            buttonHeight = 64;
            buttonPressed = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (bounds.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && mouseStatePrevious.LeftButton == ButtonState.Released)
            {
                buttonPressed = true;
            }
            if (buttonPressed && mouseState.LeftButton == ButtonState.Released)
            {
                buttonPressed = false;
            }
            mouseStatePrevious = mouseState;
        }

        public virtual void Draw(GameTime gameTime, Texture2D textureSet)
        {
            if (buttonPressed)
            {
                _spriteBatch.Draw(textureSet, bounds, sourceRectPressed, Color.White);
            }
            else
            {
                _spriteBatch.Draw(textureSet, bounds, sourceRect, Color.White);
            }
        }
    }
}
