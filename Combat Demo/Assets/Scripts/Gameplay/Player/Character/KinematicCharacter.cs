using CoffeeBara.Gameplay.Util;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    [RequireComponent(typeof(CharacterController))]
    public class KinematicCharacter : MonoBehaviour {
        public bool faceMoveDirection = true;
        
        [Header("Ground Check")]
        public float sphereRadius = 0.5f;
        public float castStart = 0.6f;
        public float castLength = 0.2f;
        public LayerMask groundMask;

        private float _angularVelocity;
        private DampedVector _horizontalVelocity;
        private DampedAngle _yaw;
        private CharacterController _characterController;

        public bool IsGrounded { get; private set; }
        public float VelocityDamping { get; set; }
        public float GravityScale { get; set; }
        public float AngularDamping { get; set; }
        public float VerticalVelocity { get; set; }

        public Vector3 Forward => transform.forward;
        
        private Quaternion Rotation {
            get => transform.rotation;
            set => transform.rotation = value;
        }
        
        public void Move(Vector3 velocity) {
            _horizontalVelocity.Target = velocity;
        }

        public void Jump(float jumpForce) {
            VerticalVelocity = jumpForce;
        }
        
        private void Awake() {
            _characterController = GetComponent<CharacterController>();
            _yaw = new DampedAngle(transform.rotation.eulerAngles.y);
        }

        private void FixedUpdate() {
            IsGrounded = CalculateGrounded();
            VerticalVelocity += Physics.gravity.y * GravityScale * Time.fixedDeltaTime;

            float previousY = transform.position.y;
            Vector3 velocity = _horizontalVelocity.Tick(VelocityDamping, Time.fixedDeltaTime);
            velocity.y = VerticalVelocity;

            _characterController.Move(velocity * Time.fixedDeltaTime);
            VerticalVelocity = (transform.position.y - previousY) / Time.fixedDeltaTime;

            if (!faceMoveDirection || _horizontalVelocity.Current == Vector3.zero) {
                return;
            }
            
            _yaw.Target = Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
            Rotation = Quaternion.Euler(0, _yaw.Tick(AngularDamping), 0);
        }

        private bool CalculateGrounded() {
            Vector3 start = transform.position + Vector3.up * this.castStart;
            Ray ray = new Ray(start, Vector3.down);
            return Physics.SphereCast(ray, sphereRadius, castLength, groundMask);
        }

        private void OnDrawGizmos() {
            Gizmos.color = IsGrounded ? Color.green : Color.red;
            
            Vector3 start = transform.position + Vector3.up * castStart;
            Vector3 end = start + Vector3.down * castLength;
            
            Gizmos.DrawWireSphere(start, sphereRadius);
            Gizmos.DrawWireSphere(end, sphereRadius);
        }
    }
}