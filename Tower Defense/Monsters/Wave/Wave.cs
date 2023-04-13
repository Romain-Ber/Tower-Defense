using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class Wave
    {
        private List<MonsterBase> monsterList { get; }
        public Wave()
        {
            monsterList.Add(new MonsterGround1());
        }

        public void Update(GameTime gameTime)
        {
            foreach (MonsterBase monster in monsterList)
            {
                
            }
        }
        public void Draw(GameTime gameTime)
        {
            foreach (MonsterBase monster in monsterList)
            {

            }
        }
    }
}