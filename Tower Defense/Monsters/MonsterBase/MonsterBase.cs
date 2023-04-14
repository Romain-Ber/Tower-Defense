using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledCS;

namespace Tower_Defense
{
    public abstract class MonsterBase
    {
        protected SpriteBatch _spriteBatch;
        protected int monsterWidth, monsterHeight;
        protected float monsterSpeed;
        protected bool IsGround;
        protected Vector2 position;
        protected int frameMax, frameCurrent;
        protected float frameTimer, frameSpeed;
        protected int frameOffsetX, frameOffsetY;
        protected int frameRow;
        protected SpriteEffects frameFlip;
        protected Rectangle sourceRect;
        protected string lastDirection;
        protected int factorX, factorY;
        protected string name;

        public MonsterBase(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            monsterWidth = 64;
            monsterHeight = 64;
            frameCurrent = 0;
            frameTimer = 0f;
            frameFlip = SpriteEffects.None;
            position = new Vector2(Map.monsterStartX, Map.monsterStartY);
        }

        public virtual void Update(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime.Milliseconds;
            Direction();
            Move();
            UpdateFrame();
        }

        public virtual void Direction()
        {
            int currentX = (int)((position.X - Map.mapOffsetX) / Map.mapTileWidth);
            int currentY = (int)((position.Y - Map.mapOffsetY) / Map.mapTileHeight);
            if (IsGround)
            {
                if (lastDirection != Map.groundPath[currentX, currentY] && Map.groundPath[currentX, currentY] != "START")
                {
                    lastDirection = Map.groundPath[currentX, currentY];
                    position = new Vector2(currentX * Map.mapTileWidth + Map.mapOffsetX, currentY * Map.mapTileHeight + Map.mapOffsetY);
                }
            }
            else
            {
                if (lastDirection != Map.flyingPath[currentX, currentY] && Map.groundPath[currentX, currentY] != "START")
                {
                    lastDirection = Map.flyingPath[currentX, currentY];
                    position = new Vector2(currentX * Map.mapTileWidth + Map.mapOffsetX, currentY * Map.mapTileHeight + Map.mapOffsetY);
                }
            }
        }

        public virtual void Move()
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
                    frameRow = 2; frameFlip = SpriteEffects.FlipHorizontally;
                    break;
                case "RIGHT":
                    factorX = 1; factorY = 0;
                    frameRow = 2; frameFlip = SpriteEffects.None;
                    break;
                case "END":
                    factorX = 0; factorY = 0;
                    break;
                default:
                    break;
            }
            position = new Vector2(position.X + factorX * monsterSpeed, position.Y + factorY * monsterSpeed);
        }

        public virtual void UpdateFrame()
        {
            if (frameTimer > frameSpeed)
            {
                if (frameCurrent + 1 >= frameMax)
                {
                    frameCurrent = 0;
                }
                else
                {
                    frameCurrent += 1;
                }
                frameTimer = 0;
            }
            sourceRect = new Rectangle(frameCurrent * monsterWidth + (frameCurrent + 1) * frameOffsetX,
                                       frameRow * monsterHeight + (frameRow + 1) * frameOffsetY,
                                       monsterWidth,
                                       monsterHeight);
        }

        public virtual void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(MonsterMain.monsterTexture[name], position, sourceRect, Color.White, 0f, Vector2.Zero, 1f, frameFlip, 0f);
        }
    }
}
