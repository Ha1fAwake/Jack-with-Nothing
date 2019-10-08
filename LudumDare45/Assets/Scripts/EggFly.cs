using LudumDare.Scripts;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using UnityEngine;

public class EggFly : MonoBehaviour {

    public float Speed = 2.0f;
    public ConstStringChooser hurtBoss;

    void Start() {
        GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 1, 0) * Speed;
    }
    private void OnTriggerEnter2D(Collider2D c) {
        if (c.transform.CompareTag("Boss"))
        {
            CEventCenter.BroadMessage(hurtBoss.StringValue, GameMgr.Instance.eggDamage);
            Destroy(gameObject);
        }
    }
}