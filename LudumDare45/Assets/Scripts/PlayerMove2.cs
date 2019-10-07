/*主角按键检测处理*/
using UnityEngine;

public class PlayerMove2 : MonoBehaviour {

    private Animator anim;
    private float Speed = 2.0f;
    private float last_xDre;
    private float last_yDre;
    private bool isMoved = false;

    private void Start() {
        anim = this.GetComponent<Animator>();
    }

    void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(x) > Mathf.Epsilon || Mathf.Abs(y) > Mathf.Epsilon) {
            last_xDre = x;
            last_yDre = y;
            isMoved = true;
        }
        else {
            isMoved = false;
        }
        anim.SetBool("isMoved", isMoved);
        anim.SetFloat("xValue", last_xDre);
        anim.SetFloat("yValue", last_yDre);

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, Speed, 0);
            BagData.PlayerFace = BagData.Direction.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, -Speed, 0);
            BagData.PlayerFace = BagData.Direction.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-Speed, 0, 0);
            BagData.PlayerFace = BagData.Direction.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(Speed, 0, 0);
            BagData.PlayerFace = BagData.Direction.right;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)) {
            Vector3 SpeedVec = GetComponent<Rigidbody2D>().velocity;
            SpeedVec.y = 0;
            GetComponent<Rigidbody2D>().velocity = SpeedVec;
            BagData.PlayerFace = BagData.Direction.up;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) {
            Vector3 SpeedVec = GetComponent<Rigidbody2D>().velocity;
            SpeedVec.y = 0;
            GetComponent<Rigidbody2D>().velocity = SpeedVec;
            BagData.PlayerFace = BagData.Direction.down;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) {
            Vector3 SpeedVec = GetComponent<Rigidbody2D>().velocity;
            SpeedVec.x = 0;
            GetComponent<Rigidbody2D>().velocity = SpeedVec;
            BagData.PlayerFace = BagData.Direction.left;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) {
            Vector3 SpeedVec = GetComponent<Rigidbody2D>().velocity;
            SpeedVec.x = 0;
            GetComponent<Rigidbody2D>().velocity = SpeedVec;
            BagData.PlayerFace = BagData.Direction.right;
        }
    }
}