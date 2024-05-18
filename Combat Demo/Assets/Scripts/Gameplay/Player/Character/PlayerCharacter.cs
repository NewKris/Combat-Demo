using System;
using CoffeeBara.Gameplay.Common.FiniteStateMachine;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    public class PlayerCharacter : MonoBehaviour {
        public MovementParameters parameters;
        
        private BlackBoard _blackBoard;
        private Trigger _jumpTrigger;
        private Trigger _dashTrigger;
        private Trigger _attackTrigger;
        private CharacterStateMachine _stateMachine;

        public bool SprintHeld {
            set => _blackBoard.holdingDash = value;
        }
        
        public string CurrentStateName => _stateMachine.CurrentStateName;

        public Vector2 MovementInput {
            set => _blackBoard.movementInput = value;
        }
        
        public void Jump() {
            _jumpTrigger.Invoke();
        }

        public void Dash() {
            _dashTrigger.Invoke();
        }

        public void LightAttack() {
            _attackTrigger.Invoke();
        }

        public void HeavyAttack() {
            _attackTrigger.Invoke();
        }

        public void SpecialAttack() {
            _attackTrigger.Invoke();
        }

        private void Awake() {
            _blackBoard = new BlackBoard() {
                defaultGravityScale = parameters.CalculateGravityScale(),
                jumpForce = parameters.CalculateJumpForce(),
                dashSpeed = parameters.CalculateDashSpeed(),
                kinematicCharacter = GetComponent<KinematicCharacter>(),
                characterAnimator = GetComponentInChildren<CharacterAnimator>(),
                parameters = parameters
            };

            _jumpTrigger = new Trigger();
            _dashTrigger = new Trigger();
            _attackTrigger = new Trigger();
            
            _stateMachine = new CharacterStateMachine(
                _blackBoard, 
                _jumpTrigger, 
                _dashTrigger,
                _attackTrigger
            );
        }

        private void Update() {
            _stateMachine.Tick();
        }
    }
}
