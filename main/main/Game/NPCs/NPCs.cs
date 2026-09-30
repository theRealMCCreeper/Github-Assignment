using Microsoft.Xna.Framework;
using Engine;

namespace Lecture4;
public class NPC_Rabbit : NPC
{
    public NPC_Rabbit(Vector2 pos) : base(Services.AssetManager.GetTexture(Art.Rabbit), pos, "rabbit")
    {
        
        dialogue = "i am rabbit";
    }

    public override void TalkTo()
    {
        string line = dialogue;
        Services.DialogueSystem.DisplayDialogue(line);
    }
}
public class NPC_Turtle : NPC
{
    public NPC_Turtle(Vector2 pos) : base(Services.AssetManager.GetTexture(Art.Turtle), pos, "turtle")
    {

        dialogue = "second turtle? geez";
    }

    public override void TalkTo()
    {
        string line = dialogue;
        if (Services.InventorySystem.HasItem(Item.Violin))
        {
            line = "what a beautiful instrument!";
        }
        Services.DialogueSystem.DisplayDialogue(line);
    }
}
