using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Engine
{
    public enum Tile
    {
        None,
        Floor,
        Wall
    }
    public class Grid
    {
        const int TileSize = 64;


        private Dictionary<char, Tile> tileChars = new Dictionary<char, Tile>()
        {
            {'#',Tile.Wall },
            {'_',Tile.Floor }
        };
        private Dictionary<Tile, Color> tileColors = new Dictionary<Tile, Color>()
        {
            {Tile.Floor,Color.DarkBlue },
            {Tile.Wall,Color.Black }
        };
        private Dictionary<Tile, bool> tileSolid = new Dictionary<Tile, bool>()
        {
            {Tile.Floor,false },
            {Tile.Wall,true }
        };

        private Dictionary<Point, Tile> tiles;

        public Grid()
        {
            tiles = new Dictionary<Point, Tile>();
        }
        public bool HasTileDefined(Char c)
        {
            return tileChars.ContainsKey(c);
        }
        public Tile ConvertFromChar(Char c)
        {
            if (HasTileDefined(c) == false)
            {
                return Tile.None;
            }
            return tileChars[c];
        }
        public void SetTile(Point p, Tile tile)
        {
            if (tiles.ContainsKey(p))
            {
                tiles[p] = tile;
            }
            else
            {
                tiles.Add(p, tile);
            }
        }
        public void SetTile(int x, int y, Tile tile)
        {
            SetTile(new Point(x, y), tile);
        }
        public void ClearTile(Point p)
        {
            if (tiles.ContainsKey(p))
            {
                tiles.Remove(p);
            }
        }
        public void ClearTile(int x, int y)
        {
            ClearTile(new Point(x, y));
        }
        
        public Vector2 GridPointToPixelVector(Point gridPoint)
        {
            return new Vector2(gridPoint.X*TileSize,gridPoint.Y*TileSize);
        }
        public Point PixelVectorToGridPoint(Vector2 pixelPos)
        {
            Point gridPoint = Point.Zero;
            gridPoint.X = (int)Math.Floor(pixelPos.X / TileSize);
            gridPoint.Y = (int)Math.Floor(pixelPos.Y / TileSize);
            return gridPoint;
        }
        public bool IsTileSolid(Point gridPoint)
        {
            if (tiles.ContainsKey(gridPoint))
            {
                Tile tile = tiles[gridPoint];
                return tileSolid[tile];
            }
            return false;
        }
        public bool IsTileSolid(Vector2 pixelPos)
        {
            return IsTileSolid(PixelVectorToGridPoint(pixelPos));
        }
        public bool DoesRectangleOverlapSolid(Rectangle entityCollider)
        {
            Point topLeft = PixelVectorToGridPoint(new Vector2(entityCollider.Left, entityCollider.Top));
            Point bottomRight = PixelVectorToGridPoint(new Vector2(entityCollider.Right, entityCollider.Bottom));
            for(int x = topLeft.X; x <= bottomRight.X; x++)
            {
                for(int y = topLeft.Y; y <= bottomRight.Y; y++)
                {
                    Point tilePoint = new Point(x, y);
                    if (IsTileSolid(tilePoint))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            MouseState mouseState = Mouse.GetState();
            Vector2 mousePos = new Vector2(mouseState.X,mouseState.Y);
            Point gridPoint = PixelVectorToGridPoint(mousePos);
            foreach(Point p in tiles.Keys)
            {   
                Rectangle destinationRectangle = new Rectangle(p.X*TileSize, p.Y*TileSize, TileSize, TileSize);
                Tile tile = tiles[p];
                Color color = tileColors[tile];
                /*if(p == gridPoint)
                {
                    color = Color.Red;
                }*/
                spriteBatch.Draw(Scene.pixelTexture, destinationRectangle,color);
            }
        }
    }
}
