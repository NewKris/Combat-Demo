using CoffeeBara.Gameplay.Common.FiniteStateMachine;

namespace CoffeeBara.Gameplay.Player.MovementPlayer {
    public class MovementStateMachine {
        private readonly Trigger _jumpTrigger;
        private readonly Trigger _dashTrigger;
        private readonly StateMachine<BlackBoard> _stateMachine;

        public MovementStateMachine(BlackBoard blackBoard) {
            _jumpTrigger = new Trigger();
            _dashTrigger = new Trigger();

            State<BlackBoard> idleState = MovementStateFactory.IdleState();
            
            _stateMachine = new StateMachine<BlackBoard>(idleState, blackBoard);
        }

        public void TriggerJump() {
            _jumpTrigger.Invoke();
        }

        public void TriggerDash() {
            _dashTrigger.Invoke();
        }
    }
}