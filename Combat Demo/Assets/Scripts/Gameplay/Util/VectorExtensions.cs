using UnityEngine;

namespace CoffeeBara.Gameplay.Util {
    public static class VectorExtensions {
        public static Vector3 ToGroundPlaneVector(this Vector2 vector2) {
            return new Vector3(vector2.x, 0, vector2.y);
        }

        public static Vector3 Flatten(this Vector3 vector3) {
            vector3.y = 0;
            return vector3;
        }
    }
}