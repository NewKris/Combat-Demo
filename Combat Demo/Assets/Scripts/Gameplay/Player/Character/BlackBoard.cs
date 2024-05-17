using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    [Serializable]
    public class BlackBoard {
        public float defaultGravityScale;
        public float jumpForce;
        public Vector2 movementInput;
        public MovementParameters parameters;
        public KinematicCharacter kinematicCharacter;
    }
}