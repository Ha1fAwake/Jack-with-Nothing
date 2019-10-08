using LudumDare.Scripts;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;

namespace UnityEngine.UI
{
    public class MusicIdentity : EatableIdentity
    {
        public ConstStringChooser messageToShot;
        public override void UseOnTo(ItemIdentity identity)
        {
            base.UseOnTo(identity);
            if (identity)
                return;

            CEventCenter.BroadMessage(messageToShot.StringValue);
            Debug.Log("广播消息：" + messageToShot.StringValue);
            BagData.ClearBag();
            Destroy(gameObject);
            

        }
    }
}