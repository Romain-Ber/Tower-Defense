using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class MonsterGround1 : MonsterBase
    {
        private int frames { get; }
        private int frameOffsetX { get; }
        private int frameOffsetY { get; }
        private float frameSpeed { get; }
        private string monsterType { get; }
        private int maxHealth;
        private int health { get; set; }

        public int getHealth()
        {
            return health;
        }
        public void setHealth(int health)
        {
            this.health = health;
        }


        public MonsterGround1(): base()
        {
            frames = 6;
            frameOffsetX = 0;
            frameOffsetY = 0;
            frameSpeed = 200f;
            monsterSpeed = 5f;
            monsterType = "Leafbug";
            IsGround = true;
            maxHealth = 10;
            health = maxHealth;

            Map.groundPath = null;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
