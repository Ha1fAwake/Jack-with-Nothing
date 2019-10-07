using UnityEngine;

public class EggFly : MonoBehaviour {

    public float Speed = 2.0f;

    void Start() {
        GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 1, 0) * Speed;
    }
    private void OnTriggerEnter2D(Collider2D c) {
        if (c.transform.tag == "Boss") {
            Destroy(gameObject);
        }
    }
}