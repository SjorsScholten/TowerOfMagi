using UnityEngine;

namespace ScriptableObjects {
    [CreateAssetMenu(fileName = "New Item", menuName = "Item")]
    public class ItemData : ScriptableObject {
        [SerializeField] private new string name = "default item name";
        [SerializeField] private string description = "this is the default placeholder item description";
        [SerializeField] private Sprite icon = null;
    }
}