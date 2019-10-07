using ReadyGamerOne.Global;
using ReadyGamerOne.MemorySystem;
using ReadyGamerOne.Script;
using UnityEngine;

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