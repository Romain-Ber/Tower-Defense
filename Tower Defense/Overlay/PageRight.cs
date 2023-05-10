using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tower_Defense
{
    public class PageRight
    {
        private SpriteBatch _spriteBatch;
        private string monsterName;

        private Vector2 pagePos;
        private Rectangle pageSource;
        private float pageScale;

        private Texture2D _monsterTexture;
        private Rectangle monsterSource;
        private SpriteEffects frameFlip;
        private int monsterWidth, monsterHeight, frameMax, frameOffsetX, frameOffsetY, frameRow, frameCurrent;
        private Vector2 monsterPos;

        private float frameTimer, frameSpeed;

        private Rectangle pageBounds;
        private bool pagePressed;
        private MouseState mouseState, mouseStatePrevious;

        public PageRight(SpriteBatch spriteBatch, string monsterName)
        {
            _spriteBatch = spriteBatch;
            this.monsterName = monsterName;

            _monsterTexture = MonsterMain.monsterTexture[monsterName];

            monsterWidth = (int)Database.monsterDictionary[monsterName]["monsterWidth"];
            monsterHeight = (int)Database.monsterDictionary[monsterName]["monsterHeight"];
            frameMax = (int)Database.monsterDictionary[monsterName]["frameMax"];
            frameOffsetX = (int)Database.monsterDictionary[monsterName]["frameOffsetX"];
            frameOffsetY = (int)Database.monsterDictionary[monsterName]["frameOffsetY"];
            frameSpeed = Database.monsterDictionary[monsterName]["frameSpeed"];

            frameTimer = 0;
            frameCurrent = 0;

            frameRow = 5;
            if (monsterName == "Clampbeetle" || monsterName == "MagmaCrab" || monsterName == "Scorpion") frameFlip = SpriteEffects.FlipHorizontally; else frameFlip = SpriteEffects.None;
            monsterSource = new Rectangle(frameCurrent * monsterWidth + (frameCurrent * 2 + 1) * frameOffsetX,
                                       frameRow * monsterHeight + (frameRow * 2 + 1) * frameOffsetY,
                                       monsterWidth,
                                       monsterHeight);

        }

        public void Update(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime.Milliseconds;
            UpdateMonsterFrame();
            BoundCheck();
        }

        public void UpdateMonsterFrame()
        {
            if (frameTimer > frameSpeed)
            {
                if (frameCurrent + 1 >= frameMax)
                {
                    frameCurrent = 0;
                }
                else
                {
                    frameCurrent += 1;
                }
                frameTimer = 0;
            }
            monsterSource = new Rectangle(frameCurrent * monsterWidth + (frameCurrent * 2 + 1) * frameOffsetX,
                                       frameRow * monsterHeight + (frameRow * 2 + 1) * frameOffsetY,
                                       monsterWidth,
                                       monsterHeight);
        }

        public void BoundCheck()
        {
            mouseState = Mouse.GetState();
            if (pageBounds.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && mouseStatePrevious.LeftButton == ButtonState.Released)
            {
                pagePressed = true;
            }
            if (pageBounds.Contains(mouseState.Position) && pagePressed && mouseState.LeftButton == ButtonState.Released)
            {
                OnClick();
                frameTimer = 0;
                pagePressed = false;
            }
            else if (pagePressed && mouseState.LeftButton == ButtonState.Released)
            {
                pagePressed = false;
            }
            mouseStatePrevious = mouseState;
        }

        public void OnClick()
        {

        }

        public void Draw(GameTime gameTime)
        {
            //_spriteBatch.Draw(titleTextures, tabPos, tabSource, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            //_spriteBatch.Draw(titleTextures, iconPos, iconSource, Color.White, 0f, Vector2.Zero, iconScale, SpriteEffects.None, 0f);

            _spriteBatch.Draw(Book.bookTexture, pagePos, pageSource, Color.White, 0f, Vector2.Zero, pageScale, SpriteEffects.None, 0f);
            _spriteBatch.Draw(_monsterTexture, monsterPos, monsterSource, Color.White, 0f, Vector2.Zero, 1f, frameFlip, 0f);
        }
    }
}
