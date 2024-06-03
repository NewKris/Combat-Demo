using CoffeeBara.Gameplay.Common.HierarchicalStateMachine;
using CoffeeBara.Gameplay.Player.Character.Animation;
using CoffeeBara.Gameplay.Util;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character.StateMachine.Factories {
    public static class StateFactory {
        public static State<BlackBoard> Idle() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Idle")
                .OnEnter(bb => {
                    bb.kinematicCharacter.GravityScale = bb.defaultGravityScale;
                    bb.kinematicCharacter.VelocityDamping = bb.movementParameters.velocityDamping;
                    bb.kinematicCharacter.AngularDamping = bb.movementParameters.angularDamping;
                    bb.airJumpCount = 0;
                    bb.dashCount = 0;
                    
                    bb.characterAnimator.QueueClip(Animations.Idle, 0.1f);
                    bb.kinematicCharacter.Move(Vector3.zero);
                })
                .Build();
        }
        
        public static State<BlackBoard> Move() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Move")
                .OnEnter(bb => {
                    bb.characterAnimator.QueueClip(Animations.Jog, 0.1f);
                })
                .OnTick(bb => {
                    Vector3 velocity = bb.movementInput.ToGroundPlaneVector() * bb.movementParameters.moveSpeed;
                    bb.kinematicCharacter.Move(velocity);
                })
                .Build();
        }
        
        public static State<BlackBoard> Sprint() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Sprint")
                .OnEnter(bb => {
                    bb.characterAnimator.QueueClip(Animations.Sprint, 0.1f);
                })
                .OnTick(bb => {
                    Vector3 velocity = bb.movementInput.ToGroundPlaneVector() * bb.movementParameters.sprintSpeed;
                    bb.kinematicCharacter.Move(velocity);
                })
                .Build();
        }
        
        public static State<BlackBoard> Dash() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Dash")
                .OnEnter(bb => {
                    bb.kinematicCharacter.GravityScale = 0;
                    bb.kinematicCharacter.VerticalVelocity = 0;
                    bb.characterAnimator.QueueClip(Animations.Dash, 0, 1);
                    
                    bb.dashCount++;
                    bb.timer = 0;
                })
                .OnTick(bb => {
                    Vector3 dir = bb.movementInput == Vector2.zero ? bb.kinematicCharacter.Forward : bb.movementInput.ToGroundPlaneVector();
                    Vector3 vel = dir * bb.dashSpeed;
                    
                    bb.kinematicCharacter.Move(vel);
                    bb.timer += Time.deltaTime;
                })
                .Build();
        }
        
        public static State<BlackBoard> Jump() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Jump")
                .OnEnter(bb => {
                    bb.characterAnimator.QueueClip(Animations.Jump, 0, 1);
                    bb.kinematicCharacter.Jump(bb.jumpForce);
                })
                .Build();
        }
        
        public static State<BlackBoard> DoubleJump() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Double Jump")
                .OnEnter(bb => {
                    bb.characterAnimator.QueueClip(Animations.DoubleJump, 0, 1);
                    bb.kinematicCharacter.Jump(bb.jumpForce);
                    bb.airJumpCount++;
                })
                .Build();
        }
        
        public static State<BlackBoard> Airborne() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Airborne")
                .OnEnter(bb => {
                    bb.kinematicCharacter.GravityScale = bb.defaultGravityScale;
                    bb.characterAnimator.QueueClip(Animations.Airborne, 0.1f);
                })
                .OnTick(bb => {
                    float moveSpeed = bb.holdingSprint
                        ? bb.movementParameters.sprintSpeed
                        : bb.movementParameters.moveSpeed;
                    
                    Vector3 velocity = bb.movementInput.ToGroundPlaneVector() * moveSpeed;
                    bb.kinematicCharacter.Move(velocity);
                })
                .Build();
        }
    }
}