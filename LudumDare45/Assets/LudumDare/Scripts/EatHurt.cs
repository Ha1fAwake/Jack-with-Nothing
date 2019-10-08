using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class EatHurt : UnityEngine.MonoBehaviour
    {

        public ConstStringChooser hurtPlayer;
        public ConstStringChooser hurtBoss;

        public FlowerIdentity flower;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(gameObject.name + "  碰到：" + other.transform.name);
            if (other.CompareTag("Player"))
            {
                Debug.Log("伤害玩家");
                CEventCenter.BroadMessage(hurtPlayer.StringValue, GameMgr.Instance.eatDamage);
            }else if (other.CompareTag("Boss"))
            {
                Debug.Log("伤害Boss");
                CEventCenter.BroadMessage(hurtBoss.StringValue, GameMgr.Instance.eatDamage);
            }

            if (transform.IsChildOf(other.transform))
                return;

            var identity = other.GetComponent<ItemIdentity>();
            if (identity)
            {
                if (flower.TryStartEating(identity.ItemInfo.id))
                {
                    Debug.Log("食人花主动吃物品");
                    Destroy(other.gameObject);
                }
            }
        }
    }
}