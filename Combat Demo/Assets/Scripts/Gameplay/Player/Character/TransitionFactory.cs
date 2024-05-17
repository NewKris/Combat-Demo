using CoffeeBara.Gameplay.Common.FiniteStateMachine;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    public static class TransitionFactory {
        public static Transition<BlackBoard> IdleToMove(BlackBoard blackBoard, State<BlackBoard> moveState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(moveState)
                .Dependency(blackBoard)
                .Condition(bb => bb.movementInput != Vector2.zero)
                .Build();
        }

        public static Transition<BlackBoard> MoveToIdle(BlackBoard blackBoard, State<BlackBoard> idleState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(idleState)
                .Dependency(blackBoard)
                .Condition(bb => bb.movementInput == Vector2.zero)
                .Build();
        }
        
        public static Transition<BlackBoard> AttackToIdle(BlackBoard blackBoard, State<BlackBoard> idleState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(idleState)
                .Dependency(blackBoard)
                .Build();
        }

        public static Transition<BlackBoard> ToAirborne(
            BlackBoard blackBoard,
            State<BlackBoard> airborneState
        ) {
            return Transition<BlackBoard>.GetBuilder()
                .Dependency(blackBoard)
                .ToState(airborneState)
                .Condition(bb => !bb.kinematicCharacter.IsGrounded)
                .Build();
        }

        public static Transition<BlackBoard> ToIdle(
            BlackBoard blackBoard,
            State<BlackBoard> idleState
        ) {
            return Transition<BlackBoard>.GetBuilder()
                .Dependency(blackBoard)
                .ToState(idleState)
                .Condition(bb => bb.kinematicCharacter.IsGrounded)
                .Build();
        }

        public static Transition<BlackBoard> TriggerJump(
            BlackBoard blackBoard,
            Trigger jumpTrigger,
            State<BlackBoard> jumpState
        ) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(jumpState)
                .Dependency(blackBoard)
                .SetTrigger(jumpTrigger)
                .Build();
        }

        public static Transition<BlackBoard> TriggerDoubleJump(
            BlackBoard blackBoard,
            Trigger jumpTrigger,
            State<BlackBoard> doubleJumpState
        ) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(doubleJumpState)
                .Dependency(blackBoard)
                .SetTrigger(jumpTrigger)
                .Build();
        }

        public static Transition<BlackBoard> TriggerDash(
            BlackBoard blackBoard, 
            Trigger dashTrigger, 
            State<BlackBoard> dashState
        ) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(dashState)
                .Dependency(blackBoard)
                .SetTrigger(dashTrigger)
                .Build();
        }

        public static Transition<BlackBoard> TriggerAttack(
            BlackBoard blackBoard, 
            Trigger attackTrigger, 
            State<BlackBoard> attackState
        ) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(attackState)
                .Dependency(blackBoard)
                .SetTrigger(attackTrigger)
                .Build();
        }
    }
}