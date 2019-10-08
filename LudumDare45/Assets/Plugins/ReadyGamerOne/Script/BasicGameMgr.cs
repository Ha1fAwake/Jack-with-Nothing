using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ReadyGamerOne.Script
{
    /// <summary>
    /// 使用SceneMgr推荐用脚本继承这个类
    /// </summary>
    public class BasicGameMgr:MonoBehaviour
    {
        public static event Action onDrawGizomos;
        
            
        protected virtual void Awake()
        {
            SceneManager.sceneLoaded += (s,d) => OnAnySceneLoad();
            SceneManager.sceneUnloaded += (s) => OnAnySceneUnload();
            AddGlobalScript();
            WorkForOnlyOnce();
        }

        protected virtual void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        protected virtual void WorkForOnlyOnce()
        {
            print("work for only once");
        }

        protected virtual void OnAnySceneLoad()
        {
            RefreshGlobalVar();
        }

        protected virtual void OnAnySceneUnload()
        {
            MainLoop.Clear();
        }

        protected virtual void AddGlobalScript()
        {
            this.gameObject.AddComponent<MainLoop>();
        }

        protected virtual void RefreshGlobalVar()
        {
            
        }

        private void OnDrawGizmos()
        {
            onDrawGizomos?.Invoke();
        }
    }
}