using CoffeeBara.Gameplay.Common.HierarchicalStateMachine;
using CoffeeBara.Gameplay.Player.Character.StateMachine.Factories;

namespace CoffeeBara.Gameplay.Player.Character.StateMachine {
    public class TransitionRegistry {
        public readonly Transition<BlackBoard> toAirborne;
        public readonly Transition<BlackBoard> toIdle;
        public readonly Transition<BlackBoard> idleToMove;
        public readonly Transition<BlackBoard> moveToIdle;
        public readonly Transition<BlackBoard> moveToSprint;
        public readonly Transition<BlackBoard> sprintToMove;
        public readonly Transition<BlackBoard> dashToIdle;
        public readonly Transition<BlackBoard> dashToAirborne;
        public readonly Transition<BlackBoard> toJump;
        public readonly Transition<BlackBoard> toDoubleJump;
        public readonly Transition<BlackBoard> toDash;
        public readonly Transition<BlackBoard> toAttack;
        public readonly Transition<BlackBoard> attackToIdle;
        public readonly Transition<BlackBoard> attackToDash;
        public readonly Transition<BlackBoard> attackToAirborne;
        
        public TransitionRegistry(
            StateRegistry registry,
            Trigger<BlackBoard> jumpTrigger,
            Trigger<BlackBoard> dashTrigger
        ) {
            toAirborne = TransitionFactory.ToAirborne(registry.airborneState);
            toIdle = TransitionFactory.ToIdle(registry.idleState);
            idleToMove = TransitionFactory.IdleToMove(registry.moveState);
            moveToIdle = TransitionFactory.MoveToIdle(registry.idleState);
            moveToSprint = TransitionFactory.MoveToSprint(registry.sprintState);
            sprintToMove = TransitionFactory.SprintToMove(registry.moveState);
            dashToIdle = TransitionFactory.DashToGrounded(registry.idleState);
            dashToAirborne = TransitionFactory.DashToAirborne(registry.airborneState);
            toJump = TransitionFactory.ToJump(jumpTrigger, registry.jumpState);
            toDoubleJump = TransitionFactory.ToDoubleJump(jumpTrigger, registry.doubleJumpState);
            toDash = TransitionFactory.ToDash(dashTrigger, registry.dashState);
            toAttack = TransitionFactory.ToAttackState(registry.attackState);
            attackToIdle = TransitionFactory.AttackToIdle(registry.idleState);
            attackToDash = TransitionFactory.AttackToDash(dashTrigger, registry.dashState);
            attackToAirborne = TransitionFactory.AttackToAirborne(registry.airborneState);
        }
    }
}