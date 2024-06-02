using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.CombatPlayer {
    public class AnimatorEventListener : MonoBehaviour {
        public event Action OnNextAttack; 
        
        public void NextAttack() {
            OnNextAttack?.Invoke();
        }
    }
}