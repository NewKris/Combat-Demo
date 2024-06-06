using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.Common.SimpleBehaviours
{
    public class GroundedCursor : MonoBehaviour {
        public LayerMask groundMask;

        private void Update() {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundMask)) {
                transform.position = hit.point;
            }
        }
    }
}
