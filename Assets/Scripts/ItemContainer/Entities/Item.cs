using System;
using ScriptableObjects;

[Serializable]
public class Item {
    public readonly ItemData _data;
    public int itemAmount = 0;

    public Item(ItemData data) {
        this._data = data;
    }

    public bool CanAddStack(Item item) {
        //TODO: implement Item Stack constraint
        return false;
    }
}