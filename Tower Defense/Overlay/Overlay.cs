using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tower_Defense
{
    public class Overlay
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private Texture2D overlayTexture;
        private Texture2D buttonsTexture;
        private List<Button> buttonList;
        public static SpriteFont cinzelBoldFont;

        private Book book;

        public static int playerHealth;

        public Overlay(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
        }

        public void Load()
        {
            overlayTexture = _content.Load<Texture2D>("GUI/GUI16");
            buttonsTexture = _content.Load<Texture2D>("GUI/buttons");
            cinzelBoldFont = _content.Load<SpriteFont>("Cinzel-Bold");
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

            book = new Book(_content, _spriteBatch); book.Load();

            playerHealth = 20;
        }
        public void Unload()
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach(var button in buttonList)
            {
                button.Update(gameTime);
            }

            book.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(overlayTexture, new Vector2(0, 0), Color.White);
            foreach(var button in buttonList)
            {
                button.Draw(gameTime, buttonsTexture);
            }

            book.Draw(gameTime);

            //Overlay Text
            int spacing = 20;
            int textX = 1640;
            int textY = 640;

            string playerHealthCountText = $"Health Points: {playerHealth}";
            Vector2 playerHealthCountVector1 = new Vector2(textX, textY);
            _spriteBatch.DrawString(cinzelBoldFont, playerHealthCountText, playerHealthCountVector1, Color.BlanchedAlmond);

            textY += spacing;
            string waveSpeedText;
            if (MainGame.gameSpeedIndex == 0) { waveSpeedText = "Game Speed: PAUSED"; }
            else { waveSpeedText = $"Game Speed: {MainGame.gameSpeedDictionary[MainGame.gameSpeedIndex].ToString()}X"; }
            Vector2 waveSpeedVector1 = new Vector2(textX, textY);
            _spriteBatch.DrawString(cinzelBoldFont, waveSpeedText, waveSpeedVector1, Color.BlanchedAlmond);

            textY += spacing;

            textY += spacing;
            string waveNumberText = "Current Level: 1";
            Vector2 waveNumberVector1 = new Vector2(textX, textY);
            _spriteBatch.DrawString(cinzelBoldFont, waveNumberText, waveNumberVector1, Color.BlanchedAlmond);

            textY += spacing;
            
            string monsterCountText = $"Ennemy Count: {MonsterMain.monsterList.Count}";
            Vector2 monsterCountVector = new Vector2(textX, textY);
            _spriteBatch.DrawString(cinzelBoldFont, monsterCountText, monsterCountVector, Color.BlanchedAlmond);


        }
    }
}
