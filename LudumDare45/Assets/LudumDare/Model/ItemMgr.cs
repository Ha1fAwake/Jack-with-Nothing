using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace LudumDare.Model
{
    public class ItemMgr:ScriptableObject
    {
        [MenuItem("ReadyGamerOne/Create/ItemMgr")]
        public static void CreateAsset()
        {

            AssetDatabase.CreateAsset(CreateInstance<ItemMgr>(), "Assets/ItemMgr.asset");
            AssetDatabase.Refresh();

            Selection.activeObject = AssetDatabase.LoadAssetAtPath<ItemMgr>("Assets/ItemMgr.asset");
        }
        
        private static ItemMgr _instance;
        private static ItemMgr Instance
        {
            get
            {

                if (!_instance)
                {
                    if(File.Exists("Assets/ItemMgr.asset"))
                        _instance = UnityEditor.AssetDatabase.LoadAssetAtPath<ItemMgr>("Assets/ItemMgr.asset");
                }
#if UNITY_EDITOR
                if (!_instance)
                {
                    _instance = CreateInstance<ItemMgr>();
                    UnityEditor.AssetDatabase.CreateAsset(_instance, "Assets/ItemMgr.asset");
                }
#endif
                if (_instance == null)
                    throw new System.Exception("初始化失败");

                return _instance;
            }
        }

        public List<BasicItem> itemInfos = new List<BasicItem>(); 
        
        public int GetID()
        {
            var index = 0;
            while (true)
            {
                var ok = true;
                foreach (var unit in itemInfos)
                {
                    if (index == unit.id)
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                    break;
                index++;
            }

            return index;
        }
        
        
        public static BasicItem GetItem(int id)
        {
            foreach (var VARIABLE in ItemMgr.Instance.itemInfos)
            {
                if (VARIABLE.id == id)
                    return VARIABLE;
            }

            throw new Exception("没有这个ID的物体");
        } 
        
    }
}