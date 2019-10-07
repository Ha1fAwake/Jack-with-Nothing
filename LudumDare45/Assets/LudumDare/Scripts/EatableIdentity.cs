using UnityEngine;

namespace LudumDare.Scripts
{
    public class EatableIdentity :ItemIdentity
    {
        protected virtual void OnEat()
        {
            
        }
        public override void UseOnTo(ItemIdentity identity)
        {
            base.UseOnTo(identity);
            Debug.Log("使用物品");
            var flower = identity as FlowerIdentity;
            if (flower)
            {
                if (flower.TryStartEating(ItemInfo.id))
                {
                    OnEat();
                    Destroy(gameObject);
                    global::BagData.ClearBag();
                    return;
                }
            }
        }
    }
}