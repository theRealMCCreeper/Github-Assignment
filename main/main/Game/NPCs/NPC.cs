using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Engine;

namespace Lecture4;
public class NPC : SolidEntity
{
    public static NPC CreateNPC(Vector2 pos, string name)
    {
        NPC npc = null;
        switch (name)
        {
            case "rabbit":
                npc = new NPC_Rabbit(pos);
                break;
            case "turtle":
                npc = new NPC_Turtle(pos);
                break;
        }
        if(npc == null)
        {
            Debug.WriteLine($"error: npc {name} is not defined");
            return null;
        }
        
        return npc;
    }
    private string name;
    protected string dialogue = "";
    public NPC(Texture2D texture, Vector2 pos, string name) : base(texture, pos, Vector2.Zero, new Vector2(128, 128))
    {
        this.name = name;
    }
    public void SetDialogue(string dialogue)
    {
        this.dialogue = dialogue;
    }

    public virtual void TalkTo()
    {
        Services.DialogueSystem.DisplayDialogue(dialogue);
    }
}
