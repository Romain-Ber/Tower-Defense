using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public abstract class TowerBase
    {
        protected SpriteBatch _spriteBatch;
        protected Vector2 position;
        protected Vector2 scale;
        protected float fireSpeed;
        protected float fireTime;
        protected float fireRate;
        protected float rotationSpeed;

        protected int frameMax, frameCurrent;
        protected float frameTimer, frameSpeed;
        protected int frameOffsetX, frameOffsetY;
        protected int frameRow;
        protected SpriteEffects frameFlip;
        protected Rectangle sourceRect;


        public TowerBase(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime)
        { 

        }
    }
}
