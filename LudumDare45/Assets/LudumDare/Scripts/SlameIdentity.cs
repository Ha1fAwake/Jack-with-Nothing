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
        private Coroutine cor;
        public override void OnAddToBag()
        {
            base.OnAddToBag();
            timer = GetComponent<Timer>();
            timer.StartTimer(waittingTime);
            cor = MainLoop.Instance.ExecuteLater(() =>
            {
                if (IsInBag)
                {
                    Debug.Log("玩家被背包里的史莱姆搞死");
                    CEventCenter.BroadMessage(playerDeadMessage.StringValue);

                }
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

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (cor != null)
                MainLoop.Instance.StopCoroutine(cor);
        }
    }
}