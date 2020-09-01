using UnityEngine;

namespace Utility.Scripts {
    public class LifterSphere : MonoBehaviour {
        private float _min = 0.25f, _max = 0.5f;
        private float maxSpeed = 10f;
        private float vel = Physics.gravity.y;
    
        private Rigidbody _rigidbody;
        private SphereCollider _collider;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<SphereCollider>();
        }

        private void FixedUpdate() {
            UpdateSphereSize(); //set on grounded event;
        }

        private void UpdateSphereSize() {
            var verticalVelocity = Mathf.Clamp(_rigidbody.velocity.y, -10f, 0);
            _collider.radius = _max - ((_max - _min) / maxSpeed) * Mathf.Abs(verticalVelocity);
        }
    }
}
