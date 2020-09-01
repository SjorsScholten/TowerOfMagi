using Character.Controllers;
using Character.Entities;
using Util.StatePattern;

namespace Character.States {
    public abstract class BaseCharacterState : IState {
        protected CharacterController controller;

        protected float moveSpeed = 0;

        public BaseCharacterState(CharacterController controller) {
            controller = controller;
        }
        
        public virtual void OnEnter() { }

        public virtual void OnExit() { }

        public virtual void HandleInput() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }
    }
}