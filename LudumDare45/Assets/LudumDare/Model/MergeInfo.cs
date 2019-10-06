using System;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare.Model
{
    [Serializable]
    public class MergeInfo
    {
        public ItemMgr mgr;
        [SerializeField] private int targetIdIndex;
        [SerializeField] private int sourId1Index;
        [SerializeField] private int sourId2Index;

        public List<int> SourIds
        {
            get
            {
                var list = new List<int>();
                list.Add(SourId1);
                list.Add(SourId2);
                return list;
            }
        }
        public int TargetId => mgr.IDInts[targetIdIndex];
        public int SourId1 => mgr.IDInts[sourId1Index];
        public int SourId2=>mgr.IDInts[sourId2Index];
    }
}