using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class TriggerHurt : UnityEngine.MonoBehaviour
    {
        public ConstStringChooser hurtPlayer;
        public ConstStringChooser hurtBoss;

        protected virtual void OnHurtPlayer(GameObject player)
        {
            
        }

        protected virtual void OnHurtBoss(GameObject boss)
        {
            
        }
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
//                Debug.Log("伤害玩家");
                OnHurtPlayer(other.gameObject);
                CEventCenter.BroadMessage(hurtPlayer.StringValue, GameMgr.Instance.boomDamage);
            }
            else if (other.CompareTag("Boss"))
            {
//                Debug.Log("伤害Boss");
                OnHurtBoss(other.gameObject);
                CEventCenter.BroadMessage(hurtBoss.StringValue, GameMgr.Instance.boomDamage);
            }
        }
    }
}