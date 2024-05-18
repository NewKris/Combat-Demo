using CoffeeBara.Gameplay.Common.FiniteStateMachine;

namespace CoffeeBara.Gameplay.Player.Character {
    public class CharacterStateMachine {
        private readonly StateMachine<BlackBoard> _stateMachine;
        private readonly BlackBoard _blackBoard;
        private readonly Trigger _jumpTrigger;
        private readonly Trigger _dashTrigger;
        private readonly Trigger _attackTrigger;
        
        private State<BlackBoard> _idleState;
        private State<BlackBoard> _moveState;
        private State<BlackBoard> _jumpState;
        private State<BlackBoard> _doubleJumpState;
        private State<BlackBoard> _airborneState;
        private State<BlackBoard> _dashState;
        private State<BlackBoard> _attackState;

        private Transition<BlackBoard> _jumpTransition;
        private Transition<BlackBoard> _doubleJumpTransition;
        private Transition<BlackBoard> _dashTransition;
        private Transition<BlackBoard> _attackTransition;
        private Transition<BlackBoard> _idleToMove;
        private Transition<BlackBoard> _moveToIdle;
        private Transition<BlackBoard> _attackToIdle;
        private Transition<BlackBoard> _toIdle;
        private Transition<BlackBoard> _toAirborne;
        private Transition<BlackBoard> _dashToIdle;
        private Transition<BlackBoard> _dashToAirborne;

        public string CurrentStateName => _stateMachine.CurrentStateName;
        
        public CharacterStateMachine(
            BlackBoard blackBoard,
            Trigger jumpTrigger,
            Trigger dashTrigger,
            Trigger attackTrigger
        ) {
            _blackBoard = blackBoard;
            _jumpTrigger = jumpTrigger;
            _dashTrigger = dashTrigger;
            _attackTrigger = attackTrigger;
            
            CreateStates();
            CreateTransitions();
            AssignTransitions();
            
            _stateMachine = new StateMachine<BlackBoard>(_idleState, blackBoard);
        }

        public void Tick() {
            _stateMachine.Tick();
        }

        private void CreateStates() {
            _idleState = StateFactory.Idle();
            _moveState = StateFactory.Move();
            _jumpState = StateFactory.Jump();
            _doubleJumpState = StateFactory.DoubleJump();
            _airborneState = StateFactory.Airborne();
            _dashState = StateFactory.Dash();
            _attackState = StateFactory.Attack();
        }

        private void CreateTransitions() {
            _jumpTransition = TransitionFactory.TriggerJump(
                _blackBoard, 
                _jumpTrigger, 
                _jumpState
            );
            
            _doubleJumpTransition = TransitionFactory.TriggerDoubleJump(
                _blackBoard, 
                _jumpTrigger, 
                _doubleJumpState
            );
            
            _dashTransition = TransitionFactory.TriggerDash(
                _blackBoard,
                _dashTrigger,
                _dashState
            );
            
            _attackTransition = TransitionFactory.TriggerAttack(
                _blackBoard,
                _attackTrigger,
                _attackState
            );
            
            _toIdle = TransitionFactory.ToIdle(_blackBoard, _idleState);
            _toAirborne = TransitionFactory.ToAirborne(_blackBoard, _airborneState);
            
            _idleToMove = TransitionFactory.IdleToMove(_blackBoard, _moveState);
            _moveToIdle = TransitionFactory.MoveToIdle(_blackBoard, _idleState);
            _attackToIdle = TransitionFactory.AttackToIdle(_blackBoard, _idleState);
            _dashToIdle = TransitionFactory.DashToIdle(_blackBoard, _idleState);
            _dashToAirborne = TransitionFactory.DashToAirborne(_blackBoard, _airborneState);
        }

        private void AssignTransitions() {
            _idleState.SetTransitions(
                _idleToMove,
                _jumpTransition,
                _dashTransition,
                _attackTransition,
                _toAirborne
            );
            
            _moveState.SetTransitions(
                _moveToIdle,
                _jumpTransition,
                _dashTransition,
                _toAirborne,
                _attackTransition
            );
            
            _airborneState.SetTransitions(
                _toIdle,
                _doubleJumpTransition,
                _dashTransition
            );
            
            _jumpState.SetTransitions(
                _toAirborne,
                _toIdle
            );
            
            _doubleJumpState.SetTransitions(
                _toAirborne,
                _toIdle
            );
            
            _dashState.SetTransitions(
                _dashToAirborne,
                _dashToIdle
            );
            
            _attackState.SetTransitions(
                _attackToIdle
            );
        }
    }
}