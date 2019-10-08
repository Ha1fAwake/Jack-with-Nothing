using System;
using LudumDare.Model;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using ReadyGamerOne.Script;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare.Scripts
{
    public class BossAIMgr : MonoBehaviour
    {
        public static bool goStateOne = true;
        public Sprite sleeping;
        public Sprite idle;
        public float sliderLoadTime;
        public SuperBloodBar playerSlider;
        public SuperBloodBar bossSlider;
        public ConstStringChooser messageHurtBoss;
        public ConstStringChooser messageHurtPlayer;
        public ConstStringChooser messageState1End;
        public ConstStringChooser messagePlayerDie;
        public ConstStringChooser messsageBossDie;
        
        public BossAi_1 ai1;
        public BossAi_2 ai2;

        private SpriteRenderer sr;
        
        private void Awake()
        {
            ai1.aiMgr = this;
            ai2.aiMgr = this;
            sr = GetComponent<SpriteRenderer>();
            if(goStateOne)
                CEventCenter.AddListener(messageState1End.StringValue, EnterStateTwo);
            
            CEventCenter.AddListener<float>(messageHurtPlayer.StringValue, (hurt) =>
            {
                
                playerSlider.Value -= hurt * GameMgr.Instance.playerScaler;
                if (playerSlider.Value <= 0)
                    CEventCenter.BroadMessage(messagePlayerDie.StringValue);
            });
            CEventCenter.AddListener<float>(messageHurtBoss.StringValue, (hurt) =>
            {
                bossSlider.Value -= hurt * GameMgr.Instance.bossScaler;
                if (bossSlider.Value <= 0)
                {
                    //胜利

                    CEventCenter.BroadMessage(messsageBossDie.StringValue);
                }
            });
            
        }


        private void EnterStateOne()
        {
            sr.sprite = sleeping;
            ai1.enabled = true;
            ai2.enabled = false;
        }

        private void EnterStateTwo()
        {
            if (sr == null)
                return;
            sr.sprite = idle;
            ai2.enabled = true;
            ai1.enabled = false;
        }

        private void Start()
        {               
            if(goStateOne)
                 EnterStateOne();
            bossSlider.Value = 0;
            playerSlider.Value = 0;
            MainLoop.Instance.UpdateForSeconds(LoadSlider, sliderLoadTime, () =>
            {
                timer = 0;
                if(!goStateOne)
                    EnterStateTwo();
            });
        }

        private float timer = 0;

        private void LoadSlider()
        {
            bossSlider.Value = timer / sliderLoadTime*bossSlider.maxValue;
            playerSlider.Value = timer / sliderLoadTime*playerSlider.maxValue;
            timer += Time.deltaTime;
        }
    }
}