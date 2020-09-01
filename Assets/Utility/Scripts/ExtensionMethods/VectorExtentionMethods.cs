using UnityEngine;

namespace Util {
    public static class VectorExtentionMethods {
        public static Vector3 ToDirection(this Vector2 a) => new Vector3(a.x, 0, a.y);
        public static Vector3 Horizontal(this Vector3 a) => new Vector3(a.x, 0, a.z);
    }
}