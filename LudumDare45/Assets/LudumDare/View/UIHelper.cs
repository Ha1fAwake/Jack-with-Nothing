using System;
using LudumDare.Model;
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
            var canvas = Object.FindObjectOfType<Canvas>();
            if (canvas == null)
                throw new Exception("显示UI，场景里，需要有Canvas");
            var obj = MemoryMgr.InstantiateGameObject(Const.ItemInfoPath, canvas.transform);
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