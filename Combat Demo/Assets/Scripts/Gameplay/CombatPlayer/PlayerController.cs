using System;
using CoffeeBara.Gameplay.Input;
using UnityEngine;

namespace CoffeeBara.Gameplay.CombatPlayer
{
    public class PlayerController : MonoBehaviour {
        public PlayerCharacter playerCharacter;
        
        private PlayerInput _input;

        private void Awake() {
            _input = new PlayerInput();

            _input.Locomotion.Jump.performed += _ => playerCharacter.Jump();
            _input.Locomotion.Dash.performed += _ => playerCharacter.Dash();
            _input.Combat.Attack.performed += _ => playerCharacter.Attack();
            _input.Combat.Special.performed += _ => playerCharacter.Special();
            
            _input.Enable();
        }

        private void Update() {
            playerCharacter.MovementInput = _input.Locomotion.Move.ReadValue<Vector2>();
            playerCharacter.Sprinting = _input.Locomotion.Dash.ReadValue<float>() != 0;
        }
    }
}
