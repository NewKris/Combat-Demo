using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character.Combat {
    public class CombatAnimationListener : MonoBehaviour {
        public event Action<AttackConfig> OnAttackFrameReached;
        public event Action OnWait;
        public event Action OnAttackEnded;

        public void Slash(AttackConfig config) {
            OnAttackFrameReached?.Invoke(config);
        }

        public void Wait() {
            OnWait?.Invoke();
        }

        public void End() {
            OnAttackEnded?.Invoke();
        }
    }
}