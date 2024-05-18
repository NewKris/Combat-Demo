using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    public static class CharacterAnimations {
        public static readonly int Idle = Animator.StringToHash("idle");
        public static readonly int Move = Animator.StringToHash("move");
        public static readonly int Dash = Animator.StringToHash("dash");
        public static readonly int Jump = Animator.StringToHash("jump");
        public static readonly int DoubleJump = Animator.StringToHash("double_jump");
        public static readonly int Airborne = Animator.StringToHash("airborne");
    }
}