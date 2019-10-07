using ReadyGamerOne.Common;
using ReadyGamerOne.Const;

namespace UnityEngine.UI
{
    public class MusicIdentity : ItemIdentity
    {
        public ConstStringChooser messageToShot;
        public override void UseOnTo(ItemIdentity identity)
        {
            if (identity)
                return;

            CEventCenter.BroadMessage(messageToShot.StringValue);
        }
    }
}