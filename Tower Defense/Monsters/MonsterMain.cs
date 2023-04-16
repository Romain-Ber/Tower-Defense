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
        public static Dictionary<string, Texture2D> monsterTexture;
        public static List<MonsterBase> monsterList;
        private float monsterTimer;
        private int monsterCount; // temps for demo

        public MonsterMain(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
        }
        public void Load()
        {
            monsterTexture = new Dictionary<string, Texture2D>()
            {
                { "Leafbug", _content.Load<Texture2D>("Monster/Leafbug") },
                { "Firebug", _content.Load<Texture2D>("Monster/Firebug") },
                { "MagmaCrab", _content.Load<Texture2D>("Monster/Magma Crab") },
                { "Scorpion", _content.Load<Texture2D>("Monster/Scorpion") },
                { "Voidbutterfly", _content.Load<Texture2D>("Monster/Voidbutterfly") },
                { "FlyingLocust", _content.Load<Texture2D>("Monster/Flying Locust") },
                { "Firewasp", _content.Load<Texture2D>("Monster/Firewasp") },
                { "Clampbeetle", _content.Load<Texture2D>("Monster/Clampbeetle") }
            };

            monsterList = new List<MonsterBase>
            {
                new Leafbug(_spriteBatch)
            };
            monsterTimer = 0;

            monsterCount = 0;
        }

        public void Unload()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            monsterTimer += gameTime.ElapsedGameTime.Milliseconds * MainGame.gameSpeedDictionary[MainGame.gameSpeedIndex];
            if (monsterTimer > 1500)
            {
                if (monsterCount > 8)
                {
                    monsterCount = 0;
                }
                else
                {
                    monsterCount = monsterCount + 1;
                }
                switch (monsterCount)
                {
                    case 0:
                        monsterList.Add(new Clampbeetle(_spriteBatch));
                        break;
                    case 1:
                        monsterList.Add(new MagmaCrab(_spriteBatch));
                        break;
                    case 2:
                        monsterList.Add(new FlyingLocust(_spriteBatch));
                        break;
                    case 3:
                        monsterList.Add(new Scorpion(_spriteBatch));
                        break;
                    case 4:
                        monsterList.Add(new Voidbutterfly(_spriteBatch));
                        break;
                    case 5:
                        monsterList.Add(new Leafbug(_spriteBatch));
                        break;
                    case 6:
                        monsterList.Add(new Firewasp(_spriteBatch));
                        break;
                    case 7:
                        monsterList.Add(new Firebug(_spriteBatch));
                        break;
                    default:
                        break;
                }
                monsterTimer = 0;
            }
            UpdateMonsters(gameTime);
        }

        public void UpdateMonsters(GameTime gameTime)
        {
            for (int i = monsterList.Count - 1; i >= 0; i--)
            {
                MonsterBase monster = monsterList[i];
                monster.Update(gameTime);
                if (monster.reachedVillage)
                {
                    monsterList.RemoveAt(i);
                    Overlay.playerHealth--;
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            for (int i = monsterList.Count - 1; i >= 0; i--)
            {
                MonsterBase monster = monsterList[i];
                monster.Draw(gameTime);
            }
        }
    }
}
