using System;
using CoffeeBara.Gameplay.Common.FiniteStateMachine;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.MovementPlayer {
    public class PlayerCharacter : MonoBehaviour {
        private MovementStateMachine _stateMachine;
        private BlackBoard _blackBoard;

        public Vector2 MovementInput {
            set => _blackBoard.movementInput = value;
        }

        public void Jump() {
            _stateMachine.TriggerJump();
        }

        public void Dash() {
            _stateMachine.TriggerDash();
        }

        private void Awake() {
            BlackBoard blackBoard = new BlackBoard() {
                
            };
            
            _stateMachine = new MovementStateMachine(blackBoard);
        }
    }
}