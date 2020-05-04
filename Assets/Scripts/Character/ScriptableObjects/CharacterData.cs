using UnityEngine;

namespace Character.ScriptableObjects {
    [CreateAssetMenu(fileName = "New Character", menuName = "Entity/Character")]
    public class CharacterData : ScriptableObject {
        [SerializeField] private StatBlock stats = new StatBlock();
        [SerializeField] private float mass = 60;

        public StatBlock Stats => stats;

        public float Mass => mass;
    }
}