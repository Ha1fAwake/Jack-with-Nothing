using System;
using System.Collections.Generic;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Assertions;

namespace LudumDare.Model
{
    public class ItemMgr:ScriptableObject
    {
        #region Editor

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

        #endregion

        #region 单例

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

        #endregion
        
        #region UsedByEditor

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
        /// <summary>
        /// ID字符串
        /// </summary>
        public string[] ItemNames
        {
            get
            {
                var strs = new string[itemInfos.Count];
                for (var i = 0; i < itemInfos.Count; i++)
                    strs[i] = itemInfos[i].ItemName;
                return strs;
            }
        }

        public int[] IDInts
        {
            get
            {
                var ints = new int[itemInfos.Count];
                for (var i = 0; i < ints.Length; i++)
                    ints[i] = itemInfos[i].id;
                return ints;
            }
        }        

        #endregion

        #region DataStructure

        public List<BasicItem> itemInfos = new List<BasicItem>();
        public List<MergeInfo> merageInfos = new List<MergeInfo>();        

        #endregion


        /// <summary>
        /// 物品库中是否有这个ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool ContansID(int id)
        {
            foreach (var VARIABLE in Instance.itemInfos)
            {
                if (VARIABLE.id == id)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 仓库中是否包含这个名字
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ContansName(string name)
        {
            foreach (var VARIABLE in Instance.itemInfos)
            {
                if (VARIABLE.ItemName == name)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 根据名字获取ID
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public static int Name2Id(string itemName)
        {
            foreach (var VARIABLE in Instance.itemInfos)
            {
                if (VARIABLE.ItemName == itemName)
                    return VARIABLE.id;
            }

            return -1;
        }
        

        /// <summary>
        /// 获取物品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
            foreach (var VARIABLE in Instance.itemInfos)
            {
                if (VARIABLE.ItemName == name)
                    return VARIABLE;
            }

            throw new Exception("没有这个ID的物体：" + name);
        }

        /// <summary>
        /// 合成是否合法
        /// </summary>
        /// <param name="id_1"></param>
        /// <param name="id_2"></param>
        /// <returns>合法返回正确ID，不合法，返回-1</returns>
        public static bool IsMergeOk(int id_1, int id_2,out BasicItem target)
        {
            if(id_1==-1 || id_2==-1)
                throw new Exception("没有这样的ID: "+id_1+"  "+id_2);
            foreach (var VARIABLE in ItemMgr.Instance.merageInfos)
            {
                var ids = VARIABLE.SourIds;
                if (ids.Contains(id_1) && ids.Contains(id_2))
                {
                    target = ItemMgr.GetItem(VARIABLE.TargetId);
                    return true;
                }
            }

            target = null;
            return false;
        }
        public static bool IsMergeOk(string itemName1, string itemName2,out BasicItem targetId)
        {
            return IsMergeOk(ItemMgr.Name2Id(itemName1), ItemMgr.Name2Id(itemName2), out targetId);
        }

        /// <summary>
        /// 置换是否合理
        /// </summary>
        /// <param name="ownId"></param>
        /// <param name="targetId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool IsExchangeOk(int ownId, int targetId)
        {
            if (!ContansID(ownId) || !ContansID(targetId))
                throw new Exception("ID 不对：" + ownId + "  " + targetId);

            var info = GetItem(targetId);
            var conditions = info.exchangeCondition;
            
            //如果条件为空，表示没有置换条件
            if (string.IsNullOrEmpty(conditions))
                return true;

            return conditions.Contains(ownId.ToString());
        }
        public static bool IsExchangeOk(string ownName, string targetName)
        {
            return IsExchangeOk(Name2Id(ownName), Name2Id(targetName));
        }
    }
}