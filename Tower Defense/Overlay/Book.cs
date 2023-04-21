using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class Book
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;

        public static bool IsBookOpen;

        private Texture2D bookTexture, tabTexture, titleTextures, showcaseBorderTexture, showcaseTextures, statTexture, statMisc, descTexture;
        private Dictionary<int, Rectangle> textureRect;
        private Rectangle sourceRectLeftBottom, sourceRectRightBottom, sourceRectLeftTop, sourceRectRightTop;
        private Vector2 posLeft, posRight;
        private float scale;
        private int frameMax, frameCount;
        private int frameWidth, frameHeight;
        private float frameTimer;

        private List<Tab> tabList;
        private int tabNumber;
        private bool creatingTabs;
        private float tabTimer, tabTimerInterval;

        public static bool bookOpened, bookClosed;
        private bool bookRight, bookLeft;
        public static int bookFlip;

        private MouseState mouseState, mouseStatePrevious;
        private bool previousPressed, nextPressed;
        private Rectangle rectPageLeft, rectPageRight;

        private Dictionary<int, string> pageContentLeft, pageContentRight;
        private Vector2 pagePosLeft, pagePosRight;

        public Book(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
        }

        public void Load()
        {
            bookTexture = _content.Load<Texture2D>("Book/BookTextures");
            tabTexture = _content.Load<Texture2D>("Book/tab");
            titleTextures = _content.Load<Texture2D>("Book/titleTextures");
            showcaseBorderTexture = _content.Load<Texture2D>("Book/showcaseBorderTexture");
            showcaseTextures = _content.Load<Texture2D>("Book/showcaseTextures");
            statTexture = _content.Load<Texture2D>("Book/statTexture");
            statMisc = _content.Load<Texture2D>("Book/statMisc");
            descTexture = _content.Load<Texture2D>("Book/descTexture");


            scale = 3f;
            frameMax = 14; frameCount = 0;
            frameWidth = bookTexture.Width / frameMax;
            frameHeight = bookTexture.Height;

            posLeft = new Vector2(20, 15);
            posRight = new Vector2(posLeft.X + frameWidth * scale, posLeft.Y);
            rectPageLeft = new Rectangle((int)posLeft.X, (int)posLeft.Y, (int)(frameWidth * scale), (int)(frameHeight * scale));
            rectPageRight = new Rectangle((int)posRight.X, (int)posRight.Y, (int)(frameWidth * scale), (int)(frameHeight * scale));

            pagePosLeft = new Vector2(rectPageLeft.X + 50, rectPageLeft.Y + 210);
            pagePosRight = new Vector2(rectPageRight.X + 50, rectPageRight.Y + 210);

            textureRect = new Dictionary<int, Rectangle>();
            for (int i = 0; i < frameMax; i++)
            {
                textureRect[i] = new Rectangle(i * frameWidth, 0, frameWidth, frameHeight);
            }
            textureRect.Add(14, new Rectangle(0, 0, 0, 0)); //transparent rect

            sourceRectLeftBottom = textureRect[14];
            sourceRectLeftTop = textureRect[14];
            sourceRectRightBottom = textureRect[14];
            sourceRectRightTop = textureRect[14];

            bookOpened = false; bookClosed = false; bookRight = false; bookLeft = false;
            bookFlip = 0;
            frameTimer = 0;
            frameCount = 0;

            IsBookOpen = false;

            tabList = new List<Tab>();
            tabNumber = 0;
            tabTimer = 0; tabTimerInterval = 100f;
        }

        public void Update(GameTime gameTime)
        {
            if (IsBookOpen)
            {
                UpdateBookFrame(gameTime);
                CheckPageAction(gameTime);
                PageContent();
                foreach (Tab tab in tabList)
                {
                    tab.Update(gameTime);
                }

            }
        }

        public void CheckPageAction(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            /////
            if (rectPageLeft.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && mouseStatePrevious.LeftButton == ButtonState.Released)
            {
                previousPressed = true;
            }
            if (rectPageLeft.Contains(mouseState.Position) && previousPressed && mouseState.LeftButton == ButtonState.Released)
            {
                frameTimer = 0;
                bookLeft = true;
                previousPressed = false;
            }
            else if (previousPressed && mouseState.LeftButton == ButtonState.Released)
            {
                previousPressed = false;
            }
            ///////
            if (rectPageRight.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && mouseStatePrevious.LeftButton == ButtonState.Released)
            {
                nextPressed = true;
            }
            if (rectPageRight.Contains(mouseState.Position) && nextPressed && mouseState.LeftButton == ButtonState.Released)
            {
                frameTimer = 0;
                bookRight = true;
                nextPressed = false;
            }
            else if (nextPressed && mouseState.LeftButton == ButtonState.Released)
            {
                nextPressed = false;
            }
            /////
            mouseStatePrevious = mouseState;
        }

        public void UpdateBookFrame(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (bookOpened == false)
            {
                BookOpening(80f);
            }
            if (creatingTabs)
            {
                tabTimer += gameTime.ElapsedGameTime.Milliseconds;
                CreateTabs();
            }
            if (bookFlip > 0)
            {
                PageForward(16f);
            }
            if (bookFlip < 0)
            {
                PageBackward(16f);
            }
            if (bookLeft)
            {
                PageBackward(50f);
            }
            if (bookRight)
            {
                PageForward(50f);
            }
            if (bookClosed && bookFlip == 0)
            {
                BookClosing(80f);
            }
        }

        public void BookOpening(float frameSpeed)
        {
            if (frameTimer > frameSpeed)
            {
                switch (frameCount)
                {
                    case 0:
                        sourceRectLeftBottom = textureRect[14];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[14];
                        sourceRectRightTop = textureRect[0];
                        break;
                    case 1:
                        sourceRectLeftBottom = textureRect[14];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[14];
                        sourceRectRightTop = textureRect[1];
                        break;
                    case 2:
                        sourceRectLeftBottom = textureRect[14];
                        sourceRectLeftTop = textureRect[2];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[3];
                        break;
                    case 3:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[14];

                        bookOpened = true;
                        frameCount = -1;
                        bookFlip = 3;
                        creatingTabs = true;

                        break;
                    default:
                        break;
                }
                frameCount++;
                frameTimer = 0;

            }
        }

        public void BookClosing(float frameSpeed)
        {
            if (frameTimer > frameSpeed)
            {
                switch (frameCount)
                {
                    case 0:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[11];
                        sourceRectRightTop = textureRect[14];

                        tabList.Clear();

                        break;
                    case 1:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[12];
                        sourceRectRightBottom = textureRect[14];
                        sourceRectRightTop = textureRect[14];
                        break;
                    case 2:
                        sourceRectLeftBottom = textureRect[13];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[14];
                        sourceRectRightTop = textureRect[14];
                        break;
                    case 3:
                        sourceRectLeftBottom = textureRect[14];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[14];
                        sourceRectRightTop = textureRect[14];

                        bookOpened = false;
                        IsBookOpen = false;
                        frameCount = -1;
                        bookFlip = 0;
                        tabNumber = 0;

                        break;
                    default:
                        break;
                }
                frameCount++;
                frameTimer = 0;
            }
        }

        public void PageForward(float frameSpeed)
        {
            if (frameTimer > frameSpeed)
            {
                switch (frameCount)
                {
                    case 0:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[4];
                        break;
                    case 1:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[5];
                        break;
                    case 2:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[6];
                        break;
                    case 3:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[7];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[14];
                        break;
                    case 4:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[8];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[14];
                        break;
                    case 5:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[9];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[14];
                        break;
                    case 6:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[14];
                        frameCount = -1;
                        bookRight = false;
                        if (bookFlip > 0) bookFlip--;

                        break;
                    default:
                        break;
                }
                frameCount++;
                frameTimer = 0;
            }
        }

        public void PageBackward(float frameSpeed)
        {
            if (frameTimer > frameSpeed)
            {
                switch (frameCount)
                {
                    case 0:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[9];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[14];
                        break;
                    case 1:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[8];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[14];
                        break;
                    case 2:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[7];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[14];
                        break;
                    case 3:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[6];
                        break;
                    case 4:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[5];
                        break;
                    case 5:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[4];
                        break;
                    case 6:
                        sourceRectLeftBottom = textureRect[10];
                        sourceRectLeftTop = textureRect[14];
                        sourceRectRightBottom = textureRect[3];
                        sourceRectRightTop = textureRect[14];
                        frameCount = -1;
                        bookLeft = false;
                        if (bookFlip < 0) bookFlip++;
                        break;
                    default:
                        break;
                }
                frameCount++;
                frameTimer = 0;
            }
        }

        public void PageContent()
        {
            if (sourceRectLeftBottom == textureRect[10])
            {
                pageContentLeft = Lexicon.lexiconContent["Summary"];
            }
            else
            {
                pageContentLeft = Lexicon.lexiconContent["Void"];
            }

            if (sourceRectRightBottom == textureRect[3])
            {
                pageContentRight = Lexicon.lexiconContent["Summary"];
            }
            else
            {
                pageContentRight = Lexicon.lexiconContent["Void"];
            }
        }

        public void CreateTabs()
        {
            if (tabTimer > tabTimerInterval && tabNumber < 8)
            {
                tabList.Add(new Tab(_spriteBatch, tabTexture, tabNumber));
                tabNumber++;
                tabTimer = 0;
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (IsBookOpen)
            {
                _spriteBatch.Draw(bookTexture, posLeft, sourceRectLeftBottom, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                _spriteBatch.Draw(bookTexture, posRight, sourceRectRightBottom, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                for (int i = 0; i< Lexicon.lexiconContent["Summary"].Count; i++)
                {
                    _spriteBatch.DrawString(Overlay.cinzelBoldFont, pageContentLeft[i], new Vector2(pagePosLeft.X, pagePosLeft.Y + 20 * i), Color.Gold);
                }
                for (int i = 0; i < Lexicon.lexiconContent["Summary"].Count; i++)
                {
                    _spriteBatch.DrawString(Overlay.cinzelBoldFont, pageContentRight[i], new Vector2(pagePosRight.X, pagePosRight.Y + 20 * i), Color.SaddleBrown);
                }

                _spriteBatch.Draw(bookTexture, posLeft, sourceRectLeftTop, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                _spriteBatch.Draw(bookTexture, posRight, sourceRectRightTop, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                foreach (Tab tab in tabList)
                {
                    tab.Draw(gameTime);
                }




                //colorTimer += gameTime.ElapsedGameTime.Milliseconds;
                //Color currentColor = Color.Lerp(startColor, endColor, colorTimer / colorTimerMax);

                //string dataText = "                                                LEXICON";
                //Vector2 dataVector = new Vector2(posLeft.X + (int)(frameWidth / 2), posLeft.Y + 100);
                //_spriteBatch.DrawString(Overlay.cinzelBoldFont, dataText, dataVector, currentColor);




                /////
                /////conceive a function that draws a layer containing text as a background so the second layer gives a better effect
            }
        }


    }
}
