using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Tower_Defense
{
    public class Overlay
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private Texture2D overlayTexture;
        private Texture2D buttonsTexture;
        private List<Button> buttonList;

        public Overlay(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
        }

        public void Load()
        {
            overlayTexture = _content.Load<Texture2D>("GUI/GUI16");
            buttonsTexture = _content.Load<Texture2D>("GUI/buttons");
            //buttonSettings = new ButtonSettings(_spriteBatch);
            buttonList = new List<Button>
            {
                new ButtonBook(_spriteBatch),
                new ButtonFaster(_spriteBatch),
                new ButtonMoney(_spriteBatch),
                new ButtonMusic(_spriteBatch),
                new ButtonPause(_spriteBatch),
                new ButtonSettings(_spriteBatch),
                new ButtonSlower(_spriteBatch),
                new ButtonSound(_spriteBatch),
                new ButtonUndo(_spriteBatch)
            };


        }
        public void Unload()
        {

        }

        public void Update(GameTime gameTime)
        {
            //buttonSettings.Update(gameTime);
            foreach(var button in buttonList)
            {
                button.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(overlayTexture, new Vector2(0, 0), Color.White);
            //buttonSettings.Draw(gameTime, buttonsTexture);
            foreach(var button in buttonList)
            {
                button.Draw(gameTime, buttonsTexture);
            }
        }
    }
}
