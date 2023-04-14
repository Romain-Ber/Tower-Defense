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
        public TiledMap map;
        private Dictionary<int, TiledTileset> tilesets;
        private Dictionary<int, Texture2D> tilesetTexture;
        public static string[,] groundPath;
        public static string[,] flyingPath;
        public static int mapTileWidth, mapTileHeight;
        public static int mapOffsetX = 16;
        public static int mapOffsetY = 20;
        public static int monsterStartX, monsterStartY;
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
        private float timerWaterFrame;
        private float nextWaterFrame;
        
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
            timerWaterFrame = 0;
            nextWaterFrame = 200f; //time between the different water frames in milliseconds
            mapTileWidth = 16;
            mapTileHeight = 16;
            CreateMonsterPath();
        }

        private void CreateMonsterPath()
        {
            //gidStart = 27, gidEnd = 30, gidDown = 51, gidUp = 3, gidRight = 28, gidLeft = 26
            var tempMap = map.Layers.Where(x => x.type == TiledLayerType.TileLayer && x.name == "GroundPath");
            foreach (var layer in tempMap)
            {
                groundPath = new string[layer.width, layer.height];
                for (var y = 0; y < layer.height; y++)
                {
                    for (var x = 0; x < layer.width; x++)
                    {
                        var index = (y * layer.width) + x;
                        var gid = layer.data[index];
                        switch (gid)
                        {
                            case 0:
                                groundPath[x, y] = "";
                                break;
                            case 27:
                                groundPath[x, y] = "START";
                                monsterStartX = x * mapTileWidth + mapOffsetX;
                                monsterStartY = y * mapTileHeight + mapOffsetY;
                                break;
                            case 30:
                                groundPath[x, y] = "END";
                                break;
                            case 3:
                                groundPath[x, y] = "UP";
                                break;
                            case 51:
                                groundPath[x, y] = "DOWN";
                                break;
                            case 26:
                                groundPath[x, y] = "LEFT";
                                break;
                            case 28:
                                groundPath[x, y] = "RIGHT";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            tempMap = map.Layers.Where(x => x.type == TiledLayerType.TileLayer && x.name == "FlyingPath");
            foreach (var layer in tempMap)
            {
                flyingPath = new string[layer.width, layer.height];
                for (var y = 0; y < layer.height; y++)
                {
                    for (var x = 0; x < layer.width; x++)
                    {
                        var index = (y * layer.width) + x;
                        var gid = layer.data[index];
                        switch (gid)
                        {
                            case 0:
                                flyingPath[x, y] = "";
                                break;
                            case 27:
                                flyingPath[x, y] = "START";
                                break;
                            case 30:
                                flyingPath[x, y] = "END";
                                break;
                            case 51:
                                flyingPath[x, y] = "DOWN";
                                break;
                            case 3:
                                flyingPath[x, y] = "UP";
                                break;
                            case 28:
                                flyingPath[x, y] = "RIGHT";
                                break;
                            case 26:
                                flyingPath[x, y] = "LEFT";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        public void Unload()
        {

        }

        private int WaterFrame()
        {
            if (timerWaterFrame < nextWaterFrame)
            {
                return 0;
            }
            if (timerWaterFrame > nextWaterFrame && timerWaterFrame < nextWaterFrame * 2)
            {
                return 1;
            }
            if (timerWaterFrame > nextWaterFrame * 2 && timerWaterFrame < nextWaterFrame * 3)
            {
                return 2;
            }
            if (timerWaterFrame > nextWaterFrame * 3)
            {
                timerWaterFrame = 0;
            }
            return 0;
        }

        public void Update(GameTime gameTime)
        {
            timerWaterFrame += gameTime.ElapsedGameTime.Milliseconds;
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
                        var tileX = x * map.TileWidth + mapOffsetX;
                        var tileY = y * map.TileHeight + mapOffsetY;
                        int textureIndex = 0;
                        if (gid == 0)
                        {
                            continue;
                        }
                        var mapTileset = map.GetTiledMapTileset(gid);
                        var tileset = tilesets[mapTileset.firstgid];
                        var rect = map.GetSourceRect(mapTileset, tileset, gid);
                        var source = new Rectangle(rect.x, rect.y, rect.width, rect.height);
                        var destination = new Rectangle(tileX, tileY, map.TileWidth, map.TileHeight);
                        if (gid >= 1 && gid < 385)
                        {
                            textureIndex = 0;
                        }
                        if (gid >= 385 && gid < 721)
                        {
                            textureIndex = 1;
                            source.Y += WaterFrame() * source.Height * 3;
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
