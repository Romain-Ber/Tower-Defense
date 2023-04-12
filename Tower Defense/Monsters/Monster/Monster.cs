using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public abstract class Monster
    {
        private SpriteBatch _spriteBatch;
        protected int monsterWidth, monsterHeight;
        private Vector2 position;
        private Rectangle bounds;
        protected Rectangle sourceRect;
        private float speed;
        private string type;
        private string path;
        private int health, maxHealth;

        public Monster(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
