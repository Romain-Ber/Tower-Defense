using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private Rectangle tabSource, iconSource;
        private float frameTimer, frameSpeed;
        private int frameCount;

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

            frameSpeed = 50f;

            switch (tabNumber)
            {
                case 0:
                    iconTexture = MonsterMain.monsterTexture["Leafbug"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 1:
                    iconTexture = MonsterMain.monsterTexture["Clampbeetle"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 2:
                    iconTexture = MonsterMain.monsterTexture["FlyingLocust"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 3:
                    iconTexture = MonsterMain.monsterTexture["MagmaCrab"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 4:
                    iconTexture = MonsterMain.monsterTexture["Scorpion"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 5:
                    iconTexture = MonsterMain.monsterTexture["Voidbutterfly"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 6:
                    iconTexture = MonsterMain.monsterTexture["Firebug"];
                    iconSource = new Rectangle(32, 0, 64, 64);
                    break;
                case 7:
                    iconTexture = MonsterMain.monsterTexture["Firewasp"];
                    iconSource = new Rectangle(16, 16, 64, 64);
                    break;
                default:
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime.Milliseconds;
            UpdateFrame();
        }

        public void UpdateFrame()
        {
            if(frameTimer > frameSpeed)
            {
                //if (frameCount < tabFrames)
                //{
                //    tabSource = new Rectangle(frameCount * tabWidth, 0, tabWidth, tabHeight);
                //    frameCount++;
                //    frameTimer = 0;
                //}
                switch (frameCount)
                {
                    case 0:
                        tabSource = new Rectangle(frameCount * tabWidth, 0, tabWidth, tabHeight);
                        frameCount++;
                        frameTimer = 0;
                        break;
                    case 1:
                        tabSource = new Rectangle(frameCount * tabWidth, 0, tabWidth, tabHeight);
                        frameCount++;
                        frameTimer = 0;
                        break;
                    case 2:
                        tabSource = new Rectangle(frameCount * tabWidth, 0, tabWidth, tabHeight);
                        frameCount++;
                        frameTimer = 0;
                        break;
                    case 3:
                        tabSource = new Rectangle(frameCount * tabWidth, 0, tabWidth, tabHeight);
                        frameCount++;
                        frameTimer = 0;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(tabTexture, tabPos, tabSource, Color.White);
            _spriteBatch.Draw(iconTexture, iconPos, iconSource, Color.White);
        }
    }
}
