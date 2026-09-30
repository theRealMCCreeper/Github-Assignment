using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lecture4
{
    public enum HorizontalAlign{Left, Right};
    public enum VerticalAlign{Top, Bottom};
    public class TextBox : Entity
    {
        private string text;
        private HorizontalAlign hAlign;
        private VerticalAlign vAlign;
        public TextBox(Vector2 pos, string text,HorizontalAlign hAlign = HorizontalAlign.Left, VerticalAlign vAlign = VerticalAlign.Top) : base(Scene.pixelTexture,pos)
        {
            this.text = text;
            this.hAlign = hAlign;
            this.vAlign = vAlign;
        }
        public void SetText(string text)
        {
            this.text = text;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 drawPos = pos;
            SpriteFont font = Services.AssetManager.font;
            Vector2 textSize = font.MeasureString(text);
            if(hAlign == HorizontalAlign.Right)
            {
                drawPos.X -= textSize.X;
            }
            if(vAlign == VerticalAlign.Bottom)
            {
                drawPos.Y -= textSize.Y;
            }
            Rectangle box = new Rectangle((int)drawPos.X, (int)drawPos.Y, (int)textSize.X, (int)textSize.Y);
            spriteBatch.Draw(Scene.pixelTexture, box, Color.Black);

            spriteBatch.DrawString(font, text, drawPos, Color.White);

            
        }
    }
}
