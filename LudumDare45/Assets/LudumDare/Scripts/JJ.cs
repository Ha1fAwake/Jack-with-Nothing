using ReadyGamerOne.Common;
using ReadyGamerOne.Const;

namespace UnityEngine.UI {
    public class JJ : UnityEngine.MonoBehaviour {

        public GameObject egg;
        public ConstStringChooser messageToShoot;

        private void Start() {
            CEventCenter.AddListener(messageToShoot.StringValue, Shot);
//            Debug.Log("添加监听："+messageToShoot.StringValue);
        }

        private void Shot()
        {
            if (this == null)
                return;
//            Debug.Log("发射！！！");
            Instantiate(egg, transform.position, new Quaternion());
        }
    }
}