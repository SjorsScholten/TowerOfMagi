using System;
using UnityEngine;

namespace Util.Timers {
    [Serializable]
    public class Timer {
        
        public float initialTime = 0f;
        public float timeScale = 1f;
        public bool countDown = false;
        
        [SerializeField] private bool enableTick = false;
        [SerializeField] private float tickTime = 0f;

        private float _currentTime = 0f;
        private float _timeLastTick = 0f;

        private bool _awake = false;
        private bool _paused = false;

        public event Action OnTimerStart;
        public event Action OnTimerTick;
        public event Action OnTimerEnd;

        
        public Timer(float initialTime = 0f, bool countDown = false) {
            this.initialTime = initialTime;
            _currentTime = this.initialTime;
            this.countDown = countDown;
        }
        
        public void Update(float deltaTime) {
            if(!_awake) return;
            Alter(deltaTime * timeScale * (countDown ? -1 : 1));
            CheckTimerTick();
            CheckTimerEnd();
        }

        
        private void CheckTimerTick() {
            if (!enableTick || !(_currentTime > _timeLastTick + tickTime)) return;
            _timeLastTick = _currentTime;
            OnTimerTick?.Invoke();
        }

        private void CheckTimerEnd() {
            if(_currentTime > 0) return;
            Stop();
        }

        
        public void Start() {
            if(_awake) return;
            _currentTime = initialTime;
            _awake = true;
            OnTimerStart?.Invoke();
        }
        
        public void Stop() {
            if(!_awake) return;
            _awake = false;
            OnTimerEnd?.Invoke();
        }
        
        public void Pause() => _awake = false;

        public void Resume() => _awake = true;
        

        public void Reset() {
            _awake = false;
            _currentTime = initialTime;
        }

        public void Alter(float amount) => _currentTime += amount;
        
        public float CurrentTime => _currentTime;
        
        public bool IsAwake => _awake;

        public void SetCallbacks(ITimerCallbacks timer) {
            OnTimerStart += timer.OnTimerStart;
            OnTimerEnd += timer.OnTimerEnd;
            OnTimerTick += timer.OnTimerTick;
        }

        public void RemoveCallbacks(ITimerCallbacks timer) {
            OnTimerStart -= timer.OnTimerStart;
            OnTimerEnd -= timer.OnTimerEnd;
            OnTimerTick -= timer.OnTimerTick;
        }
    }
}