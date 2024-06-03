using CoffeeBara.Gameplay.Common.HierarchicalStateMachine;
using CoffeeBara.Gameplay.Player.Character.StateMachine.Factories;

namespace CoffeeBara.Gameplay.Player.Character.StateMachine {
    public class CharacterStateMachine {
        private readonly Trigger<BlackBoard> _jumpTrigger;
        private readonly Trigger<BlackBoard> _dashTrigger;
        private readonly StateMachine<BlackBoard> _stateMachine;
        
        public CharacterStateMachine(BlackBoard blackBoard) {
            _jumpTrigger = new Trigger<BlackBoard>(blackBoard);
            _dashTrigger = new Trigger<BlackBoard>(blackBoard);
            
            StateRegistry states = new StateRegistry();
            TransitionRegistry transitions = new TransitionRegistry(states, _jumpTrigger, _dashTrigger);
            
            SetTransitions(states, transitions);
            
            _stateMachine = new StateMachine<BlackBoard>(states.idleState, blackBoard);
        }

        public void TriggerJump() {
            _jumpTrigger.Invoke();
        }

        public void TriggerDash() {
            _dashTrigger.Invoke();
        }

        public void Tick() {
            _stateMachine.Tick();
        }
        
        private void SetTransitions(StateRegistry states, TransitionRegistry transitions) {
            states.idleState.SetTransitions(
                transitions.toAirborne,
                transitions.idleToMove,
                transitions.toJump,
                transitions.toDash
            );
            
            states.moveState.SetTransitions(
                transitions.toAirborne,
                transitions.moveToIdle,
                transitions.toJump,
                transitions.toDash,
                transitions.moveToSprint
            );
            
            states.sprintState.SetTransitions(
                transitions.toAirborne,
                transitions.moveToIdle,
                transitions.sprintToMove,
                transitions.toJump,
                transitions.toDash
            );
            
            states.dashState.SetTransitions(
                transitions.dashToIdle,
                transitions.dashToAirborne
            );
            
            states.jumpState.SetTransitions(
                transitions.toAirborne,
                transitions.toIdle
            );
            
            states.doubleJumpState.SetTransitions(
                transitions.toAirborne,
                transitions.toIdle
            );
            
            states.airborneState.SetTransitions(
                transitions.toDoubleJump,
                transitions.toIdle,
                transitions.toDash
            );
        }
    }
}