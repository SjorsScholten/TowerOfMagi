namespace Util.Variables {
    public class PullResetValue<T> {
        private readonly T _initialValue;
        private T _currentValue;

        public PullResetValue(T initialValue) => this._initialValue = initialValue;

        public T Value {
            get {
                var value = _currentValue;
                _currentValue = _initialValue;
                return value;
            }
            set => _currentValue = value;
        }

        public T Peek() => _currentValue;
    }
}