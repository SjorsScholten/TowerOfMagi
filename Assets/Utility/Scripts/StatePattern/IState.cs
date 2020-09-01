namespace Util.StatePattern {
    public interface IState {
        void OnEnter();
        void OnExit();
        void HandleInput();
        void Update();
        void FixedUpdate();

    }
}