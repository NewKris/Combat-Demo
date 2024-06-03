using CoffeeBara.Gameplay.Common.HierarchicalStateMachine;
using CoffeeBara.Gameplay.Player.Character.Animation;
using CoffeeBara.Gameplay.Player.Character.StateMachine;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    [RequireComponent(typeof(KinematicCharacter))]
    public class PlayerCharacter : MonoBehaviour {
        public MovementParameters movementParameters;
        
        private BlackBoard _blackBoard;
        private CharacterStateMachine _stateMachine;
        
        public bool HoldingSprint {
            set => _blackBoard.holdingSprint = value;
        }
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
            _blackBoard = new BlackBoard() {
                defaultGravityScale = movementParameters.CalculateGravityScale(),
                jumpForce = movementParameters.CalculateJumpForce(),
                dashSpeed = movementParameters.CalculateDashSpeed(),
                movementParameters = movementParameters,
                kinematicCharacter = GetComponent<KinematicCharacter>(),
                characterAnimator = GetComponentInChildren<CharacterAnimator>(),
            };

            _stateMachine = new CharacterStateMachine(_blackBoard);
        }

        private void Update() {
            _stateMachine.Tick();
        }
    }
}