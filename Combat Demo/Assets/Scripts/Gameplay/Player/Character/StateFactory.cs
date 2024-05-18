using CoffeeBara.Gameplay.Common.FiniteStateMachine;
using CoffeeBara.Gameplay.Util;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    public static class StateFactory {
        public static State<BlackBoard> Idle() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Idle")
                .OnEnter(bb => {
                    bb.characterAnimator.QueueClip(CharacterAnimations.Idle, 0.1f);
                    
                    bb.noOfPerformedAirJumps = 0;
                    
                    bb.kinematicCharacter.GravityScale = bb.defaultGravityScale;
                    bb.kinematicCharacter.AngularDamping = bb.parameters.angularDamping;
                    bb.kinematicCharacter.VelocityDamping = bb.parameters.velocityDamping;
                    
                    bb.kinematicCharacter.Move(Vector3.zero);
                })
                .Build();
        }
        
        public static State<BlackBoard> Move() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Move")
                .OnEnter(bb => {
                    bb.characterAnimator.QueueClip(CharacterAnimations.Move, 0.2f);
                })
                .OnTick(bb => {
                    float maxSpeed = bb.holdingDash ? bb.parameters.maxSprintSpeed : bb.parameters.maxJogSpeed;
                    bb.characterAnimator.PlaybackSpeed = bb.holdingDash ? 1.5f : 1;
                    Vector3 vel = bb.movementInput.ToGroundPlaneVector() * maxSpeed;
                    bb.kinematicCharacter.Move(vel);
                })
                .OnExit(bb => {
                    bb.characterAnimator.PlaybackSpeed = 1;
                })
                .Build();
        }
        
        public static State<BlackBoard> Jump() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Jump")
                .OnEnter(bb => {
                    bb.kinematicCharacter.Jump(bb.jumpForce);
                    bb.characterAnimator.QueueClip(CharacterAnimations.Jump, 0, 1);
                })
                .Build();
        }
        
        public static State<BlackBoard> DoubleJump() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Double Jump")
                .OnEnter(bb => {
                    bb.noOfPerformedAirJumps++;
                    bb.kinematicCharacter.Jump(bb.jumpForce);
                    bb.characterAnimator.QueueClip(CharacterAnimations.DoubleJump, 0, 1);
                })
                .Build();
        }
        
        public static State<BlackBoard> Airborne() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Airborne")
                .OnEnter(bb => {
                    bb.kinematicCharacter.GravityScale = bb.defaultGravityScale;
                    bb.kinematicCharacter.AngularDamping = bb.parameters.angularDamping;
                    bb.kinematicCharacter.VelocityDamping = bb.parameters.airborneVelocityDamping;
                    bb.characterAnimator.QueueClip(CharacterAnimations.Airborne, 0.2f);
                })
                .OnTick(bb => {
                    float maxSpeed = bb.holdingDash ? bb.parameters.maxSprintSpeed : bb.parameters.maxJogSpeed;
                    Vector3 vel = bb.movementInput.ToGroundPlaneVector() * maxSpeed;
                    bb.kinematicCharacter.Move(vel);
                })
                .Build();
        }
        
        public static State<BlackBoard> Dash() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Dash")
                .OnEnter(bb => {
                    bb.timer = 0;
                    bb.kinematicCharacter.GravityScale = 0;
                    bb.kinematicCharacter.AngularDamping = 0;
                    bb.kinematicCharacter.VerticalVelocity = 0;
                    
                    bb.characterAnimator.QueueClip(CharacterAnimations.Dash);
                })
                .OnTick(bb => {
                    bb.timer += Time.deltaTime;
                    
                    Vector3 dir = bb.movementInput == Vector2.zero
                        ? bb.kinematicCharacter.Forward
                        : bb.movementInput.ToGroundPlaneVector();
                    
                    bb.kinematicCharacter.Move(dir * bb.dashSpeed);
                })
                .Build();
        }
        
        public static State<BlackBoard> Attack() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Attack")
                .Build();
        }
    }
}