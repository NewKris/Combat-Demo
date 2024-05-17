using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    [Serializable]
    public class MovementParameters {
        [Header("Moving")]
        public float maxJogSpeed;
        public float maxSprintSpeed;
        public float velocityDamping;
        public float angularDamping;

        [Header("Dashing")] 
        public float dashDuration;
        public float dashLength;
        
        [Header("Jumping")]
        public float jumpHeight;
        public float jumpTime;
        public int noOfAirJumps;

        [Header("Airborne")] 
        public float airborneVelocityDamping;

        public float CalculateGravityScale() {
            float t = jumpTime * 0.5f;
            float gravity = (-2 * jumpHeight) / (t * t);
            return gravity / Physics.gravity.y;
        }

        public float CalculateJumpForce() {
            float t = jumpTime * 0.5f;
            return (2 * jumpHeight) / t;
        }
    }
}