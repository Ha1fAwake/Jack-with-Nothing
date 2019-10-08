using UnityEngine;

namespace LudumDare.Scripts
{
    public class EggHurt : TriggerHurt
    {
        protected override void OnHurtBoss(GameObject boss)
        {
            base.OnHurtBoss(boss);
            Destroy(gameObject);
        }
    }
}