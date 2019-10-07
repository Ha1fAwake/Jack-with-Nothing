using System;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class InputToCEventCenter : UnityEngine.MonoBehaviour
    {
        public ConstStringChooser messageToTrigger;
        public KeyCode key;

        private void Update()
        {
            if (Input.GetKeyDown(key))
                CEventCenter.BroadMessage(messageToTrigger.StringValue);
        }
    }
}