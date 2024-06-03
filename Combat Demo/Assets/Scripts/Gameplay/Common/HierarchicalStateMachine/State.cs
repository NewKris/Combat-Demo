using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.Common.HierarchicalStateMachine {
    public class State<T> {
        public event Action<State<T>> OnExitState;

        private readonly Action<T> _onEnter;
        private readonly Action<T> _onExit;
        private readonly Action<T> _onTick;
        private readonly StateMachine<T> _innerStateMachine;

        private bool _enabled;
        private bool _hasTransitions;
        private Transition<T>[] _transitions;

        public string StateName { get; }

        internal State(
            string stateName,
            Action<T> onEnter,
            Action<T> onExit,
            Action<T> onTick,
            StateMachine<T> innerStateMachine
        ) {
            StateName = stateName;
            _onEnter = onEnter;
            _onExit = onExit;
            _onTick = onTick;
            _innerStateMachine = innerStateMachine;
            
            _enabled = false;
            _hasTransitions = false;
        }

        public static StateBuilder<T> GetBuilder() {
            return new StateBuilder<T>();
        }

        public void SetTransitions(params Transition<T>[] transitions) {
            _transitions = transitions;
            _hasTransitions = transitions.Length > 0;
        }

        public void Enter(T dependency) {
            _enabled = true;
            
            EnableTransitions(_transitions);
            _onEnter?.Invoke(dependency);
            _innerStateMachine?.Enter();
        }
        
        public void Exit(T dependency) {
            DisableTransitions(_transitions);
            _onExit?.Invoke(dependency);
            _innerStateMachine?.Exit();
        }

        public void Tick(T dependency) {
            _onTick?.Invoke(dependency);
            _innerStateMachine?.Tick();
        }

        public void TryTransition(T dependency) {
            if (!_hasTransitions || !_enabled) return;
            
            foreach (Transition<T> transition in _transitions) {
                if (!transition.Evaluate(dependency)) continue;
                
                ExitState(transition.ToState);
                break;
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
            if (!_enabled) return;
            
            _enabled = false;
            OnExitState?.Invoke(toState);
        }
    }
}