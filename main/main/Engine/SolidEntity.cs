using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{

    public class SolidEntity : ColliderEntity
    {
        public SolidEntity(Texture2D texture, Vector2 pos,Vector2 colliderOffset, Vector2 size) : base(texture,pos,colliderOffset,size)
        {

        }
        public override void Move(Vector2 movement)
        {
            base.Move(movement);
            if (scene.OverlapOtherSolidEntityCheck(this) || scene.OverlapGridCheck(this))
            {
                pos -= movement;
            }
        }
    }
}
