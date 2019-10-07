using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using ReadyGamerOne.Script;
using UnityEngine;

namespace LudumDare.Scripts
{
    /// <summary>
    /// 史莱姆信息
    /// 有一个潜伏时间，放到背包开始计时，没有拿出来，你就会死亡
    /// </summary>
    [RequireComponent(typeof(Timer))]
    public class SlameIdentity : ItemIdentity
    {
        public ConstStringChooser playerDeadMessage;
        [Header("潜伏时间")]
        public float waittingTime;

        private Timer timer;
        public override void OnAddToBag()
        {
            base.OnAddToBag();
            timer = GetComponent<Timer>();
            timer.StartTimer(waittingTime);
            MainLoop.Instance.ExecuteLater(() =>
            {
                if(IsInBag)
                    CEventCenter.BroadMessage(playerDeadMessage.StringValue);
            }, waittingTime);
        }

        public override void OnLeaveBag()
        {
            base.OnLeaveBag();
            timer.Stop();
        }

        public override void UseOnTo(ItemIdentity identity)
        {
            Debug.Log("使用");
            var flower = identity as FlowerIdentity;
            if (flower)
            {
                if (flower.TryStartEating(ItemInfo.id))
                {
                    Destroy(timer.timerObj);
                    Destroy(gameObject);
                }
            }
        }
    }
}