using UnityEngine;

namespace CoffeeBara.Gameplay.Util {
    public struct DampedVector {
        private Vector3 _velocity;
        
        public float Damping { get; set; }
        public Vector3 Current { get; set; }
        public Vector3 Target { get; set; }

        public DampedVector(Vector3 position, float damping = 0) {
            Current = position;
            Target = position;
            Damping = damping;
            _velocity = Vector3.zero;
        }

        public Vector3 Tick() {
            return Tick(Time.deltaTime);
        }
        
        public Vector3 Tick(float dt) {
            Current = Vector3.SmoothDamp(Current, Target, ref _velocity, Damping, Mathf.Infinity, dt);
            return Current;
        }
    }
}
