using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveY(-4, 0.4f).SetEase(Ease.InQuint);
    }
}
