using System;
using System.Collections;
using System.Collections.Generic;
using CoffeeBara.Gameplay.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace CoffeeBara.Gameplay.CombatPlayer {
    [RequireComponent(typeof(KinematicCharacter))]
    public class PlayerCharacter : MonoBehaviour {
        private static readonly int Moving = Animator.StringToHash("Moving");
        private static readonly int Grounded = Animator.StringToHash("Grounded");
        private static readonly int Sprinting1 = Animator.StringToHash("Sprinting");
        private static readonly int Dashing = Animator.StringToHash("Dashing");
        private static readonly int Attacking = Animator.StringToHash("Attacking");
        
        [Header("Movement")]
        public float jogSpeed = 10;
        public float sprintSpeed = 15;
        public float velocityDamping = 0.1f;
        public float angularDamping = 0.1f;

        [Header("Jumping")]
        public float jumpHeight = 2;
        public float jumpTime = 0.7f;

        [Header("Dashing")]
        public float dashDuration = 0.5f;
        public float dashLength = 5;

        [Header("Combat")] 
        public float attackBuffer = 0.05f;

        private bool _dashing;
        private bool _attacking;
        private bool _attackDone;
        private float _jumpForce;
        private float _gravityScale;
        private float _dashSpeed;
        private Queue<float> _attackInputs;
        private KinematicCharacter _kinematicCharacter;
        private Animator _animator;
        private AnimatorEventListener _animatorEventListener;

        public bool Sprinting { get; set; }
        public Vector2 MovementInput { get; set; }

        public void Jump() {
            _animator.SetTrigger("Jump");
            _kinematicCharacter.Jump(_jumpForce);
        }

        public void Attack() {
            _attackInputs.Enqueue(Time.time);
        }

        public void Special() {
            
        }

        public void SpecialAttack() {
            
        }

        public void Dash() {
            if (_dashing || _attackInputs.Count > 0) return;

            _dashing = true;
            StartCoroutine(DashAsync());
        }

        private void Awake() {
            _kinematicCharacter = GetComponent<KinematicCharacter>();
            _animator = GetComponentInChildren<Animator>();
            _animatorEventListener = GetComponentInChildren<AnimatorEventListener>();
            _attackInputs = new Queue<float>();
            
            float t = jumpTime * 0.5f;
            float gravity = (-2 * jumpHeight) / (t * t);
            
            _jumpForce = (2 * jumpHeight) / t;
            _gravityScale = gravity / Physics.gravity.y;
            _dashSpeed = dashLength / dashDuration;
            
            _kinematicCharacter.GravityScale = _gravityScale;
            _kinematicCharacter.VelocityDamping = velocityDamping;
            _kinematicCharacter.AngularDamping = angularDamping;

            _animatorEventListener.OnNextAttack += () => _attackDone = true;
        }

        private void Update() {
            _attacking = _attackInputs.Count > 0 && !_dashing && _kinematicCharacter.IsGrounded;
            
            _animator.SetBool(Moving, MovementInput != Vector2.zero);
            _animator.SetBool(Grounded, _kinematicCharacter.IsGrounded);
            _animator.SetBool(Sprinting1, Sprinting);
            _animator.SetBool(Dashing, _dashing);
            _animator.SetBool(Attacking, _attacking);

            if (!_dashing && !_attacking) {
                float speed = Sprinting ? sprintSpeed : jogSpeed;
                _kinematicCharacter.Move(MovementInput.ToGroundPlaneVector() * speed);   
            }

            if (_attacking) {
                _kinematicCharacter.Move(Vector3.zero);
            }
            
            ExpireAttackInputs();
        }

        private IEnumerator DashAsync() {
            float t = 0;
            _kinematicCharacter.GravityScale = 0;
            _kinematicCharacter.VerticalVelocity = 0;
            
            while (t < dashDuration) {
                Vector3 dir = MovementInput == Vector2.zero
                    ? _kinematicCharacter.Forward
                    : MovementInput.ToGroundPlaneVector();
                
                _kinematicCharacter.Move(dir.normalized * _dashSpeed);
                
                t += Time.deltaTime;
                yield return null;
            }

            _kinematicCharacter.GravityScale = _gravityScale;
            _dashing = false;
        }

        private void ExpireAttackInputs() {
            int expireCount = 0;
            foreach (float attackInput in _attackInputs) {
                if (Time.time - attackInput < attackBuffer) break;

                expireCount++;
            }

            for (int i = 0; i < expireCount; i++) {
                _attackInputs.Dequeue();
            }
        }

        private void PerformAttack() {
        }
    }
}