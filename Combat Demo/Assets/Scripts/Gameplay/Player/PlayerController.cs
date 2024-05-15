using System;
using CoffeeBara.Gameplay.Player.MovementPlayer;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player {
    public class PlayerController : MonoBehaviour {
        public PlayerCharacter character;

        private PlayerInput _input;
        
        private void Awake() {
            _input = new PlayerInput();
            _input.Locomotion.Jump.performed += _ => character.Jump();
            _input.Locomotion.Dash.performed += _ => character.Dash();
            
            _input.Enable();
        }

        private void OnDestroy() {
            _input.Dispose();
        }

        private void Update() {
            character.MovementInput = _input.Locomotion.Move.ReadValue<Vector2>();
        }
    }
}
