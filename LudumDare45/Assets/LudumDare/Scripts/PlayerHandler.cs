using LudumDare.Scriptsq;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class PlayerHandler : MonoSingleton<PlayerHandler>
    {
        public ConstStringChooser playerDieMessage;
        public GameObject dieSignPrefab;
        public Vector3 offset=new Vector3(0,3,0);
        private void Start()
        {
//            Debug.Log("监听");
            CEventCenter.AddListener(playerDieMessage.StringValue,OnMessageCome);
        }

        private void OnMessageCome()
        {
            Debug.Log("玩家应该死亡");
            var mb = Instantiate(dieSignPrefab, transform.position+offset, Quaternion.identity);
            mb.AddComponent<FullDown>().targetY = transform.position.y;

        }
    }
}