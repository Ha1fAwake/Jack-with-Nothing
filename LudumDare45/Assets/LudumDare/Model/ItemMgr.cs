using System;
using System.Collections.Generic;
using System.IO;

#if UNITY_EDITOR
    
using UnityEditor;
#endif
using UnityEngine;

namespace LudumDare.Model
{
    public class ItemMgr:ScriptableObject
    {
#if UNITY_EDITOR
        [MenuItem("ReadyGamerOne/Create/ItemMgr")]
        public static void CreateAsset()
        {

            var path = "Assets/Resources";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            AssetDatabase.CreateAsset(CreateInstance<ItemMgr>(), path+"/ItemMgr.asset");
            AssetDatabase.Refresh();

            Selection.activeObject = AssetDatabase.LoadAssetAtPath<ItemMgr>(path+"/ItemMgr.asset");
        }        
#endif

        
        private static ItemMgr _instance;
        private static ItemMgr Instance
        {
            get
            {

                if (!_instance)
                {
//                    if(File.Exists("Assets/Resources/ItemMgr.asset"))
                    _instance = Resources.Load<ItemMgr>("ItemMgr");
                }
#if UNITY_EDITOR
                if (!_instance)
                {
                    var path = "Assets/Resources";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    _instance = CreateInstance<ItemMgr>();
                    AssetDatabase.CreateAsset(_instance, path+"/ItemMgr.asset");
                }
#endif
                if (_instance == null)
                    throw new Exception("初始化失败");

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

            throw new Exception("没有这个ID的物体:" + id);
        }

        public static BasicItem GetItem(string name)
        {
            foreach (var VARIABLE in ItemMgr.Instance.itemInfos)
            {
                if (VARIABLE.ItemName == name)
                    return VARIABLE;
            }

            throw new Exception("没有这个ID的物体");
        }
        
    }
}