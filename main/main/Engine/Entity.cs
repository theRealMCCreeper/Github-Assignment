using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Entity
    {
        protected Scene scene;
        private Texture2D texture;

        public Vector2 pos { get; protected set; }
        public Entity(Texture2D texture)
        {
            this.texture = texture;
        }
        public Entity(Texture2D texture, Vector2 pos)
        {
            this.texture = texture;
            this.pos = pos;
        }
        public void SetScene(Scene scene)
        {
            this.scene = scene;
        }
        public virtual void Move(Vector2 movement)
        {
            pos += movement;
        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
        }
    }
}
