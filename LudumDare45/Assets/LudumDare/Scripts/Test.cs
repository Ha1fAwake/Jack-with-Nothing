using System;
using LudumDare.Model;
using LudumDare.View;
using ReadyGamerOne.Const;
using ReadyGamerOne.Utility;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class Test:MonoBehaviour
    {
        public ConstStringChooser item_1;
        public ConstStringChooser item_2;
        private void Start()
        {
            var ans = ItemMgr.IsMergeOk(ItemMgr.Name2Id(item_1.StringValue), ItemMgr.Name2Id(item_2.StringValue));
            if (ans == -1)
            {
                Debug.LogError("合成异常:");
            }
            else
            {
                Debug.Log("合成成功");
                Debug.Log(ItemMgr.GetItem(ans));
            }
        }
    }
}