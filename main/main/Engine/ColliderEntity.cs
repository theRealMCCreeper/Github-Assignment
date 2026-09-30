using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum ColliderTag
    {
        None,
        Player,
        Enemy
    }
    public class ColliderEntity : Entity
    {
        private bool debugDraw = true;
        private Vector2 colliderOffset;
        private Vector2 colliderSize;
        public ColliderTag tag { get; protected set; } = ColliderTag.None;


        public ColliderEntity(Texture2D texture, Vector2 pos,Vector2 colliderOffset, Vector2 size) : base(texture,pos)
        {
            this.colliderOffset = colliderOffset;
            colliderSize = size;
        }
        public void SetTag(ColliderTag tag)
        {
            this.tag = tag;
        }
        public Rectangle GetCollider()
        {
            return new Rectangle((int)(pos.X + colliderOffset.X), (int)(pos.Y + colliderOffset.Y), (int)colliderSize.X, (int)colliderSize.Y);
        }
        public bool IsVectorWithinCollider(Vector2 pos)
        {
            return GetCollider().Contains(pos);
        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (debugDraw)
            {
                spriteBatch.Draw(Scene.pixelTexture, GetCollider(), new Color(1.0f, 0f, 0f, 0.3f));
            }
        }
    }
}
