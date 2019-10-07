using System.Collections.Generic;
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
    public class SlameIdentity : EatableIdentity
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

        protected override void OnEat()
        {
            base.OnEat();
            
            Destroy(timer.timerObj);
        }

        private List<int> ids = new List<int>();
        public override void UseOnTo(ItemIdentity identity)
        {
            base.UseOnTo(identity);

            if (identity is SlameIdentity)
            {
                ids.Clear();
                ids.Add(ItemInfo.id);
                ids.Add(identity.ItemInfo.id);
                if(ids.Contains(4)&&ids.Contains(8))
                    global::BagData.MergeItem();
            }
            
            
        }
    }
}