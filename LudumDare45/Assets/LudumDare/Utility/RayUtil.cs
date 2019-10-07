using UnityEngine;

namespace LudumDare.Utility
{
    public static class RayUtil
    {
        public static bool IsPositionNone2D(Vector3 pos,LayerMask testLayer)
        {
            var hit = Physics2D.RaycastAll(pos, Vector2.zero,testLayer);
            return hit.Length == 0;
        }
    }
}