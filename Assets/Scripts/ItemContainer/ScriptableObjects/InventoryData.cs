using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects {
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
    public class InventoryData : ScriptableObject {
        public List<Item> items = new List<Item>();
    }
}