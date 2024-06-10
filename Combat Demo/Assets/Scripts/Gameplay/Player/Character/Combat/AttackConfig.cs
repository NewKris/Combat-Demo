using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character.Combat {
    [CreateAssetMenu(menuName = "Combat/Attack Config")]
    public class AttackConfig : ScriptableObject {
        public float baseDamage;
        public float moveDuration;
        public Vector3 moveDistance;
    }
}