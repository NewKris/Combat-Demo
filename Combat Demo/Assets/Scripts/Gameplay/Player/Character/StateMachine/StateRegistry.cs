using CoffeeBara.Gameplay.Common.HierarchicalStateMachine;
using CoffeeBara.Gameplay.Player.Character.StateMachine.Factories;

namespace CoffeeBara.Gameplay.Player.Character.StateMachine {
    public class StateRegistry {
        public readonly State<BlackBoard> idleState = StateFactory.Idle();
        public readonly State<BlackBoard> moveState = StateFactory.Move();
        public readonly State<BlackBoard> sprintState = StateFactory.Sprint();
        public readonly State<BlackBoard> dashState = StateFactory.Dash();
        public readonly State<BlackBoard> jumpState = StateFactory.Jump();
        public readonly State<BlackBoard> doubleJumpState = StateFactory.DoubleJump();
        public readonly State<BlackBoard> airborneState = StateFactory.Airborne();
        public readonly State<BlackBoard> attackState = StateFactory.Attack();
    }
}