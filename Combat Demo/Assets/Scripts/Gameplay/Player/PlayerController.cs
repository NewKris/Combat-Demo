using System;
using CoffeeBara.Gameplay.Player.Character;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player {
    public class PlayerController : MonoBehaviour {
        public PlayerCharacter character;
        
        private PlayerInput _input;
        
        private void Awake() {
            _input = new PlayerInput();

            _input.Locomotion.Jump.performed += _ => character.Jump();
            _input.Locomotion.Dash.performed += _ => character.Dash();
            
            _input.Combat.LightAttack.performed += _ => character.LightAttack();
            _input.Combat.HeavyAttack.performed += _ => character.HeavyAttack();
            _input.Combat.SpecialAttack.performed += _ => character.SpecialAttack();
            
            _input.Locomotion.Enable();
        }

        private void Update() {
            character.MovementInput = _input.Locomotion.Move.ReadValue<Vector2>();
            character.SprintHeld = _input.Locomotion.Sprint.ReadValue<float>() != 0;
        }

        private void OnDestroy() {
            _input.Dispose();
        }
    }
}
