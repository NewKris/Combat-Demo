using CoffeeBara.Gameplay.Common.FiniteStateMachine;
using CoffeeBara.Gameplay.Util;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    public static class StateFactory {
        public static State<BlackBoard> Idle() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Idle")
                .OnEnter(bb => {
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
                .OnTick(bb => {
                    float maxSpeed = bb.holdingDash ? bb.parameters.maxSprintSpeed : bb.parameters.maxJogSpeed;
                    Vector3 vel = bb.movementInput.ToGroundPlaneVector() * maxSpeed;
                    bb.kinematicCharacter.Move(vel);
                })
                .Build();
        }
        
        public static State<BlackBoard> Jump() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Jump")
                .OnEnter(bb => {
                    bb.kinematicCharacter.Jump(bb.jumpForce);
                })
                .Build();
        }
        
        public static State<BlackBoard> DoubleJump() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Double Jump")
                .OnEnter(bb => {
                    bb.noOfPerformedAirJumps++;
                    bb.kinematicCharacter.Jump(bb.jumpForce);
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