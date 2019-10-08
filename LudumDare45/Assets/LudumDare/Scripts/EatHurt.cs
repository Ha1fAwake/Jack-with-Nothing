using UnityEngine;

namespace LudumDare.Scripts
{
    public class EatHurt : TriggerHurt
    {
        public FlowerIdentity flower;
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (transform.IsChildOf(other.transform))
                return;

            var identity = other.GetComponent<ItemIdentity>();
            if (identity)
            {
                if (flower.TryStartEating(identity.ItemInfo.id))
                {
//                    Debug.Log("食人花主动吃物品");
                    Destroy(other.gameObject);
                }
            }
        }
    }
}