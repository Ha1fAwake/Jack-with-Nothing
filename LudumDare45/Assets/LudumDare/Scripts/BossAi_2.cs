using System;
using System.Collections.Generic;
using LudumDare.Model;
using LudumDare.Utility;
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
        public static int aliveCount = 0;
        [HideInInspector] public BossAIMgr aiMgr;
        public LayerMask testLayer;
        public int mapUnitSize;
        public Vector2Int map;
        public Vector2Int offset;
        private Rect rect;
        public int itemCountAtOneTime;
        public float duringTime;
        public float createCount;
        public List<ItemCreatable> createInfos = new List<ItemCreatable>();
        private List<Vector2> weightRange=new List<Vector2>();
        private float timer = 0;

        private List<Vector3> posList=new List<Vector3>();
        private Vector3 startPos;
        private void Start()
        {
            aliveCount = 0;
            startPos =new Vector3(offset.x*mapUnitSize,offset.y*mapUnitSize,0) - new Vector3(map.x * mapUnitSize / 2f, map.y * mapUnitSize / 2f, 0);
            
            for (var i = 0; i < map.x; i++)
            {
                for (var j = 0; j < map.y; j++)
                {
                    var target = startPos + new Vector3(i * mapUnitSize, j * mapUnitSize, 0);
                    posList.Add(target);
                }
            }

            timer = duringTime;
        }

        private void Update()
        {
//            Debug.Log("AliveCount: " + aliveCount + "  itemCountAtOneTime: " + itemCountAtOneTime);
            timer += Time.deltaTime;
            if (timer > duringTime)
            {
                CreateItems();

                timer = 0;
            }
        }

        private void CreateItems()
        {
            
            for (int i =aliveCount ; i < itemCountAtOneTime; i++)
            {
                var item = GetRandomItem();
                Debug.Log("添加");
                Instantiate(item.Prefab, GetRandomPos(), Quaternion.identity);
            }
        }


        private void OnDrawGizmos()
        {
            startPos =new Vector3(offset.x*mapUnitSize,offset.y*mapUnitSize,0) - new Vector3(map.x * mapUnitSize / 2f, map.y * mapUnitSize / 2f, 0);
            rect = new Rect(startPos, new Vector2(map.x*mapUnitSize, mapUnitSize * map.y));
            GizmosUtil.DrawSign(startPos);
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
            Vector3 pos;
            do
            {
                var index = Random.Range(0, posList.Count - 1);
                Debug.Log("poslist:" + posList.Count + "  index:"+index);
                pos = posList[index];
            } while (!RayUtil.IsPositionNone2D(pos, testLayer));

            return pos;
        }


    }
}