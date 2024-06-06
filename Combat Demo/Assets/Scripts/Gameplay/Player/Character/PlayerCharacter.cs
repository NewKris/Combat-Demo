using CoffeeBara.Gameplay.Common.HierarchicalStateMachine;
using CoffeeBara.Gameplay.Player.Character.Animation;
using CoffeeBara.Gameplay.Player.Character.Combat;
using CoffeeBara.Gameplay.Player.Character.StateMachine;
using CoffeeBara.Gameplay.Util;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    [RequireComponent(typeof(KinematicCharacter), typeof(CombatController))]
    public class PlayerCharacter : MonoBehaviour {
        public Transform groundedCursor;
        public MovementParameters movementParameters;
        
        private BlackBoard _blackBoard;
        private CharacterStateMachine _stateMachine;
        
        public bool UsingGamepad { get; set; }
        
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

        public void LightAttack() {
            _blackBoard.combatController.Attack();
        }

        private void Awake() {
            _blackBoard = new BlackBoard() {
                defaultGravityScale = movementParameters.CalculateGravityScale(),
                jumpForce = movementParameters.CalculateJumpForce(),
                dashSpeed = movementParameters.CalculateDashSpeed(),
                movementParameters = movementParameters,
                kinematicCharacter = GetComponent<KinematicCharacter>(),
                characterAnimator = GetComponentInChildren<CharacterAnimator>(),
                combatController = GetComponent<CombatController>(),
            };

            _stateMachine = new CharacterStateMachine(_blackBoard);
        }

        private void Update() {
            _blackBoard.combatController.FacingDirection = UsingGamepad ? 
                _blackBoard.GetMoveDirection() : (groundedCursor.position - transform.position).Flatten();
            
            _stateMachine.Tick();
        }
    }
}