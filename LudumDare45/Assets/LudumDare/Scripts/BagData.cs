using System.Collections.Generic;
using LudumDare.Model;
using ReadyGamerOne.Common;
using UnityEngine;
using UnityEngine.Assertions;

namespace LudumDare.Scripts
{
    public class BagData : MonoSingleton<BagData>
    {
        private List<int> itemIds = new List<int>();

        public int currentIndex = -1;
        public int CurrentId => itemIds[currentIndex];

        public BasicItem CurrentItem => ItemMgr.GetItem(CurrentId);
        
        public void AddItem(int itemId)
        {
            Assert.IsTrue(itemIds.Contains(itemId)==false);

            itemIds.Add(itemId);

            currentIndex = itemIds.Count - 1;
        }

        public void SwitchItem(ItemIdentity itemIdentity, Transform player)
        {
            var item = CurrentItem;
            itemIds.Remove(CurrentId);
            


        }
        
        
        
        
        
    }
}