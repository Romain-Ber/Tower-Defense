using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledCS;

namespace Tower_Defense
{
    public abstract class MonsterBase
    {
        private Map map;
        protected int monsterWidth, monsterHeight;
        protected float monsterSpeed;
        public bool IsGround { get; protected set; }
        private Vector2 position;
        private Rectangle bounds;
        private Rectangle sourceRect;
        private string direction;
        protected int vectorX, vectorY;

        public MonsterBase()
        {
            monsterWidth = 64;
            monsterHeight = 64;
            this.map = map;
        }

        public virtual void Update(GameTime gameTime)
        {
            CheckWall();
            position = new Vector2(position.X + monsterSpeed * vectorX, position.Y + monsterSpeed * vectorY);
        }

        public virtual void CheckWall()
        {
            switch (direction)
            {
                case "DOWN":
                    //if (map.Layers.Where(x => x.type == TiledLayerType.TileLayer && x.name == "GroundPath"))
                    break;
                case "UP":

                    break;
                case "LEFT":

                    break;
                case "RIGHT":

                    break;
                default:
                    break;
            }
        }

        public virtual void ChangeDirection()
        {

        }
    }
}
