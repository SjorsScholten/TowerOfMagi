using System;
using Character.ScriptableObjects;
using Character.States;
using UnityEngine;
using UnityEngine.InputSystem;
using Util;
using Util.StatePattern;
using Util.Variables;

namespace Character.Controllers {
    public class CharacterController : Entity {
        [SerializeField] private CharacterData initialData;
        
        private Entities.Character _character;
        public Vector2 direction;
        
        protected override void Initialize() {
            _character = new Entities.Character(this, initialData);
            
            myRigidbody.mass = initialData.Mass;
            
            //initialize states
            var idle = new Idle(this);
            var walk = new Walk(this);
            var run = new Running(this);

            void AT(IState from, IState to, Func<bool> condition) => _character.StateMachine.AddTransition(from, to, condition);
            
            //Add Transitions
            AT(idle, walk, StartMoving());
            AT(walk, idle, StopMoving());
            
            //Conditions
            Func<bool> StartMoving() => () => MoveForce > 0f;
            Func<bool> StopMoving() => () => MoveForce < 0.01f;
            
            _character.StateMachine.ChangeState(idle);
        }

        private void Update() {
        }

        private void FixedUpdate() {
            UpdatePhysics();
            _character.StateMachine.FixedUpdate();
        }

        #region Input Handling

        public void HandleMove(InputAction.CallbackContext context) {
            direction = context.ReadValue<Vector2>();
        }

        public void HandleAttack(InputAction.CallbackContext context) {
            if(context.performed) _character.LightAttack();
        }

        public void HandleJump(InputAction.CallbackContext context) {
            //if(context.performed) _character.Jump();
        }

        #endregion


        public void HandleCharacterMove(float finalSpeed) {
            _character.Move(direction, myRigidbody.velocity.Horizontal().magnitude, Time.fixedDeltaTime, finalSpeed);
        }

        public void ProcessForce(Vector3 force, ForceMode mode = ForceMode.Force) => myRigidbody.AddForce(force, mode);

        private void UpdatePhysics() {
            _character.IsGrounded = GroundCheck();
            _character.CanWalk = (direction.magnitude > 0) && _character.IsGrounded;
        }

        private bool GroundCheck() {
            return true; //TODO: implement ground check for 3d enviroment
        }
    }
}
