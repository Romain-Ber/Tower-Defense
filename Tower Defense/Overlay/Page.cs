using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class Page
    {
        private SpriteBatch _spriteBatch;
        private Texture2D titleTextures, showcaseBorderTexture, showcaseTextures, statTexture, statMiscTextures, descTexture;
        private int pageNumber;

        private int tabFrames, tabWidth, tabHeight;

        private Vector2 tabPos, iconPos;
        private Vector2 iconScale;
        private Rectangle tabSource, iconSource, tabBounds;
        private float frameTimer, frameSpeed;
        private int frameCount;

        private MouseState mouseState, mouseStatePrevious;
        private bool tabPressed;

        public Page(SpriteBatch spriteBatch, Texture2D titleTextures, int pageNumber)
        {
            _spriteBatch = spriteBatch;
            this.titleTextures = titleTextures;
            this.pageNumber = pageNumber;

            tabFrames = 4; frameCount = 0;
            tabWidth = titleTextures.Width / tabFrames;
            tabHeight = titleTextures.Height;
            tabSource = new Rectangle(0, 0, 0, 0);
            iconSource = new Rectangle(0, 0, 0, 0);
            tabPos = new Vector2(1497, pageNumber * (78 + 17) + 168);
            iconPos = new Vector2(tabPos.X + 12, tabPos.Y + 8);
            tabBounds = new Rectangle((int)tabPos.X, (int)tabPos.Y, tabWidth, tabHeight);

            frameSpeed = 50f;
            switch (pageNumber)
            {
                case 0:
                    titleTextures = MonsterMain.monsterTexture["Leafbug"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 1:
                    titleTextures = MonsterMain.monsterTexture["Firebug"];
                    iconSource = new Rectangle(32, 0, 64, 64);
                    break;
                case 2:
                    titleTextures = MonsterMain.monsterTexture["FlyingLocust"];
                    iconSource = new Rectangle(64, 384, 64, 64);
                    break;
                case 3:
                    titleTextures = MonsterMain.monsterTexture["Firewasp"];
                    iconSource = new Rectangle(16, 16, 64, 64);
                    break;
                case 4:
                    titleTextures = MonsterMain.monsterTexture["MagmaCrab"];
                    iconSource = new Rectangle(0, 0, 64, 64);
                    break;
                case 5:
                    titleTextures = MonsterMain.monsterTexture["Clampbeetle"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 6:
                    titleTextures = MonsterMain.monsterTexture["Scorpion"];
                    iconSource = new Rectangle(0, 128, 64, 64);
                    break;
                case 7:
                    titleTextures = MonsterMain.monsterTexture["Voidbutterfly"];
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
            if (frameTimer > frameSpeed)
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
            _spriteBatch.Draw(titleTextures, tabPos, tabSource, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            _spriteBatch.Draw(titleTextures, iconPos, iconSource, Color.White, 0f, Vector2.Zero, iconScale, SpriteEffects.None, 0f);
        }
    }
}
