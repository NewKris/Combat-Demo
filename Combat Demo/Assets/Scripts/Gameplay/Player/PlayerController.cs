using CoffeeBara.Gameplay.Input;
using CoffeeBara.Gameplay.Player.Character;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player {
    public class PlayerController : MonoBehaviour {
        public PlayerCharacter playerCharacter;

        private PlayerInput _input;
        
        private void Awake() {
            _input = new PlayerInput();

            _input.Locomotion.Jump.performed += _ => playerCharacter.Jump();
            _input.Locomotion.Dash.performed += _ => playerCharacter.Dash();
            
            _input.Enable();
        }

        private void Update() {
            playerCharacter.MovementInput = _input.Locomotion.Move.ReadValue<Vector2>();
            playerCharacter.HoldingSprint = _input.Locomotion.Sprint.ReadValue<float>() != 0;
        }
    }
}
