using System;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using ReadyGamerOne.Utility;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class BoomHurt : UnityEngine.MonoBehaviour
    {
        [Range(0, 1f)] public float bossHurt;
        [Range(0, 1f)] public float playerHurt;

        public ConstStringChooser hurtPlayer;
        public ConstStringChooser hurtBoss;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                CEventCenter.BroadMessage(hurtPlayer.StringValue, playerHurt);
            }else if (other.CompareTag("Boss"))
            {
                CEventCenter.BroadMessage(hurtBoss.StringValue, bossHurt);
            }

            if (other.GetComponent<ItemIdentity>())
                Destroy(other.gameObject);
        }


    }
}