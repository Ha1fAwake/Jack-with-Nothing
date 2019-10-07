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
        public static bool goStateOne = false;
        public MonoBehaviour checken;
        public Sprite sleeping;
        public Sprite idle;
        public float sliderLoadTime;
        public Slider bossSlider;
        [Range(0,1f)]public float bossSliderScaler=1.0f;
        public Slider playerSlider;
        [Range(0,1f)]public float playerSliderScaler = 1.0f;
        public ConstStringChooser messageHurtBoss;
        public ConstStringChooser messageHurtPlayer;
        public ConstStringChooser messageState1End;
        
        public BossAi_1 ai1;
        public BossAi_2 ai2;

        [Range(0,1f)] public float bulletHurt;
        [Range(0,1f)] public float eggHurt;
        [Range(0, 1f)] public float musicHurt;

        private SpriteRenderer sr;
        
        private void Awake()
        {
            ai1.aiMgr = this;
            ai2.aiMgr = this;
            checken.enabled = false;
            sr = GetComponent<SpriteRenderer>();
            if(goStateOne)
                CEventCenter.AddListener(messageState1End.StringValue, EnterStateTwo);
            CEventCenter.AddListener<float>(messageHurtPlayer.StringValue, (hurt) => playerSlider.value -= hurt*playerSliderScaler);
            CEventCenter.AddListener<float>(messageHurtBoss.StringValue, (hurt) =>bossSlider.value -= hurt*bossSliderScaler);
        }


        private void EnterStateOne()
        {
            sr.sprite = sleeping;
            ai1.enabled = true;
            ai2.enabled = false;
            checken.enabled = true;
        }

        private void EnterStateTwo()
        {
            sr.sprite = idle;
            ai2.enabled = true;
            ai1.enabled = false;
        }

        private void Start()
        {               
            if(goStateOne)
                 EnterStateOne();
            bossSlider.value = 0;
            playerSlider.value = 0;
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
            bossSlider.value = timer / sliderLoadTime;
            playerSlider.value = timer / sliderLoadTime;
            timer += Time.deltaTime;
        }
    }
}