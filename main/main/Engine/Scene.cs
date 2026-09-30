
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace Engine
{
    public class Scene
    {
        public static Texture2D pixelTexture;


        private List<Entity> entities;
        private List<Entity> deadEntities;

        protected Grid grid;

        #region scene changing
        public bool newSceneDesired { get; private set; }
        public string nextScene { get; private set; }
        #endregion
        public Scene()
        {
            entities = new List<Entity>();
            deadEntities = new List<Entity>();
            grid = new Grid();
        }
        public Scene(string levelName)
        {
            entities = new List<Entity>();
            deadEntities = new List<Entity>();
            grid = new Grid();
            string levelContent = LoadLevelFile(levelName);
            if(levelContent != "")
            {
                ParseLevelString(levelContent);
            }
        }
        public void Close()
        {
            newSceneDesired = false;
            nextScene = string.Empty;
        }
        void ParseLevelString(string levelString)
        {
            string[] lines = levelString.Split('\n');
            for(int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                for(int x = 0; x < line.Length; x++)
                {
                    char c = line[x];
                    Point p = new Point(x, y);
                    Tile tile = Tile.None;
                    if (grid.HasTileDefined(c))
                    {
                        tile = grid.ConvertFromChar(c);
                    }
                    if(ConvertCharToEntity(c, grid.GridPointToPixelVector(p)))
                    {
                        tile = Tile.Floor;
                    }

                    if (tile != Tile.None)
                    {
                        grid.SetTile(p, tile);
                    }
                    

                }
            }
        }
        protected virtual bool ConvertCharToEntity(char c,Vector2 pixelPosition)
        {
            return false;
        }
        string LoadLevelFile(string fileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", fileName);
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                return content;
            }
            else
            {
                Debug.WriteLine($"{filePath} doesn't exist");
                return "";
            }
        }
        public void AddEntity(Entity entity)
        {
            entity.SetScene(this);
            entities.Add(entity);
        }
        public void RemoveEntity(Entity entity)
        {
            deadEntities.Add(entity);
        }
        public void ChangeToNewScene(string sceneName)
        {
            nextScene = sceneName;
            newSceneDesired = true;
        }
        #region handle collision interactions
        public bool OverlapOtherSolidEntityCheck(SolidEntity me, ColliderTag tagToCheck = ColliderTag.None)
        {
            foreach (Entity entity in entities)
            {
                if (entity == me) { continue; }
                if (entity is SolidEntity solid)
                {
                    if (tagToCheck != ColliderTag.None)
                    {
                        if (solid.tag == tagToCheck)
                        {
                            continue;
                        }
                    }
                    if (me.GetCollider().Intersects(solid.GetCollider()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool OverlapGridCheck(SolidEntity me)
        {
            if (grid.DoesRectangleOverlapSolid(me.GetCollider()))
            {
                return true;
            }
            return false;
        }
        public List<ColliderEntity> GetColliderEntitiesWithinCollider(Rectangle collider)
        {
            List<ColliderEntity> overlappers = new List<ColliderEntity>();
            foreach (Entity entity in entities)
            {
                if(entity is ColliderEntity solid)
                {
                    if (solid.GetCollider().Intersects(collider))
                    {
                        overlappers.Add(solid);
                    }
                }
            }
            return overlappers;
        }
        #endregion
        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(gameTime);
            }
            foreach(Entity deadEntity in deadEntities)
            {
                entities.Remove(deadEntity);
            }
            deadEntities.Clear();
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            grid.Draw(spriteBatch);
            foreach (Entity entity in entities)
            {
                entity.Draw(spriteBatch);
            }
        }
    }
}