﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class Tab
    {
        private SpriteBatch _spriteBatch;
        private Texture2D tabTexture, iconTexture;
        private int tabNumber;

        private int tabFrames, tabWidth, tabHeight;

        private Vector2 tabPos, iconPos;
        private Vector2 iconScale;
        private Rectangle tabSource, iconSource, tabBounds;
        private float frameTimer, frameSpeed;
        private int frameCount;

        private MouseState mouseState, mouseStatePrevious;
        private bool tabPressed;

        public Tab(SpriteBatch spriteBatch, Texture2D tabTexture, int tabNumber)
        { 
            _spriteBatch = spriteBatch;
            this.tabTexture = tabTexture;
            this.tabNumber = tabNumber;

            tabFrames = 4; frameCount = 0;
            tabWidth = tabTexture.Width / tabFrames;
            tabHeight = tabTexture.Height;
            tabSource = new Rectangle(0, 0, 0, 0);
            iconSource = new Rectangle(0, 0, 0, 0);
            tabPos = new Vector2(1497, tabNumber * (78 + 17) + 168);
            iconPos = new Vector2(tabPos.X + 12, tabPos.Y + 8);
            tabBounds = new Rectangle((int)tabPos.X, (int)tabPos.Y, tabWidth, tabHeight);
            frameSpeed = 50f;
            switch (tabNumber)
            {
                case 0:
                    iconTexture = MonsterMain.monsterTexture["Leafbug"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 1:
                    iconTexture = MonsterMain.monsterTexture["Firebug"];
                    iconSource = new Rectangle(32, 0, 64, 64);
                    break;
                case 2:
                    iconTexture = MonsterMain.monsterTexture["FlyingLocust"];
                    iconSource = new Rectangle(64, 384, 64, 64);
                    break;
                case 3:
                    iconTexture = MonsterMain.monsterTexture["Firewasp"];
                    iconSource = new Rectangle(16, 16, 64, 64);
                    break;
                case 4:
                    iconTexture = MonsterMain.monsterTexture["MagmaCrab"];
                    iconSource = new Rectangle(0, 0, 64, 64);
                    break;
                case 5:
                    iconTexture = MonsterMain.monsterTexture["Clampbeetle"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 6:
                    iconTexture = MonsterMain.monsterTexture["Scorpion"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 7:
                    iconTexture = MonsterMain.monsterTexture["Voidbutterfly"];
                    iconSource = new Rectangle(0, 0, 64, 64);
                    break;
                default:
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime.Milliseconds;
            UpdateFrame();
            BoundCheck();
        }

        public void UpdateFrame()
        {
            if(frameTimer > frameSpeed)
            {
                switch (frameCount)
                {
                    case 0:
                        tabSource = new Rectangle(frameCount * tabWidth, 0, tabWidth, tabHeight);
                        iconScale = new Vector2(0.1f, 1f);
                        iconPos = new Vector2(tabPos.X + 12, tabPos.Y + 8);
                        frameCount++;
                        frameTimer = 0;
                        break;
                    case 1:
                        tabSource = new Rectangle(frameCount * tabWidth, 0, tabWidth, tabHeight);
                        iconScale = new Vector2(0.3f, 1f);
                        iconPos = new Vector2(tabPos.X + 12, tabPos.Y + 8);
                        frameCount++;
                        frameTimer = 0;
                        break;
                    case 2:
                        tabSource = new Rectangle(frameCount * tabWidth, 0, tabWidth, tabHeight);
                        iconScale = new Vector2(0.7f, 1f);
                        iconPos = new Vector2(tabPos.X + 12, tabPos.Y + 8);
                        frameCount++;
                        frameTimer = 0;
                        break;
                    case 3:
                        tabSource = new Rectangle(frameCount * tabWidth, 0, tabWidth, tabHeight);
                        iconScale = new Vector2(1f, 1f);
                        iconPos = new Vector2(tabPos.X + 12, tabPos.Y + 8);
                        frameCount++;
                        frameTimer = 0;
                        break;
                    default:
                        break;
                }
            }
        }

        public void BoundCheck()
        {
            mouseState = Mouse.GetState();
            if (tabBounds.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && mouseStatePrevious.LeftButton == ButtonState.Released)
            {
                tabPressed = true;
            }
            if (tabBounds.Contains(mouseState.Position) && tabPressed && mouseState.LeftButton == ButtonState.Released)
            {
                OnClick();
                frameTimer = 0;
                tabPressed = false;
            }
            else if (tabPressed && mouseState.LeftButton == ButtonState.Released)
            {
                tabPressed = false;
            }
            mouseStatePrevious = mouseState;
        }

        public void OnClick()
        {

        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(tabTexture, tabPos, tabSource, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            _spriteBatch.Draw(iconTexture, iconPos, iconSource, Color.White, 0f, Vector2.Zero, iconScale, SpriteEffects.None, 0f);
        }
    }
}
