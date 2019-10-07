using ReadyGamerOne.Common;
using ReadyGamerOne.Const;

namespace UnityEngine.UI {
    public class JJ : UnityEngine.MonoBehaviour {

        public GameObject egg;
        public ConstStringChooser messageToShoot;

        private void Start() {
            CEventCenter.AddListener(messageToShoot.StringValue, Shot);
        }

        private void Shot() {
            Instantiate(egg, transform.position, new Quaternion());
        }
    }
}