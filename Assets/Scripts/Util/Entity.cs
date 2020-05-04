using UnityEngine;

namespace Util {
    public abstract class Entity : MonoBehaviour {
        [HideInInspector] public GameObject myGameObject;
        [HideInInspector] public Transform myTransform;
        [HideInInspector] public Rigidbody myRigidbody;

        private void Awake() {
            myGameObject = this.gameObject;
            
            myTransform = GetComponent<Transform>();

            myRigidbody = GetComponent<Rigidbody>();
            if(!myRigidbody) myRigidbody = myGameObject.AddComponent<Rigidbody>();
            
            Initialize();
        }
        
        protected abstract void Initialize();
    }
}