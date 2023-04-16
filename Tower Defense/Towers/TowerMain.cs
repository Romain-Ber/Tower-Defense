using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class TowerMain
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        public static Texture2D towerBuild;
        public static Texture2D towerCollapse;
        public static Dictionary<int, Texture2D> towerTexture;
        public static Dictionary<int, Texture2D> weaponTexture;

        public TowerMain(ContentManager content, SpriteBatch spriteBatch)
        {
            _content = content;
            _spriteBatch = spriteBatch;
        }

        public void Load()
        {
            towerBuild = _content.Load<Texture2D>("Misc/Tower Construction");
            towerCollapse = _content.Load<Texture2D>("Misc/Tower - Collapse");
            towerTexture = new Dictionary<int, Texture2D>()
            {
                { 1, _content.Load<Texture2D>("Tower/Tower 01") },
                { 2, _content.Load<Texture2D>("Tower/Tower 02") },
                { 3, _content.Load<Texture2D>("Tower/Tower 03") },
                { 4, _content.Load<Texture2D>("Tower/Tower 04") },
                { 5, _content.Load<Texture2D>("Tower/Tower 05") },
                { 6, _content.Load<Texture2D>("Tower/Tower 06") },
                { 7, _content.Load<Texture2D>("Tower/Tower 07") },
                { 8, _content.Load<Texture2D>("Tower/Tower 08") }
            };
            weaponTexture = new Dictionary<int, Texture2D>()
            {
                { 1, _content.Load<Texture2D>("Weapon/Tower 01 - Level 01 - Weapon") },
                { 2, _content.Load<Texture2D>("Weapon/Tower 01 - Level 02 - Weapon") },
                { 3, _content.Load<Texture2D>("Weapon/Tower 01 - Level 03 - Weapon") },
                { 4, _content.Load<Texture2D>("Weapon/Tower 02 - Level 01 - Weapon") },
                { 5, _content.Load<Texture2D>("Weapon/Tower 02 - Level 02 - Weapon") },
                { 6, _content.Load<Texture2D>("Weapon/Tower 02 - Level 03 - Weapon") },
                { 7, _content.Load<Texture2D>("Weapon/Tower 03 - Level 01 - Weapon") },
                { 8, _content.Load<Texture2D>("Weapon/Tower 03 - Level 02 - Weapon") },
                { 9, _content.Load<Texture2D>("Weapon/Tower 03 - Level 03 - Weapon") },
                { 10, _content.Load<Texture2D>("Weapon/Tower 04 - Level 01 - Weapon") },
                { 11, _content.Load<Texture2D>("Weapon/Tower 04 - Level 02 - Weapon") },
                { 12, _content.Load<Texture2D>("Weapon/Tower 04 - Level 03 - Weapon") },
                { 13, _content.Load<Texture2D>("Weapon/Tower 05 - Level 01 - Weapon") },
                { 14, _content.Load<Texture2D>("Weapon/Tower 05 - Level 02 - Weapon") },
                { 15, _content.Load<Texture2D>("Weapon/Tower 05 - Level 03 - Weapon") },
                { 16, _content.Load<Texture2D>("Weapon/Tower 06 - Level 01 - Weapon") },
                { 17, _content.Load<Texture2D>("Weapon/Tower 06 - Level 02 - Weapon") },
                { 18, _content.Load<Texture2D>("Weapon/Tower 06 - Level 03 - Weapon") },
                { 19, _content.Load<Texture2D>("Weapon/Tower 07 - Level 01 - Weapon") },
                { 20, _content.Load<Texture2D>("Weapon/Tower 07 - Level 02 - Weapon") },
                { 21, _content.Load<Texture2D>("Weapon/Tower 07 - Level 03 - Weapon") },
                { 22, _content.Load<Texture2D>("Weapon/Tower 08 - Level 01 - Weapon") },
                { 23, _content.Load<Texture2D>("Weapon/Tower 08 - Level 02 - Weapon") },
                { 24, _content.Load<Texture2D>("Weapon/Tower 08 - Level 03 - Weapon") }
            };
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {

        }
    }
}
