using System;
using LudumDare.Model;
using ReadyGamerOne.Const;
using ReadyGamerOne.Script;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class Test:MonoBehaviour
    {
        public ConstStringChooser item_1;
        public ConstStringChooser item_2;
        
        private void Start()
        {
//            AudioMgr.Instance.PlayEffect(AudioName.);
            
            BasicItem item;

            if (ItemMgr.IsExchangeOk(item_1.StringValue, item_2.StringValue))
            {
                Debug.Log(item_1.StringValue + "可以换" + item_2.StringValue);
            }
            else
            {
                
                Debug.Log(item_1.StringValue + "不能换" + item_2.StringValue);
            }

            if(ItemMgr.IsMergeOk(item_1.StringValue,item_2.StringValue,out item))
            {
                Debug.Log("合成成功，新物品名字："+item.ItemName);
                Debug.Log(item);
                Instantiate(item.Prefab, Vector3.zero, Quaternion.identity);
            }
            else
            {
                Debug.LogError("无法合成，物品名：" + item_1.StringValue + "  " + item_2.StringValue);
            }
        }
    }
}