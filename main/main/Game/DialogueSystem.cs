using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Lecture4
{
    public class DialogueSystem
    {
        public bool inDialogue { get; private set; }
        private string currentDialogueLine = "";

        public DialogueSystem()
        {
            Services.DialogueSystem = this;
        }

        public void DisplayDialogue(string text)
        {
            inDialogue = true;
            currentDialogueLine = text;
            Debug.WriteLine(text);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
