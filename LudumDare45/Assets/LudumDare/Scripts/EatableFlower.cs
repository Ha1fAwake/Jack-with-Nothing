using System;
using System.Collections.Generic;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using ReadyGamerOne.Script;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class EatableFlower:MonoBehaviour
    {
        public ConstStringChooser playerDeadMessage;
        public bool canEat = true;
        [Header("可以吃的物品ID")]
        public List<int> acceptableItemIds=new List<int>();
        [Header("消化时间")]
        public float eattingTime;
        [Header("吃饱图片")]
        public Sprite eatingSprite;
        private Sprite idleSprite;
        private SpriteRenderer spriteRenderer;
        private ItemIdentity itemIdentity;
        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            idleSprite = spriteRenderer.sprite;
            itemIdentity = GetComponent<ItemIdentity>();
            itemIdentity.onAddToBag += () =>
            {
                if (canEat)
                {
                    //你完了，这食人花都敢拿
                    CEventCenter.BroadMessage(playerDeadMessage.StringValue);
                }
            };
        }

        
        /// <summary>
        /// 尝试吃某个物品
        /// 如果物品在可吃列表就会吃，否则返回False
        /// 这函数应该在和食人花喂食的时候调用
        /// </summary>
        /// <param name="id"></param>
        public bool TryStartEating(int id)
        {
            if (!acceptableItemIds.Contains(id))
                return false;
            canEat = false;
            spriteRenderer.sprite = eatingSprite;
            MainLoop.Instance.ExecuteLater(OnFinishEating, eattingTime);
            return true;
        }

        private void OnFinishEating()
        {
            if (itemIdentity.IsInBag)
            {
                //贪吃蛇居然还在身上，你完了
                CEventCenter.BroadMessage(playerDeadMessage.StringValue);
            }

            canEat = true;
            spriteRenderer.sprite = idleSprite;

        }

    }
}