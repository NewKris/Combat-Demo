using System.Collections.Generic;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character {
    public readonly struct Animation {
        public readonly int clipHash;
        public readonly float crossFade;
        public readonly float exitTime;
        
        public Animation(int clipHash, float crossFade, float exitTime) {
            this.clipHash = clipHash;
            this.crossFade = crossFade;
            this.exitTime = exitTime;
        }
    }
    
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimator : MonoBehaviour {
        private Animator _animator;
        private Animation _currentAnimation;
        
        private readonly Queue<Animation> _queuedAnimations = new Queue<Animation>();
        
        public float PlaybackSpeed {
            set => _animator.speed = value;
        }
        
        public void QueueClip(int clipHash, float crossFade = 0, float exitTime = 0) {
            _queuedAnimations.Enqueue(new Animation(clipHash, crossFade, Mathf.Clamp01(exitTime)));
        }
        
        private void Awake() {
            _animator = GetComponent<Animator>();
        }

        private void LateUpdate() {
            if (_queuedAnimations.Count == 0) {
                return;
            }
            
            float currentAnimationPlayTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (_currentAnimation.exitTime > currentAnimationPlayTime) {
                return;
            }
            
            _currentAnimation = _queuedAnimations.Dequeue();
            _animator.CrossFade(_currentAnimation.clipHash, _currentAnimation.crossFade);
        }
    }
}