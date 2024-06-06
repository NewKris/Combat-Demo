using CoffeeBara.Gameplay.Common.HierarchicalStateMachine;
using CoffeeBara.Gameplay.Player.Character.Animation;
using CoffeeBara.Gameplay.Player.Character.Combat;
using CoffeeBara.Gameplay.Util;
using UnityEngine;

namespace CoffeeBara.Gameplay.Player.Character.StateMachine {
    public class BlackBoard {
        public float timer;
        public bool holdingSprint;
        public int airJumpCount;
        public int dashCount;
        
        public float defaultGravityScale;
        public float jumpForce;
        public float dashSpeed;
        public Vector2 movementInput;
        public MovementParameters movementParameters;
        public KinematicCharacter kinematicCharacter;
        public CharacterAnimator characterAnimator;
        public CombatController combatController;

        public Vector3 GetMoveDirection() {
            return movementInput == Vector2.zero ? 
                kinematicCharacter.Forward 
                : movementInput.ToGroundPlaneVector();
        }
    }
}