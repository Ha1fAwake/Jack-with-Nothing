using UnityEngine;

namespace ReadyGamerOne.Utility
{
    public static class GizmosUtil
    {
        public static void DrawSign(Vector3 pos,Color color,float signalSize=1.0f)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(pos + Vector3.left * signalSize, pos + Vector3.right * signalSize);
            Gizmos.DrawLine(pos + Vector3.up * signalSize, pos + Vector3.down * signalSize);
        }
    }
}