using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    [Serializable]
    public class BlackBoard {
        public bool holdingDash;
        public float timer;
        public float defaultGravityScale;
        public float jumpForce;
        public float dashSpeed;
        public int noOfPerformedAirJumps;
        public Vector2 movementInput;
        public MovementParameters parameters;
        public KinematicCharacter kinematicCharacter;
    }
}