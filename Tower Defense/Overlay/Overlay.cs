using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Tower_Defense
{
    public class Overlay
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private MouseState mouseState;

        private Texture2D overlayTexture;

        private Texture2D buttonsTexture;
        //private ButtonOptions buttonOptions;
        private ButtonSettings buttonSettings;

        private ButtonMusic buttonMusic;
        private ButtonSound buttonSound;
        private ButtonBook buttonBook;
        private ButtonMoney buttonMoney;
        private ButtonUndo buttonUndo;
        private ButtonSlower buttonSlower;
        private ButtonPause buttonPause;
        private ButtonFaster buttonFaster;

        public Overlay(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
        }

        public void Load()
        {
            overlayTexture = _content.Load<Texture2D>("GUI/GUI16");

            buttonsTexture = _content.Load<Texture2D>("GUI/buttons");

            //buttonOptions = new ButtonOptions(_spriteBatch, buttonsTexture);
            buttonMusic = new ButtonMusic(_spriteBatch, buttonsTexture);
            buttonSound = new ButtonSound(_spriteBatch, buttonsTexture);
            buttonBook = new ButtonBook(_spriteBatch, buttonsTexture);
            buttonMoney = new ButtonMoney(_spriteBatch, buttonsTexture);
            buttonUndo = new ButtonUndo(_spriteBatch, buttonsTexture);
            buttonSlower = new ButtonSlower(_spriteBatch, buttonsTexture);
            buttonPause = new ButtonPause(_spriteBatch, buttonsTexture);
            buttonFaster = new ButtonFaster(_spriteBatch, buttonsTexture);

            buttonSettings = new ButtonSettings(_spriteBatch, new Vector2(1655, 104), new Rectangle(0, 128, 64, 64));
            
        }
        public void Unload()
        {

        }

        public void Update(GameTime gameTime)
        {
            mouseState = new MouseState();
            buttonSettings.Update(gameTime, mouseState);
        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(overlayTexture, new Vector2(0, 0), Color.White);

            //buttonOptions.Draw(gameTime);
            buttonMusic.Draw(gameTime);
            buttonSound.Draw(gameTime);
            buttonBook.Draw(gameTime);
            buttonMoney.Draw(gameTime);
            buttonUndo.Draw(gameTime);
            buttonSlower.Draw(gameTime);
            buttonPause.Draw(gameTime);
            buttonFaster.Draw(gameTime);

            buttonSettings.Draw(gameTime, buttonsTexture);
        }
    }
}
