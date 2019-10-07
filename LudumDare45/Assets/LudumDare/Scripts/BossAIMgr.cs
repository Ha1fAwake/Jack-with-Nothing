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
        
        private void Awake()
        {
            ai1.aiMgr = this;
            ai1.enabled = false;
            ai2.aiMgr = this;
            ai2.enabled = false;
            
            CEventCenter.AddListener(messageState1End.StringValue, () =>
            {
                ai1.enabled = false;
                ai2.enabled = true;
            });
            CEventCenter.AddListener<float>(messageHurtPlayer.StringValue, (hurt) => playerSlider.value -= hurt*playerSliderScaler);
            CEventCenter.AddListener<float>(messageHurtBoss.StringValue, (hurt) =>bossSlider.value -= hurt*bossSliderScaler);
            
        }

        private void Start()
        {
            bossSlider.value = 0;
            playerSlider.value = 0;
            MainLoop.Instance.UpdateForSeconds(LoadSlider, sliderLoadTime, () =>
            {
                timer = 0;
                ai1.enabled = true;
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