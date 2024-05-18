namespace CoffeeBara.Gameplay.Common.FiniteStateMachine {
    public class TransitionBuilder<T> {
        private Trigger _trigger;
        private State<T> _toState;
        private T _dependency;
        private Transition<T>.TransitionCondition _condition;
        
        internal TransitionBuilder() {}

        public Transition<T> Build() {
            return new Transition<T>(_trigger, _toState, _dependency, _condition);
        }

        public TransitionBuilder<T> SetTrigger(Trigger trigger) {
            _trigger = trigger;
            return this;
        }

        public TransitionBuilder<T> ToState(State<T> toState) {
            _toState = toState;
            return this;
        }

        public TransitionBuilder<T> Dependency(T dependency) {
            _dependency = dependency;
            return this;
        }

        public TransitionBuilder<T> Condition(Transition<T>.TransitionCondition condition) {
            _condition = condition;
            return this;
        }
    }
}