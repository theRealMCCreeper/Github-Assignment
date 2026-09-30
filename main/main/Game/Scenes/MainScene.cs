using Microsoft.Xna.Framework;
using Engine;

namespace Lecture4
{
    public class MainScene : Scene
    {
        public MainScene(string levelName) : base(levelName)
        {
        }

        protected override bool ConvertCharToEntity(char c, Vector2 pixelPosition)
        {
            switch (c)
            {
                case '@':
                    AddEntity(new Player(Services.AssetManager.GetTexture(Art.Turtle), pixelPosition, Vector2.Zero, new Vector2(128, 128)));
                    return true;
            }
            return false;
        }
    }
}
