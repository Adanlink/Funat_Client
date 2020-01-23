using UnityEngine;

namespace EntityController.Entity
{
    public static class PositionHelper
    {
        public static ushort CoordinateMultiplier = 10;
        public static void SetPosition(this Transform transform, float x, float y)
        {
            transform.position = new Vector3(x /** CoordinateMultiplier*/, y /** CoordinateMultiplier*/, 0);
        }
    }
}