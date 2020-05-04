using System;
using Controllers;
using ItemContainer;
using ScriptableObjects;

[Serializable]
public class RestrictedInventory : IItemContainer<Item> {
    private readonly InventoryData _data;

    public RestrictedInventory(InventoryData data) {
        this._data = data;
    }

    public void AddItem(Item item) {
        _data.items.Add(item);
    }

    public void RemoveItem(Item item) {
        _data.items.Remove(item);
    }

    private bool CanAddItem(Item item) {
        //TODO: implement inventory constraints
        return true;
    }
}