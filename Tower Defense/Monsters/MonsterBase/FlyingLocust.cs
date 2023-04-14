﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class FlyingLocust: MonsterBase
    {
        private int maxHealth;
        public int health;

        public FlyingLocust(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            name = "FlyingLocust";

            frameMax = 8;
            frameOffsetX = 0;
            frameOffsetY = 0;
            frameRow = 0;
            frameSpeed = 80f;

            monsterSpeed = 1f;
            maxHealth = 10;
            health = maxHealth;

            IsGround = false;
            lastDirection = "RIGHT";
            sourceRect = new Rectangle(frameCurrent * monsterWidth + frameOffsetX * monsterWidth + frameOffsetX,
                                       frameRow * monsterHeight + frameOffsetY * monsterHeight + frameOffsetY,
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
