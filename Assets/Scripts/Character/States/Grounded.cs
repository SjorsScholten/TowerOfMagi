using Character.Entities;
using UnityEngine;

namespace Character.States {
    public abstract class Grounded : BaseCharacterState {
        protected Grounded(Entities.Character character) : base(character) { }
        
        public override void FixedUpdate() {
            if(Character.JumpRequest) Character.Controller.ProcessImpulse(Character.JumpForce * Vector3.up);
            Character.Controller.ProcessForce(Character.MoveForce * Character.MoveDirection);
            
            base.FixedUpdate();
        }
    }
}