﻿using UnityEngine;
using LudumDare.Scripts;
using System;

public class RandomFly : MonoBehaviour {

    public static event Action<Collision2D> onColliderEnter;
    public int CollisionNum = 10;
    public float Speed = 5;
    private int CountCollision = 0;

    private void Start() {
        Vector3 SpeedVec = new Vector3(0, 0, 0);
        SpeedVec.x = UnityEngine.Random.Range(-1.0f, 1.0f);
        SpeedVec.y = UnityEngine.Random.Range(-1.0f, 0.0f);
        SpeedVec = SpeedVec.normalized * Speed;
        GetComponent<Rigidbody2D>().velocity = SpeedVec;
    }

    private void OnCollisionEnter2D(Collision2D c) {
        CountCollision++;
        onColliderEnter?.Invoke(c);
        if (CountCollision == CollisionNum) {
            BossAi_1.DeadBullet++;
            Destroy(gameObject);
        }
    }
}