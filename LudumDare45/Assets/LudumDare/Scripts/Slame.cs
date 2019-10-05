using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using ReadyGamerOne.Script;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class Slame : UnityEngine.MonoBehaviour
    {
        public ConstStringChooser playerDeadMessage;
        [Header("潜伏时间")]
        public float waittingTime;
        
        private ItemIdentity itemIdentity;
        private void Start()
        {
            itemIdentity = GetComponent<ItemIdentity>();
            itemIdentity.onAddToBag += () =>
            {
                MainLoop.Instance.ExecuteLater(() =>
                {
                    if(itemIdentity.IsInBag)
                        CEventCenter.BroadMessage(playerDeadMessage.StringValue);
                }, waittingTime);
            };
        }
    }
}