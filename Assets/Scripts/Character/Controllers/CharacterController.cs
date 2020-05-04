using Character.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;
using Util;
using Util.Variables;

namespace Character.Controllers {
    public class CharacterController : Entity {
        [SerializeField] private CharacterData initialData;
        
        private Entities.Character _character;
        public Vector2 direction;
        
        protected override void Initialize() {
            _character = new Entities.Character(this, initialData);
            
            myRigidbody.mass = initialData.Mass;
        }

        private void Update() {
        }

        private void FixedUpdate() {
            UpdatePhysics();
            _character.Move(direction, myRigidbody.velocity.Horizontal().magnitude, Time.deltaTime);
            _character.StateMachine.FixedUpdate();
        }

        public void HandleMove(InputAction.CallbackContext context) {
            direction = context.ReadValue<Vector2>();
        }

        public void HandleAttack(InputAction.CallbackContext context) {
            if(context.performed) _character.LightAttack();
        }

        public void HandleJump(InputAction.CallbackContext context) {
            if(context.performed) _character.Jump();
        }

        public void ProcessForce(Vector3 force) {
            if (force == Vector3.zero) return;
            myRigidbody.AddForce(force, ForceMode.Force);
        }

        public void ProcessImpulse(Vector3 force) {
            if (force == Vector3.zero) return;
            myRigidbody.AddForce(force, ForceMode.Impulse);
        }

        private void UpdatePhysics() {
            _character.IsGrounded = true; //TODO: implement ground check
        }
    }
}
