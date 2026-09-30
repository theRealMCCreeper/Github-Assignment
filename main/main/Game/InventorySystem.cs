using Microsoft.Xna.Framework;
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
        private static Dictionary<Item, Art> itemArt = new Dictionary<Item, Art>()
        {
            {Item.Hammer, Art.Hammer},
            {Item.Violin, Art.Violin},
        };
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
            int horizontalDistance = 32;
            for(int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                Point p = new Point(i * horizontalDistance, 0);
                spriteBatch.Draw(Services.AssetManager.GetTexture(itemArt[item]), new Rectangle(p, new Point(32, 32)), Color.White);
            }
        }
    }
}
