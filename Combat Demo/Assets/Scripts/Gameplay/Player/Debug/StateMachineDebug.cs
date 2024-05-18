using System;
using CoffeeBara.Gameplay.Player.Character;
using TMPro;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Debug
{
    public class StateMachineDebug : MonoBehaviour {
        public PlayerCharacter character;

        private TextMeshProUGUI _text;

        private void Awake() {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void LateUpdate() {
            _text.text = character.CurrentStateName;
        }
    }
}
