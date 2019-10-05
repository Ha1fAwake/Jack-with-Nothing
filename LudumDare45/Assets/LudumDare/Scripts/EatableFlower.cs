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
        public List<int> acceptableItemIds=new List<int>();
        public float eattingTime;
        
        public Sprite eatingSprite;
        private Sprite idleSprite;
        private SpriteRenderer spriteRenderer;
        private ItemIdentity itemIdentity;
        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            idleSprite = spriteRenderer.sprite;
            itemIdentity = GetComponent<ItemIdentity>();
        }

        
        
        public void TryStartEating(int id)
        {
            if (!acceptableItemIds.Contains(id))
                return;
            canEat = false;
            spriteRenderer.sprite = eatingSprite;
            MainLoop.Instance.ExecuteLater(OnFinishEating, eattingTime);
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