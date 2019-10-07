using System;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class PlayerHandler : UnityEngine.MonoBehaviour
    {
        public ConstStringChooser messageToListen;
        private void Start()
        {
//            Debug.Log("监听");
            CEventCenter.AddListener(messageToListen.StringValue,OnMessageCome);
        }

        private void OnMessageCome()
        {
            Debug.Log("玩家应该死亡");
        }
    }
}