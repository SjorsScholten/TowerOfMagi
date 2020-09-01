using System;

namespace Util.Variables {
    public class IndexCycle {
        public int Index { get; set; } = 0;
        private readonly int _length = 0;

        public event Action OnIndexChanged;

        public IndexCycle(int length) {
            _length = length;
        }

        public void Next() {
            if(!CheckLength()) return;
            Index++;
            if (Index > _length - 1) Index = 0;
            OnIndexChanged?.Invoke();
        }

        public void Previous() {
            if(!CheckLength()) return;
            Index--;
            if (Index < 0) Index = _length - 1;
            OnIndexChanged?.Invoke();
        }

        private bool CheckLength() {
            switch (_length) {
                case 0:
                    return false;
                case 1:
                    Index = 0;
                    return false;
                default:
                    return true;
            }
        }

        public static implicit operator int(IndexCycle v) => v.Index;
    }
}