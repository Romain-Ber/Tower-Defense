using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledCS;

namespace Tower_Defense
{
    public class Map
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private TiledMap _map;


        private TiledTileset _tileset1, _tileset2, _tileset3, _tileset4, _tileset5;
        private Texture2D _tilesetTexture1, _tilesetTexture2, _tilesetTexture3, _tilesetTexture4, _tilesetTexture5;
        private int _tileWidth1, _tileWidth2, _tileWidth3, _tileWidth4, _tileWidth5;
        private int _tileHeight1, _tileHeight2, _tileHeight3, _tileHeight4, _tileHeight5;
        private int _tilesetTilesWide1, _tilesetTilesWide2, _tilesetTilesWide3, _tilesetTilesWide4, _tilesetTilesWide5;
        private int _tilesetTilesHeight1, _tilesetTilesHeight2, _tilesetTilesHeight3, _tilesetTilesHeight4, _tilesetTilesHeight5;

        public Map(ContentManager content, SpriteBatch spriteBatch)
        { 
            _content = content;
            _spriteBatch = spriteBatch;
        }

        public void LoadContent()
        {
            _map = new TiledMap("Content/Tile/map1.tmx");
            _tileset1 = new TiledTileset("Content/Tile/terrain tiles.tsx");
            _tilesetTexture1 = _content.Load<Texture2D>("Tile/terrain tiles");
            _tileWidth1 = _tileset1.TileWidth;
            _tileHeight1 = _tileset1.TileHeight;
            _tilesetTilesWide1 = _tileset1.Columns;
            _tilesetTilesHeight1 = _tileset1.TileCount / _tileset1.Columns;
            _tileset2 = new TiledTileset("Content/Tile/waterfalls.tsx");
            _tilesetTexture2 = _content.Load<Texture2D>("Tile/waterfalls");
            _tileWidth2 = _tileset2.TileWidth;
            _tileHeight2 = _tileset2.TileHeight;
            _tilesetTilesWide2 = _tileset2.Columns;
            _tilesetTilesHeight2 = _tileset2.TileCount / _tileset2.Columns;
            _tileset3 = new TiledTileset("Content/Tile/Decorations.tsx");
            _tilesetTexture3 = _content.Load<Texture2D>("Tile/Decorations");
            _tileWidth3 = _tileset3.TileWidth;
            _tileHeight3 = _tileset3.TileHeight;
            _tilesetTilesWide3 = _tileset3.Columns;
            _tilesetTilesHeight3 = _tileset3.TileCount / _tileset3.Columns;
            _tileset4 = new TiledTileset("Content/Tile/TX Props.tsx");
            _tilesetTexture4 = _content.Load<Texture2D>("Tile/TX Props");
            _tileWidth4 = _tileset4.TileWidth;
            _tileHeight4 = _tileset4.TileHeight;
            _tilesetTilesWide4 = _tileset4.Columns;
            _tilesetTilesHeight4 = _tileset4.TileCount / _tileset4.Columns;
            _tileset5 = new TiledTileset("Content/Tile/houses.tsx");
            _tilesetTexture5 = _content.Load<Texture2D>("Tile/houses");
            _tileWidth5 = _tileset5.TileWidth;
            _tileHeight5 = _tileset5.TileHeight;
            _tilesetTilesWide5 = _tileset5.Columns;
            _tilesetTilesHeight5 = _tileset5.TileCount / _tileset5.Columns;
        }
        public void Unload()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw1(GameTime gameTime)
        {
            for (var i = 0; i < _map.Layers[0].data.Length; i++)
            {
                int gid = _map.Layers[0].data[i];

                // Empty tile, do nothing
                if (gid == 0)
                {

                }
                else
                {
                    // Tileset tile ID
                    // Looking at the exampleTileset.png
                    // 0 = Blue
                    // 1 = Green
                    // 2 = Dark Yellow
                    // 3 = Magenta
                    int tileFrame = gid - 1;

                    // Print the tile type into the debug console.
                    // This assumes only one (1) `tiled tileset` is being used, so getting the first one.
                    var tile = _map.GetTiledTile(_map.Tilesets[0], _tileset1, gid);
                    if (tile != null)
                    {
                        // This should print "Grass" for each grass tile in the map each draw call
                        // so six (6) times.
                        System.Diagnostics.Debug.WriteLine(tile.type);
                    }

                    int column = tileFrame % _tilesetTilesWide1;
                    int row = (int)Math.Floor((double)tileFrame / (double)_tilesetTilesWide1);

                    float x = (i % _map.Width) * _map.TileWidth + 16;
                    float y = (float)Math.Floor(i / (double)_map.Width) * _map.TileHeight + 20;

                    Rectangle tilesetRec = new Rectangle(_tileWidth1 * column, _tileHeight1 * row, _tileWidth1, _tileHeight1);

                    _spriteBatch.Draw(_tilesetTexture1, new Rectangle((int)x, (int)y, _tileWidth1, _tileHeight1), tilesetRec, Color.White);
                }
            }
        }
        public void Draw2(GameTime gameTime)
        {

        }
    }
}
