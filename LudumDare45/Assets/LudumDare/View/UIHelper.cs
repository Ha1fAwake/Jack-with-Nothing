using System;
using LudumDare.Model;
using ReadyGamerOne.Global;
using ReadyGamerOne.MemorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace LudumDare.View
{
    public static class UIHelper
    {
        private static GameObject lastObj;

        public static GameObject ShowItemInfo(BasicItem item)
        {
            var obj = MemoryMgr.InstantiateGameObject(Const.ItemInfoPath,GlobalVar.G_Canvas.transform);
            obj.transform.Find("Image").GetComponent<Image>().sprite = item.infoSprite;
            obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.ItemName;
            obj.transform.Find("ItemDescription").GetComponent<TextMeshProUGUI>().text = item.descriptions;

            lastObj = obj;
            
            return obj;
        }

        public static void Hide()
        {
            lastObj?.SetActive(false);
        }
    }
}