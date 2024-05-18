using UnityEngine;

namespace CoffeeBara.Gameplay.Util {
    public static class VectorExtensions {
        public static Vector3 ToGroundPlaneVector(this Vector2 vector2) {
            return new Vector3(vector2.x, 0, vector2.y);
        }
    }
}