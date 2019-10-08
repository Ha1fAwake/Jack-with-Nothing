using LudumDare.Scriptsq;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using ReadyGamerOne.Global;
using ReadyGamerOne.Script;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LudumDare.Scripts
{
    public class PlayerHandler :MonoBehaviour
    {
        public ConstStringChooser playerDieMessage;
        public ConstStringChooser bossDieMessage;
        public GameObject dieSignPrefab;
        public GameObject victoryPrefab;
        public Vector3 offset=new Vector3(0,3,0);
        public GameObject ExitButton;
        private void Start()
        {
//            Debug.Log("监听");
            CEventCenter.AddListener(playerDieMessage.StringValue,OnMessageCome);
            CEventCenter.AddListener(bossDieMessage.StringValue,OnBossDie);
        }

        private void OnBossDie()
        {
            Instantiate(victoryPrefab,GlobalVar.G_Canvas.transform);
            MainLoop.Instance.ExecuteUntilTrue(() => Input.GetKeyDown(KeyCode.Space), () => SceneManager.LoadScene(0));
        }

        private void OnMessageCome()
        {
            if (this == null)
                return;
            var mb = Instantiate(dieSignPrefab, transform.position+offset, Quaternion.identity);
            mb.AddComponent<FullDown>().targetY = transform.position.y;
            Instantiate(ExitButton,GlobalVar.G_Canvas.transform);
        }

        public void ReStartThisScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}