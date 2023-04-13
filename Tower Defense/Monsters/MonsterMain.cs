using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class MonsterMain
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private Dictionary<int, Texture2D> textureDictionary;
        private float timerCurrentWave, nextWave;
        private List<Wave> waveList;

        public MonsterMain(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
        }
        public void Load()
        {
            textureDictionary = new Dictionary<int, Texture2D>()
            {
                { 1, _content.Load<Texture2D>("Monster/Leafbug") },
                { 2, _content.Load<Texture2D>("Monster/Firebug") },
                { 3, _content.Load<Texture2D>("Monster/Magma Crab") },
                { 4, _content.Load<Texture2D>("Monster/Scorpion") },
                { 5, _content.Load<Texture2D>("Monster/Voidbutterfly") },
                { 6, _content.Load<Texture2D>("Monster/Flying Locust") },
                { 7, _content.Load<Texture2D>("Monster/Firewasp") },
                { 8, _content.Load<Texture2D>("Monster/Clampbeetle") }
            };
            timerCurrentWave = 0f;
            nextWave = 30000f;

            //waveList = new List<Wave>()
            //{
            //    new Wave()
            //};
        }

        public void Unload()
        {
            Console.WriteLine(2);
        }

        public void Update(GameTime gameTime)
        {
            timerCurrentWave += gameTime.ElapsedGameTime.Milliseconds;
            //foreach(Wave wave in waveList)
            //{
            //    wave.Update(gameTime);
            //}
        }

        public void Draw(GameTime gameTime)
        {
            //foreach (Wave wave in waveList)
            //{
            //    wave.Update(gameTime);
            //}
        }
    }
}
