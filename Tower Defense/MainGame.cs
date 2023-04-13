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
        private Map map;
        private Overlay overlay;
        private MonsterMain monsters;

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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = new Map(Content, spriteBatch);
            map.Load();
            overlay = new Overlay(Content, spriteBatch);
            overlay.Load();
            monsters = new MonsterMain(Content, spriteBatch);
            monsters.Load();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            map.Update(gameTime);
            monsters.Update(gameTime);
            overlay.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            map.Draw(gameTime, "PATH");
            monsters.Draw(gameTime);
            map.Draw(gameTime, "ACCENT");
            overlay.Draw(gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}