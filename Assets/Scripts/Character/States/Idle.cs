using Character.Controllers;

namespace Character.States {
    public class Idle : Grounded {
        
        public Idle(CharacterController controller) : base(controller) { }
        
        public override void OnEnter() {
            base.OnEnter();
            //set animation to idle
        }
    }
}