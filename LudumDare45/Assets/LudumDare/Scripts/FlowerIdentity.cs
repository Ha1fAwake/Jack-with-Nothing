using System;
using System.Collections.Generic;
using LudumDare.Model;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using ReadyGamerOne.Script;
using UnityEngine;

namespace LudumDare.Scripts
{
    [RequireComponent(typeof(Timer))]
    public class FlowerIdentity:EatableIdentity
    {
        public ConstStringChooser playerDeadMessage;
        public ConstStringChooser chewingFlower;
        public bool canEat = true;
        [Header("可以吃的物品ID")]
        public List<int> acceptableItemIds=new List<int>();
        [Header("消化时间")]
        public float eattingTime;
        private SpriteRenderer spriteRenderer;

        public override BasicItem ItemInfo
        {
            get
            {
                if (canEat)
                    return ItemMgr.GetItem(itemName.StringValue);
                else
                    return ItemMgr.GetItem(chewingFlower.StringValue);
            }
        }

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// 添加物品到背包回调
        /// </summary>
        public override void OnAddToBag()
        {
            base.OnAddToBag();
            if (canEat)
            {
                //你完了，这食人花都敢拿
                CEventCenter.BroadMessage(playerDeadMessage.StringValue);
            }
        }

        private Timer timer;
        
        /// <summary>
        /// 尝试吃某个物品
        /// 如果物品在可吃列表就会吃，否则返回False
        /// 这函数应该在和食人花喂食的时候调用
        /// </summary>
        /// <param name="id"></param>
        public bool TryStartEating(int id)
        {
            Debug.Log("试吃");
            if (!canEat)
                return false;
            if (!acceptableItemIds.Contains(id))
                return false;

            Debug.Log("真吃了");
            canEat = false;
            spriteRenderer.sprite = ItemMgr.GetItem(chewingFlower.StringValue).infoSprite;
            timer = GetComponent<Timer>();
                timer.StartTimer(eattingTime);
            MainLoop.Instance.ExecuteLater(OnFinishEating, eattingTime);
            return true;
        }

        /// <summary>
        /// 结束消化回调
        /// </summary>
        private void OnFinishEating()
        {
            if (IsInBag)
            {
                //贪吃蛇居然还在身上，你完了
                CEventCenter.BroadMessage(playerDeadMessage.StringValue);
            }

            canEat = true;
            spriteRenderer.sprite = ItemMgr.GetItem(itemName.StringValue).infoSprite;

        }


        protected override void OnEat()
        {
            base.OnEat();
            Destroy(timer.timerObj);
            timer = null;
        }
    }
}