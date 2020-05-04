using System.Collections.Generic;
using UnityEngine;

namespace Util {
    public class GameObjectPool<TObject> : Singleton<GameObjectPool<TObject>> where TObject : Entity {
        [SerializeField] private int startAmount = 0;
        [SerializeField] private TObject prefab = null;
        private readonly Queue<TObject> _objects = new Queue<TObject>();

        protected virtual void Awake() {
            AddObject(startAmount);
        }

        public TObject Get() {
            if (_objects.Count == 0) AddObject();
            return _objects.Dequeue();
        }

        public void AddObject(int count = 1) {
            for (var x = 0; x < count; x++) {
                var newObject = Instantiate(prefab, this.transform);
                newObject.gameObject.SetActive(false);
                _objects.Enqueue(newObject);
            }
        }

        public void ReturnToPool(TObject obj) {
            obj.gameObject.SetActive(false);
            _objects.Enqueue(obj);
        }
    }
}