using System;
using LudumDare.Model;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class BossAIMgr : MonoBehaviour
    {
        private void Start()
        {
            RandomFly.onColliderEnter += OnBulletEnter;
        }
        
        private void OnBulletEnter(Collision2D collision)
        {
            
        }
    }
}