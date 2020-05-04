using Character.Entities;
using Util.StatePattern;

namespace Character.States {
    public abstract class BaseCharacterState : IState {
        protected Entities.Character Character;

        public BaseCharacterState(Entities.Character character) {
            Character = character;
        }
        
        public virtual void OnEnter() { }

        public virtual void OnExit() { }

        public virtual void HandleInput() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }
    }
}