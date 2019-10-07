/*Boss的前期AI行为脚本*/
using ReadyGamerOne.Const;
using UnityEngine;
using ReadyGamerOne.Common;
using ReadyGamerOne.Script;

namespace LudumDare.Scripts {
    public class BossAi_1 : MonoBehaviour {

        public ConstStringChooser messageWhenStateEnd;
        public GameObject Bullet;
        public int BulletNum = 20; //子弹数量
        public float WaitTime = 5.0f;   //发射前的等待时间
        public float DeltCreateTime = 0.2f; //子弹发射时间间隔
        public static int DeadBullet = 0;
        private float TimeCount = 0;
        private bool IsShooted = false; //是否已开始发射子弹
        private bool IsSendMessage = false;  //是否已发射消息

        private void AnnounceStateEnd() {
            CEventCenter.BroadMessage(messageWhenStateEnd.StringValue);
        }
        private void Update() {
            TimeCount += Time.deltaTime;
            if (TimeCount > WaitTime && !IsShooted) {
                IsShooted = true;
                MainLoop.Instance.ExecuteEverySeconds(CreateBullet, BulletNum, DeltCreateTime);
            }
            if (DeadBullet == BulletNum && !IsSendMessage) {
                IsSendMessage = true;
                AnnounceStateEnd();
                print("转换至ai2");
            }
        }

        public void CreateBullet() {
            Instantiate(Bullet, transform.position, new Quaternion());
        }
    }
}