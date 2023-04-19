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
        private int frameMax;
        public static int frameStart, frameEnd, frameCount;
        private int frameWidth, frameHeight;
        private float frameTimer;

        public static bool bookOpened, bookClosed;
        private int bookFlipOpen, bookFlipClose;

        private Rectangle rectLeftTop, rectRightTop;
        private MouseState mouseState, mouseStatePrevious;
        private bool previousPressed, nextPressed;

        private Color startColor, endColor;
        private float colorTimer, colorTimerMax, currentColor;

        public Book(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
        }

        public void Load()
        {
            bookTexture = _content.Load<Texture2D>("Book/BookTexture");
            scale = 3f;
            frameMax = 14; frameCount = 0;
            frameWidth = bookTexture.Width / frameMax;
            frameHeight = bookTexture.Height;

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

            bookOpened = false; bookClosed = false;
            bookFlipOpen = 5; bookFlipClose = 5;

            posLeft = new Vector2(75, 15);
            posRight = new Vector2(75 + frameWidth * scale, 15);

            frameStart = 0; frameEnd = 2;
            frameTimer = 0;
            frameCount = 0;

            IsBookOpen = false;

            //Debug.WriteLine($"posLeft.X = {posLeft.X}, posLeft.Y = {posLeft.Y}, posRight.X = {posRight.X}, posRight.Y = {posRight.Y}");

            rectLeftTop = new Rectangle((int)posLeft.X, (int)posLeft.Y, frameWidth / 2, frameHeight);
            rectRightTop = new Rectangle((int)posLeft.X + frameWidth / 2, (int)posLeft.Y, frameWidth / 2, frameHeight);
        }

        public void Update(GameTime gameTime)
        {
            if (IsBookOpen)
            {
                UpdateBook(gameTime);
            }
            else
            {
                //startColor = Color.DarkGoldenrod; endColor = Color.Transparent;
                //colorTimer = 0; colorTimerMax = 10f;
            }
        }

        public void UpdateBook(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime.Milliseconds;

            //mouseState = Mouse.GetState();
            ///////
            //if (rectLeftTop.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && mouseStatePrevious.LeftButton == ButtonState.Released)
            //{
            //    previousPressed = true;
            //}
            //if (rectLeftTop.Contains(mouseState.Position) && previousPressed && mouseState.LeftButton == ButtonState.Released)
            //{
            //    frameStart = 6; frameEnd = 0;
            //    frameCurrent = frameStart;
            //    frameTimer = 0;
            //    previousPressed = false;
            //    //startColor = Color.DarkGoldenrod; endColor = Color.Transparent;
            //    //colorTimer = 0; colorTimerMax = 350f;
            //}
            //else if (previousPressed && mouseState.LeftButton == ButtonState.Released)
            //{
            //    previousPressed = false;
            //}
            /////////
            //if (rectRightTop.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && mouseStatePrevious.LeftButton == ButtonState.Released)
            //{
            //    nextPressed = true;
            //}
            //if (rectRightTop.Contains(mouseState.Position) && nextPressed && mouseState.LeftButton == ButtonState.Released)
            //{
            //    frameStart = 0; frameEnd = 6;
            //    frameCurrent = frameStart;
            //    frameTimer = 0;
            //    nextPressed = false;
            //    //startColor = Color.DarkGoldenrod; endColor = Color.Transparent;
            //    //colorTimer = 0; colorTimerMax = 200f;
            //}
            //else if (nextPressed && mouseState.LeftButton == ButtonState.Released)
            //{
            //    nextPressed = false;
            //}
            ///////
            //mouseStatePrevious = mouseState;


            if (bookOpened == false)
            {
                BookOpening(100f);
            }
            if (bookFlipOpen > 0)
            {
                PageForward(25f);
            }
            //if (frameStart == 0 && frameEnd == 6)
            //{
            //    PageForward(100f);
            //}
            //if (frameStart == 6 && frameEnd == 0)
            //{
            //    PageBackward(100f);
            //}
            //if (frameStart == 0 && frameEnd == 0) frameTimer = 0;
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
                        sourceRectRightBottom = textureRect[4];
                        sourceRectRightTop = textureRect[3];

                        bookOpened = true;
                        frameCount = -1;
                        bookFlipOpen = 5;
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
                        frameCount = -1;
                        bookFlipOpen--;
                        break;
                    default:
                        break;
                }
                if (bookFlipOpen == 0)
                {
                    sourceRectLeftBottom = textureRect[10];
                    sourceRectLeftTop = textureRect[14];
                    sourceRectRightBottom = textureRect[3];
                    sourceRectRightTop = textureRect[14];
                }
                frameCount++;
                frameTimer = 0;
            }
        }

        public void PageBackward(float frameSpeed)
        {
            if (frameTimer > frameSpeed)
            {
                if (frameCount == frameEnd)
                {
                    frameStart = 0; frameEnd = 0;
                    frameCount = 0;
                    //startColor = Color.Transparent; endColor = Color.DarkGoldenrod;
                    //colorTimer = 0; colorTimerMax = 200f;
                }
                if (frameCount > frameEnd)
                {
                    frameCount--;
                    frameTimer = 0;
                }
            }
            //sourceRectLeftTop = new Rectangle(frameCurrent * frameWidth, 0, frameWidth, frameHeight);
        }

        public void Draw(GameTime gameTime)
        {
            if (IsBookOpen)
            {
                _spriteBatch.Draw(bookTexture, posLeft, sourceRectLeftBottom, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                _spriteBatch.Draw(bookTexture, posRight, sourceRectRightBottom, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                _spriteBatch.Draw(bookTexture, posLeft, sourceRectLeftTop, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                _spriteBatch.Draw(bookTexture, posRight, sourceRectRightTop, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);



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
