/*主角按键检测处理*/
using UnityEngine;
using LudumDare.View;

public class PlayerMove2 : MonoBehaviour {

    private Animator anim;
    public float MoveSpeed = 2.0f;
    private float last_xDre;
    private float last_yDre;
    private bool isMoved = false;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector3(x, y, 0) * MoveSpeed;
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
            BagData.PlayerFace = BagData.Direction.up;
            UIHelper.Hide();    //隐藏面板
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            BagData.PlayerFace = BagData.Direction.down;
            UIHelper.Hide();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            BagData.PlayerFace = BagData.Direction.left;
            UIHelper.Hide();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            BagData.PlayerFace = BagData.Direction.right;
            UIHelper.Hide();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)) {
            BagData.PlayerFace = BagData.Direction.up;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) {
            BagData.PlayerFace = BagData.Direction.down;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) {
            BagData.PlayerFace = BagData.Direction.left;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) {
            BagData.PlayerFace = BagData.Direction.right;
        }
    }
}