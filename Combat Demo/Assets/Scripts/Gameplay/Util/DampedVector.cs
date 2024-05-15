using UnityEngine;

namespace CoffeeBara.Gameplay.Util {
    public struct DampedVector {
        private Vector3 _velocity;
        
        public Vector3 Current { get; set; }
        public Vector3 Target { get; set; }

        public DampedVector(Vector3 position) {
            Current = position;
            Target = position;
            _velocity = Vector3.zero;
        }
        
        public Vector3 Tick(float damping) {
            return Tick(damping, Time.deltaTime);
        }
        
        public Vector3 Tick(float damping, float dt) {
            Current = Vector3.SmoothDamp(Current, Target, ref _velocity, damping, Mathf.Infinity, dt);
            return Current;
        }
    }
}
