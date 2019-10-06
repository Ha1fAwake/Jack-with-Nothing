using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToHome : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Vector3 nextPosition = new Vector3(0, 4, 0);
            collision.transform.position = nextPosition;

            cam1.SetActive(true);
            cam2.SetActive(false);
        }
    }
}