using ScriptableObjects;
using UnityEngine;

namespace Controllers {
    public class InventoryController : MonoBehaviour {
        [SerializeField] private InventoryData initialInventoryData = null;
    
        private RestrictedInventory _restrictedInventory;

        private void Start() {
            _restrictedInventory = new RestrictedInventory(initialInventoryData);
        }

        public void HandleAddItem(ItemData item) {
            _restrictedInventory.AddItem(new Item(item));
        }
    }
}