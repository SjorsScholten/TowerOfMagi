using System.Collections.Generic;

namespace ItemContainer.Entities {
    public class BaseItemContainer : IItemContainer<Item> {
        private readonly List<Item> _items = new List<Item>();
        
        public void AddItem(Item item) {
            _items.Add(item);
        }

        public void RemoveItem(Item item) {
            _items.Remove(item);
        }
    }
}