using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static Dictionary<int, Texture2D> projectileTexture;
        public static Dictionary<int, Texture2D> impactTexture;

        public static List<TowerBase> towerList;
        public static List<ProjectileBase> projectileList;

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
                { 0, _content.Load<Texture2D>("Tower/Tower 01") },
                { 1, _content.Load<Texture2D>("Tower/Tower 02") },
                { 2, _content.Load<Texture2D>("Tower/Tower 03") },
                { 3, _content.Load<Texture2D>("Tower/Tower 04") },
                { 4, _content.Load<Texture2D>("Tower/Tower 05") },
                { 5, _content.Load<Texture2D>("Tower/Tower 06") },
                { 6, _content.Load<Texture2D>("Tower/Tower 07") },
                { 7, _content.Load<Texture2D>("Tower/Tower 08") }
            };
            weaponTexture = new Dictionary<int, Texture2D>()
            {
                { 0, _content.Load<Texture2D>("Weapon/Tower 01 - Level 01 - Weapon") },
                { 1, _content.Load<Texture2D>("Weapon/Tower 01 - Level 02 - Weapon") },
                { 2, _content.Load<Texture2D>("Weapon/Tower 01 - Level 03 - Weapon") },
                { 3, _content.Load<Texture2D>("Weapon/Tower 02 - Level 01 - Weapon") },
                { 4, _content.Load<Texture2D>("Weapon/Tower 02 - Level 02 - Weapon") },
                { 5, _content.Load<Texture2D>("Weapon/Tower 02 - Level 03 - Weapon") },
                { 6, _content.Load<Texture2D>("Weapon/Tower 03 - Level 01 - Weapon") },
                { 7, _content.Load<Texture2D>("Weapon/Tower 03 - Level 02 - Weapon") },
                { 8, _content.Load<Texture2D>("Weapon/Tower 03 - Level 03 - Weapon") },
                { 9, _content.Load<Texture2D>("Weapon/Tower 04 - Level 01 - Weapon") },
                { 10, _content.Load<Texture2D>("Weapon/Tower 04 - Level 02 - Weapon") },
                { 11, _content.Load<Texture2D>("Weapon/Tower 04 - Level 03 - Weapon") },
                { 12, _content.Load<Texture2D>("Weapon/Tower 05 - Level 01 - Weapon") },
                { 13, _content.Load<Texture2D>("Weapon/Tower 05 - Level 02 - Weapon") },
                { 14, _content.Load<Texture2D>("Weapon/Tower 05 - Level 03 - Weapon") },
                { 15, _content.Load<Texture2D>("Weapon/Tower 06 - Level 01 - Weapon") },
                { 16, _content.Load<Texture2D>("Weapon/Tower 06 - Level 02 - Weapon") },
                { 17, _content.Load<Texture2D>("Weapon/Tower 06 - Level 03 - Weapon") },
                { 18, _content.Load<Texture2D>("Weapon/Tower 07 - Level 01 - Weapon") },
                { 19, _content.Load<Texture2D>("Weapon/Tower 07 - Level 02 - Weapon") },
                { 20, _content.Load<Texture2D>("Weapon/Tower 07 - Level 03 - Weapon") },
                { 21, _content.Load<Texture2D>("Weapon/Tower 08 - Level 01 - Weapon") },
                { 22, _content.Load<Texture2D>("Weapon/Tower 08 - Level 02 - Weapon") },
                { 23, _content.Load<Texture2D>("Weapon/Tower 08 - Level 03 - Weapon") }
            };
            projectileTexture = new Dictionary<int, Texture2D>()
            {
                { 0, _content.Load<Texture2D>("Projectile/Tower 01 - Level 01 - Projectile") },
                { 1, _content.Load<Texture2D>("Projectile/Tower 01 - Level 02 - Projectile") },
                { 2, _content.Load<Texture2D>("Projectile/Tower 01 - Level 03 - Projectile") },
                { 3, _content.Load<Texture2D>("Projectile/Tower 02 - Level 01 - Projectile") },
                { 4, _content.Load<Texture2D>("Projectile/Tower 02 - Level 02 - Projectile") },
                { 5, _content.Load<Texture2D>("Projectile/Tower 02 - Level 03 - Projectile") },
                { 6, _content.Load<Texture2D>("Projectile/Tower 03 - Level 01 - Projectile") },
                { 7, _content.Load<Texture2D>("Projectile/Tower 03 - Level 02 - Projectile") },
                { 8, _content.Load<Texture2D>("Projectile/Tower 03 - Level 03 - Projectile") },
                { 9, _content.Load<Texture2D>("Projectile/Tower 04 - Level 01 - Projectile") },
                { 10, _content.Load<Texture2D>("Projectile/Tower 04 - Level 02 - Projectile") },
                { 11, _content.Load<Texture2D>("Projectile/Tower 04 - Level 03 - Projectile") },
                { 12, _content.Load<Texture2D>("Projectile/Tower 05 - Level 01 - Projectile") },
                { 13, _content.Load<Texture2D>("Projectile/Tower 05 - Level 02 - Projectile") },
                { 14, _content.Load<Texture2D>("Projectile/Tower 05 - Level 03 - Projectile") },
                { 15, _content.Load<Texture2D>("Projectile/Tower 06 - Level 01 - Projectile") },
                { 16, _content.Load<Texture2D>("Projectile/Tower 06 - Level 02 - Projectile") },
                { 17, _content.Load<Texture2D>("Projectile/Tower 06 - Level 03 - Projectile") },
                { 18, _content.Load<Texture2D>("Projectile/Tower 07 - Level X - Projectile") },
                { 19, _content.Load<Texture2D>("Projectile/Tower 08 - Level 01 - Projectile") },
                { 20, _content.Load<Texture2D>("Projectile/Tower 08 - Level 02 - Projectile") },
                { 21, _content.Load<Texture2D>("Projectile/Tower 08 - Level 03 - Projectile") }
            };
            impactTexture = new Dictionary<int, Texture2D>()
            {
                { 0, _content.Load<Texture2D>("Impact/Tower 01 - Weapon - Impact") },
                { 1, _content.Load<Texture2D>("Impact/Tower 02 - Level 01 - Projectile - Impact") },
                { 2, _content.Load<Texture2D>("Impact/Tower 02 - Level 02 - Projectile - Impact") },
                { 3, _content.Load<Texture2D>("Impact/Tower 02 - Level 03 - Projectile - Impact") },
                { 4, _content.Load<Texture2D>("Impact/Tower 03 - Level 01 - Projectile - Impact") },
                { 5, _content.Load<Texture2D>("Impact/Tower 03 - Level 02 - Projectile - Impact") },
                { 6, _content.Load<Texture2D>("Impact/Tower 03 - Level 03 - Projectile - Impact") },
                { 7, _content.Load<Texture2D>("Impact/Tower 04 - Level 01 - Projectile - Impact") },
                { 8, _content.Load<Texture2D>("Impact/Tower 04 - Level 02 - Projectile - Impact") },
                { 9, _content.Load<Texture2D>("Impact/Tower 04 - Level 03 - Projectile - Impact") },
                { 10, _content.Load<Texture2D>("Impact/Tower 05 - Level 01 - Projectile - Impact") },
                { 11, _content.Load<Texture2D>("Impact/Tower 05 - Level 02 - Projectile - Impact") },
                { 12, _content.Load<Texture2D>("Impact/Tower 05 - Level 03 - Projectile - Impact") },
                { 13, _content.Load<Texture2D>("Impact/Tower 06 - Weapon - Impact") },
                { 14, _content.Load<Texture2D>("Impact/Tower 07 - Level X - Projectile - Impact") }
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
