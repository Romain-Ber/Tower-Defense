using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
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
        private MonsterMain monsterMain;
        private TowerMain towerMain;

        public static Dictionary<int, float> gameSpeedDictionary;
        public static int gameSpeedIndex;

        public static int screenWidth, screenHeight;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.GraphicsProfile = GraphicsProfile.HiDef; //necessary to treat large sized textures >4096px
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
            map = new Map(Content, spriteBatch); map.Load();
            overlay = new Overlay(Content, spriteBatch); overlay.Load();
            monsterMain = new MonsterMain(Content, spriteBatch); monsterMain.Load();
            towerMain = new TowerMain(Content, spriteBatch); towerMain.Load();

            gameSpeedDictionary = new Dictionary<int, float>
            {
                {0, 0f },
                {1, 0.1f },
                {2, 0.25f },
                {3, 0.5f },
                {4, 1f },
                {5, 2f },
                {6, 4f },
                {7, 8f }
            };
            gameSpeedIndex = 4;

            screenWidth = graphics.PreferredBackBufferWidth;
            screenHeight = graphics.PreferredBackBufferHeight;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            map.Update(gameTime);
            monsterMain.Update(gameTime);
            towerMain.Update(gameTime);
            overlay.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            map.Draw(gameTime, "PATH");
            monsterMain.Draw(gameTime);
            map.Draw(gameTime, "ACCENT");
            towerMain.Draw(gameTime);
            overlay.Draw(gameTime);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}