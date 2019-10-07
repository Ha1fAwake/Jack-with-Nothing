using System;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;

namespace UnityEngine.UI
{
    public class JJ : UnityEngine.MonoBehaviour
    {
        public ConstStringChooser messageToShoot;

        private void Start()
        {
            CEventCenter.AddListener(messageToShoot.StringValue,Shot);
        }

        private void Shot()
        {
            
        }
    }
}