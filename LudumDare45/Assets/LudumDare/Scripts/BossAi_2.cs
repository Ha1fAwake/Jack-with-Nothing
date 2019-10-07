using System;
using System.Collections.Generic;
using LudumDare.Model;
using ReadyGamerOne.Const;
using ReadyGamerOne.Script;
using ReadyGamerOne.Utility;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LudumDare.Scripts
{
    [Serializable]
    public class ItemCreatable
    {
        public ConstStringChooser ItemName;
        public int weight;
    } 
        
        
        
    public class BossAi_2 : UnityEngine.MonoBehaviour
    {
        public int mapUnitSize;
        public Rect rect;
        public float duringTime;
        public float createCount;
        public List<ItemCreatable> createInfos = new List<ItemCreatable>();
        private List<Vector2> weightRange=new List<Vector2>();
        private float timer = 0;

        private void Start()
        {
            timer = duringTime;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > duringTime)
            {
                CreateItems();

                timer = 0;
            }
        }

        private void CreateItems()
        {
            for (int i = 0; i < createCount; i++)
            {
                var item = GetRandomItem();
                Instantiate(item.Prefab, GetRandomPos(), Quaternion.identity);
            }
        }


        private void OnDrawGizmos()
        {
            GizmosUtil.DrawRect(rect);
        }

        /// <summary>
        /// 获取一个随机物品
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private BasicItem GetRandomItem()
        {
            weightRange.Clear();
            var allWeight = 0f;
            foreach (var VARIABLE in createInfos)
            {
                allWeight += VARIABLE.weight;
            }

            var nowWeight = 0f;
            foreach (var VARIABLE in createInfos)
            {
                var w = new Vector2(nowWeight / allWeight, (nowWeight + VARIABLE.weight) / allWeight);
                weightRange.Add(w);
                nowWeight += VARIABLE.weight;
            }

            var r = Random.Range(0f, 1f);
            for (var i = 0; i < weightRange.Count; i++)
            {
                if (r < weightRange[i].y && r > weightRange[i].x)
                {
                    return ItemMgr.GetItem(createInfos[i].ItemName.StringValue);
                }
            }
            
            throw new Exception("获取物品异常");
        }
        /// <summary>
        /// 获取随机位置
        /// </summary>
        /// <returns></returns>
        private Vector3 GetRandomPos()
        {
            var x_Random = Random.Range(rect.x, rect.x + rect.width);
            var y_Random = Random.Range(rect.y, rect.y + rect.height);

            var x = Mathf.RoundToInt(x_Random / mapUnitSize) * mapUnitSize;
            var y = Mathf.RoundToInt(y_Random / mapUnitSize) * mapUnitSize;

//            Debug.Log(x + "  " + y);
            return new Vector3(x, y, 0);
        }


    }
}