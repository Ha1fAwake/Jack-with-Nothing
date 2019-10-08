using Fungus;
using ReadyGamerOne.Global;
using ReadyGamerOne.MemorySystem;
using ReadyGamerOne.Script;
using UnityEngine;
using UnityEngine.Events;

namespace LudumDare.Scripts
{
    public class GameMgr : BasicGameMgr
    {
        #region 单例
    
        private static GameMgr instance;
        public static GameMgr Instance
        {
            get { return instance; }
            private set { instance = value; }
        }
        protected override void Awake()
        {		
            if (instance &&this != Instance)
            {
                this.gameObject.SetActive(false);
                return;
            }
    
            instance = this;
            base.Awake();
        }

        #endregion

        public float eatDamage=10f;
        public float bulletDamage=10f;
        public float eggDamage=15f;
        public float boomDamage=5;
        public float playerScaler = 1.0f;
        public float bossScaler = 1.0f;
        
        protected override void WorkForOnlyOnce()
        {
            base.WorkForOnlyOnce();
            MemoryMgr.LoadAssetFromResourceDir<AudioClip>(
                typeof(AudioName),
                Const.AudioDir,
                (name,clip)=>
                AudioMgr.Instance.audioclips.Add(name,clip)
                );
        }


        protected override void OnAnySceneLoad()
        {
            base.OnAnySceneLoad();
            global::BagData.ClearBag();
        }

        protected override void AddGlobalScript()
        {
            base.AddGlobalScript();
            gameObject.AddComponent<AudioMgr>();
        }

        protected override void RefreshGlobalVar()
        {
            GlobalVar.G_Canvas = GameObject.Find("Canvas");
        }
    }
}