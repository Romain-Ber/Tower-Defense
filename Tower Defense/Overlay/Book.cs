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
        private Rectangle sourceRect;
        private Vector2 position;
        private float scale;
        private int frameMax;
        public static int frameStart, frameEnd, frameCurrent;
        private int frameWidth, frameHeight;
        private float frameTimer, frameSpeed;
        private int pageFlipCount;

        private Rectangle previousPage, nextPage;
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
            //bookTexture = _content.Load<Texture2D>("Book/RADL_Book_red");
            bookTexture = _content.Load<Texture2D>("Book/bookAnim");

            frameMax = 7; frameCurrent = 0;
            frameWidth = bookTexture.Width / frameMax; frameHeight = bookTexture.Height;

            frameTimer = 0;
            frameSpeed = 100f;
            sourceRect = new Rectangle(0, 0, bookTexture.Width / frameMax, bookTexture.Height);
            //scale = 7f;
            scale = 1f;
            //position = new Vector2(200, -40);
            position = new Vector2(350, 200);
            frameStart = 0; frameEnd = 2;
            IsBookOpen = false;

            previousPage = new Rectangle((int)position.X, (int)position.Y, frameWidth / 2, frameHeight);
            nextPage = new Rectangle((int)position.X + frameWidth / 2, (int)position.Y, frameWidth / 2, frameHeight);
        }

        public void Update(GameTime gameTime)
        {
            if (IsBookOpen)
            {
                UpdateBook(gameTime);
            }
            else
            {
                startColor = Color.DarkGoldenrod; endColor = Color.Transparent;
                colorTimer = 0; colorTimerMax = 10f;
            }
        }

        public void UpdateBook(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime.Milliseconds;

            mouseState = Mouse.GetState();
            /////
            if (previousPage.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && mouseStatePrevious.LeftButton == ButtonState.Released)
            {
                previousPressed = true;
            }
            if (previousPage.Contains(mouseState.Position) && previousPressed && mouseState.LeftButton == ButtonState.Released)
            {
                frameStart = 6; frameEnd = 0;
                frameCurrent = frameStart;
                frameTimer = 0;
                previousPressed = false;
                startColor = Color.DarkGoldenrod; endColor = Color.Transparent;
                colorTimer = 0; colorTimerMax = 350f;
            }
            else if (previousPressed && mouseState.LeftButton == ButtonState.Released)
            {
                previousPressed = false;
            }
            ///////
            if (nextPage.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && mouseStatePrevious.LeftButton == ButtonState.Released)
            {
                nextPressed = true;
            }
            if (nextPage.Contains(mouseState.Position) && nextPressed && mouseState.LeftButton == ButtonState.Released)
            {
                frameStart = 0; frameEnd = 6;
                frameCurrent = frameStart;
                frameTimer = 0;
                nextPressed = false;
                startColor = Color.DarkGoldenrod; endColor = Color.Transparent;
                colorTimer = 0; colorTimerMax = 200f;
            }
            else if (nextPressed && mouseState.LeftButton == ButtonState.Released)
            {
                nextPressed = false;
            }
            /////
            mouseStatePrevious = mouseState;


            if (frameStart == 0 && frameEnd == 5)
            {
                BookOpening();
            }
            if (frameStart == 1 && frameEnd == 5)
            {
                PageFlipping();
            }
            if (frameStart == 0 && frameEnd == 6)
            {
                PageForward();
            }
            if (frameStart == 6 && frameEnd == 0)
            {
                PageBackward();
            }
            if (frameStart == 0 && frameEnd == 0) frameTimer = 0;
            sourceRect = new Rectangle(frameCurrent * frameWidth, 0, frameWidth, frameHeight);
        }

        public void BookOpening()
        {
            //frameStart = 0; frameEnd = 2;
            frameSpeed = 20f;
            if (frameTimer > frameSpeed)
            {
                if (frameCurrent == frameEnd)
                {
                    frameStart = 1; frameEnd = 5; //change to next animation: PageFlipping()
                    frameCurrent = frameStart;
                    pageFlipCount = 3;
                    frameTimer = 0;
                }
                if (frameCurrent < frameEnd)
                {
                    frameCurrent++;
                    frameTimer = 0;
                }
            }
        }

        public void PageFlipping()
        {
            frameSpeed = 20f;
            //frameStart = 4; frameEnd = 6;
            if (frameTimer > frameSpeed)
            {
                if (pageFlipCount == 0 && frameCurrent == frameEnd)
                {
                    frameStart = 0; frameEnd = 0;
                    frameCurrent = 0;
                    frameTimer = 0;
                    startColor = Color.Transparent; endColor = Color.DarkGoldenrod;
                    colorTimer = 0; colorTimerMax = 200f;
                }
                else if (frameCurrent >= frameEnd)
                {
                    frameCurrent = frameStart;
                    pageFlipCount--;
                }
                else
                {
                    frameCurrent++;
                    frameTimer = 0;
                }
            }
        }

        public void PageForward()
        {
            frameSpeed = 50f;
            if (frameTimer > frameSpeed)
            {
                if (frameCurrent == frameEnd)
                {
                    frameStart = 0; frameEnd = 0;
                    frameCurrent = 0;
                    startColor = Color.Transparent; endColor = Color.DarkGoldenrod;
                    colorTimer = 0; colorTimerMax = 200f;
                }
                if (frameCurrent < frameEnd)
                {
                    frameCurrent++;
                    frameTimer = 0;
                }
            }
        }

        public void PageBackward()
        {
            frameSpeed = 50f;
            if (frameTimer > frameSpeed)
            {
                if (frameCurrent == frameEnd)
                {
                    frameStart = 0; frameEnd = 0;
                    frameCurrent = 0;
                    startColor = Color.Transparent; endColor = Color.DarkGoldenrod;
                    colorTimer = 0; colorTimerMax = 200f;
                }
                if (frameCurrent > frameEnd)
                {
                    frameCurrent--;
                    frameTimer = 0;
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (IsBookOpen)
            {
                _spriteBatch.Draw(bookTexture, position, new Rectangle(0, 0, bookTexture.Width / frameMax, bookTexture.Height), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                _spriteBatch.Draw(bookTexture, position, sourceRect, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);



                colorTimer += gameTime.ElapsedGameTime.Milliseconds;
                Color currentColor = Color.Lerp(startColor, endColor, colorTimer / colorTimerMax);

                string dataText = "                                                LEXICON";
                Vector2 dataVector = new Vector2(position.X + (int)(frameWidth / 2), position.Y + 100);
                _spriteBatch.DrawString(Overlay.cinzelBoldFont, dataText, dataVector, currentColor);




                /////
                /////conceive a function that draws a layer containing text as a background so the second layer gives a better effect
            }
        }


    }
}
