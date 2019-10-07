using System;
using DG.Tweening;

namespace LudumDare.Scriptsq
{
    public class FullDown : UnityEngine.MonoBehaviour
    {
        public float targetY;
        private void Start()
        {
            transform.DOMoveY(targetY, 0.3f).SetEase(Ease.InQuint);
        }
    }
}