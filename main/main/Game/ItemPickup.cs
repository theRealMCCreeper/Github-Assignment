using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine;

namespace Lecture4;
public class ItemPickup : ColliderEntity
{
    private Item item;
    public ItemPickup(Texture2D texture, Vector2 pos) : base(texture, pos, Vector2.Zero, new Vector2(64, 64))
    {
        
    }
    public void SetItem(Item item)
    {
        this.item = item;
    }
    public void PickUp()
    {
        Services.InventorySystem.AddItem(item);
        scene.RemoveEntity(this);
    }
}
