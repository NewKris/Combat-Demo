using System;
using System.Collections;
using System.Collections.Generic;
using CoffeeBara.Gameplay.Player.Character.Animation;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character.Combat {
    public enum AttackType {
        NORMAL,
        SPECIAL
    }

    public readonly struct AttackInput {
        public readonly AttackType attackType;
        public readonly float inputTime;
        
        public AttackInput(AttackType attackType, float inputTime) {
            this.attackType = attackType;
            this.inputTime = inputTime;
        }
    }
    
    public class CombatController : MonoBehaviour {
        // TODO: Input caching for other actions
        // Add an Exit Trigger that gets invoked after current attack if you have a dash/jump input cached and valid
        
        public float inputBuffer = 0.5f;

        private bool _active;
        private int _currentNormalAttack;
        private Animator _animator;
        private KinematicCharacter _character;
        private CombatAnimationListener _listener;
        private Queue<float> _inputBuffer;
        
        public bool IsAttacking { get; set; }
        public bool HasAttacksQueued => _inputBuffer.Count > 0;
        public bool Swinging { get; set; }
        public Vector3 FacingDirection { get; set; }
        
        public void Attack() {
            _inputBuffer.Enqueue(Time.time);
        }

        public void StartAttacking() {
            _active = true;
            
            IsAttacking = true;
            _currentNormalAttack = 0;
            _inputBuffer.Dequeue();
            _animator.Play(Animations.SwordNormal1);
        }

        public void StopAttacking() {
            _active = false;
            
            IsAttacking = false;
            _currentNormalAttack = 0;
            StopCoroutine(nameof(WaitForInputAsync));
            StopCoroutine(nameof(MoveAsync));
        }

        private void Awake() {
            _animator = GetComponentInChildren<Animator>();
            _character = GetComponent<KinematicCharacter>();
            _listener = GetComponentInChildren<CombatAnimationListener>();
            _inputBuffer = new Queue<float>();
            
            _listener.OnAttackEnded += OnAttackEnded;
            _listener.OnWait += OnWaitForInput;
            _listener.OnAttackFrameReached += OnAttackSlash;
        }

        private void OnDestroy() {
            _listener.OnAttackEnded -= OnAttackEnded;
            _listener.OnWait -= OnWaitForInput;
            _listener.OnAttackFrameReached -= OnAttackSlash;
        }

        private void Update() {
            ExpireInputs();
        }

        private void OnAttackSlash(AttackConfig config) {
            if (!_active) return;
            
            StopCoroutine(WaitForInputAsync());
            StartCoroutine(MoveAsync(config.moveDuration, config.moveDistance));
            Swinging = true;
            Debug.Log("Hit");
        }

        private void OnWaitForInput() {
            if (!_active) return;
            
            Swinging = false;
            StartCoroutine(WaitForInputAsync());
        }

        private void OnAttackEnded() {
            if (!_active) return;
            
            StopCoroutine(WaitForInputAsync());
            IsAttacking = false;
        }

        private void ExpireInputs() {
            int expireCount = 0;

            foreach (float input in _inputBuffer) {
                float elapsedTime = Time.time - input;
                if (elapsedTime < inputBuffer) break;

                expireCount++;
            }
            
            for (int i = 0; i < expireCount; i++) {
                _inputBuffer.Dequeue();
            }
        }

        private IEnumerator MoveAsync(float duration, Vector3 localMoveDistance) {
            float t = 0;

            Vector3 localVelocity = localMoveDistance / duration;
            Vector3 velocity = _character.YawRotation * localVelocity;
            _character.Move(velocity);
            
            while (t < duration) {
                t += Time.deltaTime;
                yield return null;
            }
            
            _character.Move(Vector3.zero);
        }

        private IEnumerator WaitForInputAsync() {
            while (_active) {
                if (HasAttacksQueued) {
                    _inputBuffer.Dequeue();
                    _character.Look(FacingDirection);
                    _animator.Play(GetNextNormalAttackHash());
                    _currentNormalAttack = (_currentNormalAttack + 1) % 4;
                    break;
                }

                yield return null;
            }
        }

        private int GetNextNormalAttackHash() {
            return _currentNormalAttack switch {
                0 => Animations.SwordNormal2,
                1 => Animations.SwordNormal3,
                2 => Animations.SwordNormal4,
                3 => Animations.SwordNormal1,
                _ => throw new Exception("Invalid attack index")
            };
        }
    }
}
