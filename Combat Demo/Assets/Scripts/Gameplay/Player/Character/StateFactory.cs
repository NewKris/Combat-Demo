using CoffeeBara.Gameplay.Common.FiniteStateMachine;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    public static class StateFactory {
        public static State<BlackBoard> Idle() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Idle")
                .OnEnter(bb => {
                    bb.kinematicCharacter.GravityScale = bb.defaultGravityScale;
                })
                .Build();
        }
        
        public static State<BlackBoard> Move() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Move")
                .Build();
        }
        
        public static State<BlackBoard> Jump() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Jump")
                .Build();
        }
        
        public static State<BlackBoard> DoubleJump() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Double Jump")
                .Build();
        }
        
        public static State<BlackBoard> Airborne() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Airborne")
                .Build();
        }
        
        public static State<BlackBoard> Dash() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Dash")
                .Build();
        }
        
        public static State<BlackBoard> Attack() {
            return State<BlackBoard>.GetBuilder()
                .StateName("Attack")
                .Build();
        }
    }
}