using JetBrains.Annotations;
using ReadyGamerOne.Const;
using UnityEngine;
using ReadyGamerOne.Common;

namespace LudumDare.Scripts {
    public class BossAi_1 : MonoBehaviour {

        public ConstStringChooser messageWhenStateEnd;
        public GameObject Bullet;
        public float Speed;
        public int BulletNumm = 20;
        public static int DeadBullet = 0;

        private void AnnounceStateEnd() {
            CEventCenter.BroadMessage(messageWhenStateEnd.StringValue);
        }
    }
}