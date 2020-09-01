using Character.Controllers;

namespace Character.States {
    public class Walk : Grounded {
        
        public Walk(CharacterController controller) : base(controller) { }

        public override void OnEnter() {
            moveSpeed = 5f;
            base.OnEnter();
        }
    }
}