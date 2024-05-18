using UnityEngine;

namespace CoffeeBara.Gameplay.Util {
    public struct DampedAngle {
        private float _velocity;
        
        public float Current { get; set; }
        public float Target { get; set; }

        public DampedAngle(float angle) {
            Current = angle;
            Target = angle;
            _velocity = 0;
        }
        
        public float Tick(float damping) {
            return Tick(damping, Time.deltaTime);
        }
        
        public float Tick(float damping, float dt) {
            Current = Mathf.SmoothDampAngle(Current, Target, ref _velocity, damping, Mathf.Infinity, dt);
            return Current;
        }
    }
}