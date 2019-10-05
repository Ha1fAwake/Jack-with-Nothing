using System;
using UnityEngine;

namespace ReadyGamerOne.Global
{
    public static partial class GlobalVar
    {
        public static GameObject G_Canvas;

        public static Vector3 GCanvasButton => G_Canvas.transform.position - new Vector3(0, Screen.height, 0);

        public static Vector3 GCanvasTop => G_Canvas.transform.position + new Vector3(0, Screen.height, 0);

        public static Vector3 GCanvasLeft => G_Canvas.transform.position - new Vector3(Screen.width, 0, 0);

        public static Vector3 GCanvasRight => G_Canvas.transform.position + new Vector3(Screen.width, 0, 0);
    }
}
