using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Lecture4
{
    public enum Item
    {
        Hammer,
        Violin
    }

    public class InventorySystem
    {
        private List<Item> items = new List<Item>();

        public InventorySystem()
        {
            Services.InventorySystem = this;
        }
        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public bool HasItem(Item item)
        {
            return items.Contains(item);
        }
        public void RemoveItem(Item item)
        {
            if (HasItem(item))
            {
                items.Remove(item);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
