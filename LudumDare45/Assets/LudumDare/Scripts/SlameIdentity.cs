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
    public class SlameIdentity : ItemIdentity
    {
        public ConstStringChooser playerDeadMessage;
        [Header("潜伏时间")]
        public float waittingTime;
        
        public override void OnAddToBag()
        {
            base.OnAddToBag();
            MainLoop.Instance.ExecuteLater(() =>
            {
                if(IsInBag)
                    CEventCenter.BroadMessage(playerDeadMessage.StringValue);
            }, waittingTime);
        }

    }
}