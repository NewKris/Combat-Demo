using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    [Serializable]
    public class MovementParameters {
        [Header("Movement")]
        public float moveSpeed;
        public float sprintSpeed;
        public float angularDamping;
        public float velocityDamping;

        [Header("Jumping")] 
        public float jumpHeight;
        public float jumpTime;
        public int noOfAirJumps;

        [Header("Dashing")] 
        public float dashLength;
        public float dashDuration;
        public int noOfAirDashes;

        public float CalculateGravityScale() {
            float t = jumpTime * 0.5f;
            float targetGravity = (-2 * jumpHeight) / (t * t);
            return targetGravity / Physics.gravity.y;
        }

        public float CalculateJumpForce() {
            float t = jumpTime * 0.5f;
            return (2 * jumpHeight) / t;
        }

        public float CalculateDashSpeed() {
            return dashLength / dashDuration;
        }
    }
}