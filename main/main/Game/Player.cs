using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine;

namespace Lecture4;
public class Player : SolidEntity
{
    private float speed = 2.5f;

    //input
    Vector2 desiredDirection = Vector2.Zero;

    public Player(Texture2D texture, Vector2 pos, Vector2 colliderOffset, Vector2 size) : base(texture, pos, colliderOffset, size)
    {
    }

    public override void Update(GameTime gameTime)
    {

        HandleInput();
        if(desiredDirection != Vector2.Zero)
        {
            desiredDirection.Normalize();
        }
        Move(desiredDirection*speed);
    }
    void HandleInput()
    {
        desiredDirection = Vector2.Zero;
        if (Input.IsInputEventDown(InputEvent.MoveRight))
        {
            desiredDirection.X += 1;
        }
        if (Input.IsInputEventDown(InputEvent.MoveLeft))
        {
            desiredDirection.X -= 1;
        }
        if (Input.IsInputEventDown(InputEvent.MoveDown))
        {
            desiredDirection.Y += 1;
        }
        if (Input.IsInputEventDown(InputEvent.MoveUp))
        {
            desiredDirection.Y -= 1;
        }
    }
}
