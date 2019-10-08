/*Boss��ǰ��AI��Ϊ�ű�*/
using ReadyGamerOne.Const;
using UnityEngine;
using ReadyGamerOne.Common;
using ReadyGamerOne.Script;

namespace LudumDare.Scripts {
    public class BossAi_1 : MonoBehaviour {
        [HideInInspector] public BossAIMgr aiMgr;
        public ConstStringChooser messageWhenStateEnd;
        public GameObject Bullet;
        public int BulletNum = 20; //�ӵ�����
        public float WaitTime = 5.0f;   //����ǰ�ĵȴ�ʱ��
        public float DeltCreateTime = 0.2f; //�ӵ�����ʱ����
        public static int DeadBullet = 0;
        private float TimeCount = 0;
        private bool IsShooted = false; //�Ƿ��ѿ�ʼ�����ӵ�
        private bool IsSendMessage = false;  //�Ƿ��ѷ�����Ϣ

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
//                print("ת����ai2");
            }
        }

        public void CreateBullet()
        {
            if (this == null)
                return;
            var bullet = Instantiate(Bullet, transform.position, new Quaternion());
            var logic = bullet.GetComponent<RandomFly>();
            logic.damage = GameMgr.Instance.bulletDamage;
            logic.hurtBossMessage = aiMgr.messageHurtBoss.StringValue;
            logic.hurtPlayerMessage = aiMgr.messageHurtPlayer.StringValue;
        }
    }
}