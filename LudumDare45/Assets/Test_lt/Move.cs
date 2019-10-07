using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(-2, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
