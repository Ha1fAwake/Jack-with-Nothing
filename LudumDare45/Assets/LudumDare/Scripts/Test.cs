using System;
using LudumDare.Model;
using LudumDare.View;
using ReadyGamerOne.Utility;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class Test:MonoBehaviour
    {
        private void Start()
        {
            UIHelper.ShowItemInfo(ItemMgr.GetItem(0));
        }
    }
}