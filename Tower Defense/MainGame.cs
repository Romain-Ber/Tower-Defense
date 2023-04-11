using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing.Text;
using TiledCS;

namespace Tower_Defense
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private MouseState mouseState;
        private Map map;
        private Overlay overlay;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = new Map(Content, spriteBatch);
            map.Load();
            overlay = new Overlay(Content, spriteBatch);
            overlay.Load();


            // TODO: use this.Content to load your game content here

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            map.Update(gameTime);
            overlay.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            map.Draw(gameTime, "PATH");


            map.Draw(gameTime, "ACCENT");
            overlay.Draw(gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}