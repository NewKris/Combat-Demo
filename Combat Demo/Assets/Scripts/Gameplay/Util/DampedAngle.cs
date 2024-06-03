using UnityEngine;

namespace CoffeeBara.Gameplay.Util {
    public struct DampedAngle {
        private float _velocity;
        private float _maxSpeed;
        
        public float Current { get; set; }
        public float Target { get; set; }

        public DampedAngle(float angle, float maxSpeed = Mathf.Infinity) {
            Current = angle;
            Target = angle;
            _velocity = 0;
            _maxSpeed = maxSpeed;
        }
        
        public float Tick(float damping = 0) {
            return Tick(damping, Time.deltaTime);
        }
        
        public float Tick(float damping, float dt) {
            Current = Mathf.SmoothDampAngle(Current, Target, ref _velocity, damping, _maxSpeed, dt);
            return Current;
        }
    }
}