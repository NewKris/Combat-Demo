using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character.Animation {
    public static class Animations {
        public static readonly int Idle = Animator.StringToHash("idle");
        public static readonly int Jog = Animator.StringToHash("jog");
        public static readonly int Sprint = Animator.StringToHash("sprint");
        public static readonly int Airborne = Animator.StringToHash("airborne");
        public static readonly int Dash = Animator.StringToHash("dash");
        public static readonly int Jump = Animator.StringToHash("jump");
        public static readonly int DoubleJump = Animator.StringToHash("double_jump");
    }
}