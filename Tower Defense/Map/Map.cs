using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TiledCS;

namespace Tower_Defense
{
    public class Map
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private TiledMap map;
        private Dictionary<int, TiledTileset> tilesets;
        private Dictionary<int, Texture2D> tilesetTexture;
        [Flags]
        enum Trans
        {
            None = 0,
            Flip_H = 1 << 0,
            Flip_V = 1 << 1,
            Flip_D = 1 << 2,
            Rotate_90 = Flip_D | Flip_H,
            Rotate_180 = Flip_H | Flip_V,
            Rotate_270 = Flip_V | Flip_D,
            Rotate_90AndFlip_H = Flip_H | Flip_V | Flip_D,
        }

        public Map(ContentManager content, SpriteBatch spriteBatch)
        { 
            _content = content;
            _spriteBatch = spriteBatch;
        }

        public void Load()
        {
            map = new TiledMap("Content/Tile/map1.tmx");
            tilesets = map.GetTiledTilesets("Content/Tile/");
            tilesetTexture = new Dictionary<int, Texture2D>()
            {
                { 0, _content.Load<Texture2D>("Tile/terrain tiles") },
                { 1, _content.Load<Texture2D>("Tile/waterfalls") },
                { 2, _content.Load<Texture2D>("Tile/TX Props") },
                { 3, _content.Load<Texture2D>("Tile/Decorations") },
                { 4, _content.Load<Texture2D>("Tile/houses") }
            };
        }
        public void Unload()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime, String layersType)
        {
            var tileLayers = map.Layers.Where(x => x.type == TiledLayerType.TileLayer);
            switch (layersType)
            {
                case "PATH":
                    tileLayers = map.Layers.Where(x => x.type == TiledLayerType.TileLayer && x.name == "Main Layer" || x.name == "Sub Layer");
                    break;
                case "ACCENT":
                    tileLayers = map.Layers.Where(x => x.type == TiledLayerType.TileLayer && x.name == "Accent1" || x.name == "Accent2" || x.name == "Accent3");
                    break;
                default:
                    break;
            }
            foreach (var layer in tileLayers)
            {
                for (var y = 0; y < layer.height; y++)
                {
                    for (var x = 0; x < layer.width; x++)
                    {
                        var index = (y * layer.width) + x;
                        var gid = layer.data[index];
                        var tileX = x * map.TileWidth + 16;
                        var tileY = y * map.TileHeight + 20;
                        int textureIndex = 0;
                        if (gid == 0)
                        {
                            continue;
                        }
                        if (gid >= 1 && gid < 385)
                        {
                            textureIndex = 0;
                        }
                        if (gid >= 385 && gid < 721)
                        {
                            textureIndex = 1;
                        }
                        if (gid >= 721 && gid < 1745)
                        {
                            textureIndex = 2;
                        }
                        if (gid >= 1745 && gid < 2065)
                        {
                            textureIndex = 3;
                        }
                        if (gid >= 2065)
                        {
                            textureIndex = 4;
                        }
                        var mapTileset = map.GetTiledMapTileset(gid);
                        var tileset = tilesets[mapTileset.firstgid];
                        var rect = map.GetSourceRect(mapTileset, tileset, gid);
                        var source = new Rectangle(rect.x, rect.y, rect.width, rect.height);
                        var destination = new Rectangle(tileX, tileY, map.TileWidth, map.TileHeight);
                        Trans tileTrans = Trans.None;
                        if (map.IsTileFlippedHorizontal(layer, x, y)) tileTrans |= Trans.Flip_H;
                        if (map.IsTileFlippedVertical(layer, x, y)) tileTrans |= Trans.Flip_V;
                        if (map.IsTileFlippedDiagonal(layer, x, y)) tileTrans |= Trans.Flip_D;
                        SpriteEffects effects = SpriteEffects.None;
                        double rotation = 0f;
                        switch (tileTrans)
                        {
                            case Trans.Flip_H: effects = SpriteEffects.FlipHorizontally; break;
                            case Trans.Flip_V: effects = SpriteEffects.FlipVertically; break;

                            case Trans.Rotate_90:
                                rotation = Math.PI * .5f;
                                destination.X += map.TileWidth;
                                break;

                            case Trans.Rotate_180:
                                rotation = Math.PI;
                                destination.X += map.TileWidth;
                                destination.Y += map.TileHeight;
                                break;

                            case Trans.Rotate_270:
                                rotation = Math.PI * 3 / 2;
                                destination.Y += map.TileHeight;
                                break;

                            case Trans.Rotate_90AndFlip_H:
                                effects = SpriteEffects.FlipHorizontally;
                                rotation = Math.PI * .5f;
                                destination.X += map.TileWidth;
                                break;

                            default:
                                break;
                        }
                        _spriteBatch.Draw(tilesetTexture[textureIndex], destination, source, Color.White, (float)rotation, Vector2.Zero, effects, 0);
                    }
                }
            }
        }
    }
}
