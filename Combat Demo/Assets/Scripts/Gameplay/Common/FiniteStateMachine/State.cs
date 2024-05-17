using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.Common.FiniteStateMachine {
    public class State<T> {
        public event Action<State<T>> OnExitState;

        private readonly Action<T> _onEnter;
        private readonly Action<T> _onExit;
        private readonly Action<T> _onTick;

        private Transition<T>[] _transitions;

        public string StateName { get; }

        internal State(
            string stateName,
            Action<T> onEnter,
            Action<T> onExit,
            Action<T> onTick
        ) {
            StateName = stateName;
            _onEnter = onEnter;
            _onExit = onExit;
            _onTick = onTick;
        }

        public static StateBuilder<T> GetBuilder() {
            return new StateBuilder<T>();
        }

        public void SetTransitions(params Transition<T>[] transitions) {
            _transitions = transitions;
        }

        public void Enter(T dependency) {
            EnableTransitions(_transitions);
            _onEnter?.Invoke(dependency);
        }
        
        public void Exit(T dependency) {
            DisableTransitions(_transitions);
            _onExit?.Invoke(dependency);
        }

        public void Tick(T dependency) {
            _onTick?.Invoke(dependency);
        }

        public void TryTransition() {
            if (_transitions == null) return;
            
            foreach (Transition<T> transition in _transitions) {
                if (transition.Evaluate()) {
                    ExitState(transition.ToState);
                    break;
                }
            }
        }
        
        private void EnableTransitions(Transition<T>[] transitions) {
            if (transitions == null) {
                return;
            }

            foreach (Transition<T> transition in transitions) {
                transition.OnTransitionTriggered += ExitState;
                transition.Activate();
            }
        }

        private void DisableTransitions(Transition<T>[] transitions) {
            if (transitions == null) {
                return;
            }
            
            foreach (Transition<T> transition in transitions) {
                transition.OnTransitionTriggered -= ExitState;
                transition.DeActivate();
            }
        }

        private void ExitState(State<T> toState) {
            OnExitState?.Invoke(toState);
        }
    }
}