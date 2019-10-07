using System;
using ReadyGamerOne.EditorExtension;
using ReadyGamerOne.Script;

namespace LudumDare.Scripts
{
    public class SceneMgr : UnityEngine.MonoBehaviour
    {
        public StringChooser sceneBgm = new StringChooser(typeof(AudioName));

        private void Start()
        {
            AudioMgr.Instance.PlayBgm(sceneBgm.StringValue);
        }
    }
}