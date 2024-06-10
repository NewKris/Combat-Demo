using UnityEngine;

namespace CoffeeBara.Gameplay.Util {
    public struct DampedAngle {
        private float _velocity;

        public float Damping { get; set; }
        public float Current { get; set; }
        public float Target { get; set; }

        public DampedAngle(float angle, float damping = 0) {
            Current = angle;
            Target = angle;
            Damping = damping;
            _velocity = 0;
        }
        
        public float Tick(float damping = 0) {
            return Tick(damping, Time.deltaTime);
        }
        
        public float Tick(float damping, float dt) {
            Current = Mathf.SmoothDampAngle(Current, Target, ref _velocity, damping, Mathf.Infinity, dt);
            return Current;
        }
    }
}