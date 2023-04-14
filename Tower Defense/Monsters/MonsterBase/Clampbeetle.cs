using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class Clampbeetle : MonsterBase
    {
        private int maxHealth;
        public int health;

        public Clampbeetle(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            name = "Clampbeetle";

            frameMax = 8;
            frameOffsetX = 0;
            frameOffsetY = 0;
            frameRow = 0;
            frameSpeed = 80f;

            monsterSpeed = 0.75f;
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
                    break;
                default:
                    break;
            }
            position = new Vector2(position.X + factorX * monsterSpeed, position.Y + factorY * monsterSpeed);
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
