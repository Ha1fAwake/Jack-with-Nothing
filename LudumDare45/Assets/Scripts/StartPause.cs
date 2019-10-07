using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPause : MonoBehaviour
{
    public GameObject player;

    private void OnStart()
    {
        player.AddComponent<PlayerMove2>();
    }
}
