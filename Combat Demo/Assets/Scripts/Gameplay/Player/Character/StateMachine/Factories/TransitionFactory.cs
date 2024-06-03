using CoffeeBara.Gameplay.Common.HierarchicalStateMachine;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character.StateMachine.Factories {
    public static class TransitionFactory {
        public static Transition<BlackBoard> ToAirborne(State<BlackBoard> airborneState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(airborneState)
                .Condition(bb => !bb.kinematicCharacter.IsGrounded)
                .Build();
        }
        
        public static Transition<BlackBoard> ToIdle(State<BlackBoard> idleState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(idleState)
                .Condition(bb => bb.kinematicCharacter.IsGrounded)
                .Build();
        }

        public static Transition<BlackBoard> IdleToMove(State<BlackBoard> moveState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(moveState)
                .Condition(bb => bb.movementInput != Vector2.zero)
                .Build();
        }

        public static Transition<BlackBoard> MoveToIdle(State<BlackBoard> idleState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(idleState)
                .Condition(bb => bb.movementInput == Vector2.zero)
                .Build();
        }
        
        public static Transition<BlackBoard> MoveToSprint(State<BlackBoard> sprintState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(sprintState)
                .Condition(bb => bb.holdingSprint)
                .Build();
        }
        
        public static Transition<BlackBoard> SprintToMove(State<BlackBoard> moveState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(moveState)
                .Condition(bb => !bb.holdingSprint)
                .Build();
        }
        
        public static Transition<BlackBoard> ToJump(Trigger<BlackBoard> jumpTrigger, State<BlackBoard> jumpState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(jumpState)
                .SetTrigger(jumpTrigger)
                .Build();
        }
        
        public static Transition<BlackBoard> ToDoubleJump(Trigger<BlackBoard> jumpTrigger, State<BlackBoard> doubleJumpState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(doubleJumpState)
                .SetTrigger(jumpTrigger)
                .Condition(bb => bb.airJumpCount < bb.movementParameters.noOfAirJumps)
                .Build();
        }
        
        public static Transition<BlackBoard> ToDash(Trigger<BlackBoard> dashTrigger, State<BlackBoard> dashState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(dashState)
                .SetTrigger(dashTrigger)
                .Condition(bb => bb.kinematicCharacter.IsGrounded || bb.dashCount < bb.movementParameters.noOfAirDashes)
                .Build();
        }
        
        public static Transition<BlackBoard> DashToAirborne(State<BlackBoard> airborneState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(airborneState)
                .Condition(bb => !bb.kinematicCharacter.IsGrounded && bb.timer > bb.movementParameters.dashDuration)
                .Build();
        }
        
        public static Transition<BlackBoard> DashToGrounded(State<BlackBoard> groundedState) {
            return Transition<BlackBoard>.GetBuilder()
                .ToState(groundedState)
                .Condition(bb => bb.kinematicCharacter.IsGrounded && bb.timer > bb.movementParameters.dashDuration)
                .Build();
        }
    }
}