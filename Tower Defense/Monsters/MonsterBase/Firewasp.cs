using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class Firewasp : MonsterBase
    {
        private int maxHealth;
        public int health;

        public Firewasp(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            name = "Firewasp";

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
            factorX = 1;
            factorY = 0;
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
            base.Move();
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
