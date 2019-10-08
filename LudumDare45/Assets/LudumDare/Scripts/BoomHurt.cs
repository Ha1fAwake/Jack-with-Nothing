using System;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using ReadyGamerOne.Utility;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class BoomHurt : UnityEngine.MonoBehaviour
    {

        public ConstStringChooser hurtPlayer;
        public ConstStringChooser hurtBoss;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("伤害玩家");
                CEventCenter.BroadMessage(hurtPlayer.StringValue, GameMgr.Instance.boomDamage);
            }else if (other.CompareTag("Boss"))
            {
                Debug.Log("伤害Boss");
                CEventCenter.BroadMessage(hurtBoss.StringValue, GameMgr.Instance.boomDamage);
            }

            if (transform.IsChildOf(other.transform))
                return;

            var iden = other.GetComponent<ItemIdentity>();
            if (iden)
            {
                if (iden is BoomIdentity)
                    return;
                Destroy(other.gameObject);
            }
        }


    }
}