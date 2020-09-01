using Character.Controllers;

namespace Character.States {
    public abstract class Grounded : BaseCharacterState {
        protected Grounded(CharacterController controller) : base(controller) { }
        
        public override void FixedUpdate() {
            //if(Character.JumpRequest) Character.Controller.ProcessImpulse(Character.JumpForce * Vector3.up);
            controller.HandleCharacterMove(moveSpeed);
            base.FixedUpdate();
        }
    }
}