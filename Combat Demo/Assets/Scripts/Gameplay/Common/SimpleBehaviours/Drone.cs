using System;
using CoffeeBara.Gameplay.Util;
using UnityEngine;

namespace CoffeeBara.Gameplay.Common.SimpleBehaviours {
    public class Drone : MonoBehaviour {
        public Transform target;
        public float damping = 0.1f;

        private DampedVector _position;
        
        public void SnapToTarget() {
            _position = new DampedVector(target.position, damping);
        }

        private void Awake() {
            SnapToTarget();
        }

        private void FixedUpdate() {
            _position.Target = target.position;
            transform.position = _position.Tick(Time.fixedDeltaTime);
        }
    }
}
