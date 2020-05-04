using Character.Entities;

namespace Character.States {
    public class Idle : Grounded {
        
        public Idle(Entities.Character character) : base(character) { }
        
        public override void OnEnter() {
            base.OnEnter();
            //set animation to idle
        }
    }
}