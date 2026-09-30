using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lecture4
{

    public class DialogueSystem
    {
        public bool inDialogue { get; private set; }
        private string currentDialogueLine = "";
        private float remainingLineTime = 0;
        private float timePerLine = 2;

        private TextBox textBox;

        public DialogueSystem()
        {
            Services.DialogueSystem = this;
            textBox = new TextBox(new Vector2(0, Game1.ScreenSize.Y), "", HorizontalAlign.Left, VerticalAlign.Bottom);
        }


        public void DisplayDialogue(string text)
        {
            inDialogue = true;
            currentDialogueLine = text;
            remainingLineTime = timePerLine;
            SetText(currentDialogueLine);
        }
        private void SetText(string text)
        {
            textBox.SetText(text);
        }
        void EndDialogue()
        {
            inDialogue = false;
            SetText("");
        }
        public void Update(GameTime gameTime)
        {
            if (inDialogue)
            {
                remainingLineTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(remainingLineTime <= 0)
                {
                    EndDialogue();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            textBox.Draw(spriteBatch);
        }
    }
}
