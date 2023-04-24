using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class MagmaCrab: MonsterBase
    {
        private int maxHealth;
        public int health;

        public MagmaCrab(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            name = "MagmaCrab";

            frameMax = (int)Database.monsterDictionary[name]["frameMax"];
            frameOffsetX = (int)Database.monsterDictionary[name]["frameOffsetX"];
            frameOffsetY = (int)Database.monsterDictionary[name]["frameOffsetY"];
            frameRow = 0;
            frameSpeed = Database.monsterDictionary[name]["frameSpeed"];

            monsterSpeed = Database.monsterDictionary[name]["monsterSpeed"];
            maxHealth = (int)Database.monsterDictionary[name]["maxHealth"];
            health = maxHealth;
            if (Database.monsterDictionary[name]["IsGround"] == 1)
            {
                IsGround = true;
                lastDirection = "DOWN";
            }
            else
            {
                IsGround = false;
                lastDirection = "RIGHT";
            }
            sourceRect = new Rectangle(frameCurrent * monsterWidth + (frameCurrent * 2 + 1) * frameOffsetX,
                                       frameRow * monsterHeight + (frameRow * 2 + 1) * frameOffsetY,
                                       monsterWidth,
                                       monsterHeight);

            factorX = 0;
            factorY = 1;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Direction()
        {
            base.Direction();
        }

        public override void Move()
        {
            switch (lastDirection)
            {
                case "UP":
                    factorX = 0; factorY = -1;
                    frameRow = 1; frameFlip = SpriteEffects.None;
                    break;
                case "DOWN":
                    factorX = 0; factorY = 1;
                    frameRow = 0; frameFlip = SpriteEffects.None;
                    break;
                case "LEFT":
                    factorX = -1; factorY = 0;
                    frameRow = 2; frameFlip = SpriteEffects.None;
                    break;
                case "RIGHT":
                    factorX = 1; factorY = 0;
                    frameRow = 2; frameFlip = SpriteEffects.FlipHorizontally;
                    break;
                case "END":
                    factorX = 0; factorY = 0;
                    reachedVillage = true;
                    break;
                default:
                    break;
            }
            position = new Vector2(position.X + factorX * monsterSpeed * MainGame.gameSpeedDictionary[MainGame.gameSpeedIndex],
                       position.Y + factorY * monsterSpeed * MainGame.gameSpeedDictionary[MainGame.gameSpeedIndex]);
        }

        public override void UpdateFrame()
        {
            frameRow = frameRow + 3;
            base.UpdateFrame();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
