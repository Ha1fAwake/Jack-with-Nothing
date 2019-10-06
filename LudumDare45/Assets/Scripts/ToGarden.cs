using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGarden : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Vector3 nextPosition = new Vector3(2,7,0);
            collision.transform.position = nextPosition;

            cam2.SetActive(true);
            cam1.SetActive(false);
        }
    }
}
