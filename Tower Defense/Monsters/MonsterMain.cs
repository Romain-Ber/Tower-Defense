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

        private List<string> waveContent;
        private int levelIndex;

        private float waveTimer;
        private float waveInterval;
        private float spawnInterval;

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
                //new Leafbug(_spriteBatch)
            };
            waveTimer = 0;
            waveInterval = 45000;

            monsterCount = 0;

            levelIndex = 0;

        }

        public void Unload()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            waveTimer += gameTime.ElapsedGameTime.Milliseconds * MainGame.gameSpeedDictionary[MainGame.gameSpeedIndex];
            AddWave();
            UpdateMonsters(gameTime);
        }

        public void AddWave()
        {
            if (waveTimer > waveInterval && levelIndex < Levels.levelContent.Count)
            {
                spawnInterval = (float)(waveInterval / 1.5) / Levels.levelContent[levelIndex].Count;
                waveContent = new List<string>(Levels.levelContent[levelIndex]);
                levelIndex++;
            }
            if (waveContent != null && waveContent.Count > 0)
            {
                for (int i = waveContent.Count - 1; i >= 0; i--)
                {
                    if (waveTimer > spawnInterval)
                    {
                        switch (waveContent[i])
                        {
                            case "Clampbeetle":
                                monsterList.Add(new Clampbeetle(_spriteBatch));
                                break;
                            case "Firebug":
                                monsterList.Add(new Firebug(_spriteBatch));
                                break;
                            case "Firewasp":
                                monsterList.Add(new Firewasp(_spriteBatch));
                                break;
                            case "FlyingLocust":
                                monsterList.Add(new FlyingLocust(_spriteBatch));
                                break;
                            case "Leafbug":
                                monsterList.Add(new Leafbug(_spriteBatch));
                                break;
                            case "MagmaCrab":
                                monsterList.Add(new MagmaCrab(_spriteBatch));
                                break;
                            case "Scorpion":
                                monsterList.Add(new Scorpion(_spriteBatch));
                                break;
                            case "Voidbutterfly":
                                monsterList.Add(new Voidbutterfly(_spriteBatch));
                                break;
                            default:
                                break;
                        }
                        waveContent.RemoveAt(i);
                        waveTimer = 0;
                    }
                }
            }
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

            string gameTimerText = $"Game Time: {waveTimer / 1000}";
            Vector2 monsterCountVector = new Vector2(32, 32);
            _spriteBatch.DrawString(Overlay.cinzelBoldFont, gameTimerText, monsterCountVector, Color.BlanchedAlmond);

            string dataText = $"Wave: {levelIndex} / {Levels.levelContent.Count}";
            Vector2 dataVector = new Vector2(48, 48);
            _spriteBatch.DrawString(Overlay.cinzelBoldFont, dataText, dataVector, Color.BlanchedAlmond);


        }
    }
}
