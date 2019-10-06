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
            GameObject prefab;
            int targetId;
            
            if(ItemMgr.IsMergeOk(item_1.StringValue,item_2.StringValue,out targetId, out prefab))
            {
                Debug.Log("合成成功，新物品ID："+targetId);
                Debug.Log(ItemMgr.GetItem(targetId));
                Instantiate(prefab, Vector3.zero, Quaternion.identity);
            }
            else
            {
                Debug.LogError("无法合成");
            }
        }
    }
}