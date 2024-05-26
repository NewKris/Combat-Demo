using System;

namespace CoffeeBara.Gameplay.Common.HierarchicalStateMachine {
    public class Transition<T> {
        public event Action<State<T>> OnTransitionTriggered; 
        
        public delegate bool TransitionCondition(T dependency);

        private readonly bool _hasTrigger;
        private readonly bool _hasCondition;
        private readonly Trigger _trigger;
        private readonly State<T> _toState;
        private readonly T _dependency;
        private readonly TransitionCondition _condition;

        public State<T> ToState => _toState;

        internal Transition(
            Trigger trigger,
            State<T> toState,
            T dependency,
            TransitionCondition condition
        ) {
            _hasTrigger = trigger != null;
            _hasCondition = condition != null;
            
            _trigger = trigger;
            _toState = toState;
            _dependency = dependency;
            _condition = condition;
        }

        public static TransitionBuilder<T> GetBuilder() {
            return new TransitionBuilder<T>();
        }
        
        public bool Evaluate() {
            if (_hasTrigger || !_hasCondition) {
                return false;
            }
            
            return _condition.Invoke(_dependency);
        }

        public void Activate() {
            if (!_hasTrigger) {
                return;
            }
            
            _trigger.OnTriggered += OnTriggered;
        }

        public void DeActivate() {
            if (!_hasTrigger) {
                return;
            }
            
            _trigger.OnTriggered -= OnTriggered;
        }

        private void OnTriggered() {
            if (!_hasCondition || _condition.Invoke(_dependency)) {
                OnTransitionTriggered?.Invoke(_toState);
            }
        }
    }
}