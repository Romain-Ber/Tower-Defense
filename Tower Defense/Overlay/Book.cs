using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tower_Defense
{
    public class Book
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;

        public static bool IsBookOpen;

        private Texture2D bookTexture;
        private Dictionary<int, Rectangle> textureRect;
        private Rectangle sourceRectLeftBottom, sourceRectRightBottom, sourceRectLeftTop, sourceRectRightTop;
        private Vector2 posLeft, posRight;
        private float scale;
        private int frameMax, frameCount;
        private int frameWidth, frameHeight;
        private float frameTimer;

        private Texture2D tabTexture;
        private Dictionary<int, Vector2> tabPos;
        private Dictionary<int, Rectangle> tabSource;
        private float tabFrameTimer, tabIntervalTimer;
        private bool tabDisplayed;

        public static bool bookOpened, bookClosed;
        private bool bookRight, bookLeft;
        public static int bookFlip;

        private MouseState mouseState, mouseStatePrevious;
        private bool previousPressed, nextPressed;
        private Rectangle rectPageLeft, rectPageRight;

        public Book(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
        }

        public void Load()
        {
            bookTexture = _content.Load<Texture2D>("Book/BookTexture");
            tabTexture = _content.Load<Texture2D>("Book/tab");
            scale = 3f;
            frameMax = 14; frameCount = 0;
            frameWidth = bookTexture.Width / frameMax;
            frameHeight = bookTexture.Height;

            posLeft = new Vector2(20, 15);
            posRight = new Vector2(posLeft.X + frameWidth * scale, posLeft.Y);
            rectPageLeft = new Rectangle((int)posLeft.X, (int)posLeft.Y, (int)(frameWidth * scale), (int)(frameHeight * scale));
            rectPageRight = new Rectangle((int)posRight.X, (int)posRight.Y, (int)(frameWidth * scale), (int)(frameHeight * scale));

            textureRect = new Dictionary<int, Rectangle>();
            for(int i = 0; i < frameMax; i++)
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

            for (int i = 0; i < 8; i++)
            {
                tabSource[i] = new Rectangle(0, 0, 0, 0);
            }
            for (int i = 0; i < 8; i++)
            {
                tabPos[i] = new Vector2(1000, i * (78+20) + 200);
            }
            tabDisplayed = false;
        }

        public void Update(GameTime gameTime)
        {
            if (IsBookOpen)
            {
                UpdateBookFrame(gameTime);
                CheckPageAction(gameTime);
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
                Debug.WriteLine($"X = {rectPageLeft.X}, Y = {rectPageLeft.Y}, W {rectPageLeft.Width}, Y = {rectPageLeft.Height}");
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
                BookOpening(100f);
            }
            if (bookOpened && tabDisplayed == false)
            {
                tabFrameTimer += gameTime.ElapsedGameTime.Milliseconds;
                DisplayTabs(16f);
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
                BookClosing(100f);
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
                        bookFlip = 5;
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

        public void DisplayTabs(float frameSpeed)
        {
            if (tabFrameTimer > frameSpeed)
            {

            }
        }

        public void Draw(GameTime gameTime)
        {
            if (IsBookOpen)
            {
                _spriteBatch.Draw(bookTexture, posLeft, sourceRectLeftBottom, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                _spriteBatch.Draw(bookTexture, posRight, sourceRectRightBottom, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                _spriteBatch.Draw(bookTexture, posLeft, sourceRectLeftTop, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                _spriteBatch.Draw(bookTexture, posRight, sourceRectRightTop, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                for (int i = 0; i < 8; i++)
                {
                    _spriteBatch.Draw(tabTexture, tabPos[i], tabSource[i], Color.White);
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
