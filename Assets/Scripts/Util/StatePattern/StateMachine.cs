using System;
using System.Collections.Generic;

namespace Util.StatePattern {
    
    public class StateMachine {
        private IState _state;
        private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type,List<Transition>>();
        private List<Transition> _currentTransition = new List<Transition>();
        private List<Transition> _anyTransitions = new List<Transition>();
        private static List<Transition> EmptyTransitions = new List<Transition>(0);

        public void Update() {
            var transition = GetTransition();
            if(transition != null) ChangeState(transition.To);
            
            _state.Update();
        }

        public void FixedUpdate() => _state.FixedUpdate();
        
        public void ChangeState(IState newState) {
            if (_state == newState) return;
            
            _state?.OnExit();
            _state = newState;

            _transitions.TryGetValue(_state.GetType(), out _currentTransition);
            if (_currentTransition == null) _currentTransition = EmptyTransitions;
            
            _state?.OnEnter();
        }

        public void AddTransition(IState state, Func<bool> predicate) => _anyTransitions.Add(new Transition(state, predicate));

        public void AddTransition(IState from, IState to, Func<bool> predicate) {
            if (_transitions.TryGetValue(from.GetType(), out var transitions) == false) {
                transitions = new List<Transition>();
                _transitions[from.GetType()] = transitions;
            }
            
            transitions.Add(new Transition(to, predicate));
        }

        private class Transition {
            public Func<bool> Condition { get; }
            public IState To { get; }

            public Transition(IState to, Func<bool> condition) {
                To = to;
                Condition = condition;
            }
        }

        private Transition GetTransition() {
            foreach (var transition in _anyTransitions) {
                if (transition.Condition()) return transition;
            }

            foreach (var transition in _currentTransition) {
                if (transition.Condition()) return transition;
            }

            return null;
        }
    }
}