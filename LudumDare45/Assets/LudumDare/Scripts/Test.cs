using System;
using LudumDare.Model;
using ReadyGamerOne.Utility;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class Test:MonoBehaviour
    {
        private void Start()
        {
            WindowsUtil.MessageBox(ItemMgr.GetItem(0));
        }
    }
}