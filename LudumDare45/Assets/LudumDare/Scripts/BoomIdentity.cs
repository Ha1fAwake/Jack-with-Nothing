using System;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using ReadyGamerOne.Script;
using UnityEngine;

namespace LudumDare.Scripts
{
    /// <summary>
    /// 炸弹信息
    /// 已出现就开始计时
    /// </summary>
    [RequireComponent(typeof(Timer))]
    public class BoomIdentity :ItemIdentity
    {
        public ConstStringChooser messagePlayDead;
        public float timeToBoom;
        private Timer timer;
        public GameObject Parital;
        public GameObject horizontal;
        public GameObject vertical;
        public GameObject horAni;
        public GameObject verAni;
        public float hideDelayTime;

        protected override void Start()
        {
            base.Start();
            timer = GetComponent<Timer>();
//            Debug.Log("StartTimer");
            timer.StartTimer(timeToBoom);
            MainLoop.Instance.ExecuteLater(OnBoom, timeToBoom);
        }

        private void OnBoom()
        {
//            Debug.Log("炸弹爆炸");
            if (this == null)
                return;
            if (IsInBag)
            {
//                Debug.Log("广播");
                Debug.Log("玩家被炸死");
                CEventCenter.BroadMessage(messagePlayDead.StringValue);
            }

            GetComponent<SpriteRenderer>().enabled = false;
            Parital.SetActive(true);
            horizontal.SetActive(true);
            vertical.SetActive(true);
            horAni.SetActive(true);
            verAni.SetActive(true);

            MainLoop.Instance.ExecuteLater(() =>
            {
                if(this!=null)
                    Destroy(gameObject);
            }, hideDelayTime);
        }
    }
}