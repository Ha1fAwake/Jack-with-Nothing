/*主角按键检测处理*/
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Animator anim;
    private float Speed = 0.05f;
    private float Distence = 0;
    private float moveUnit = 1.0f;
    private bool IsW = false;
    private bool IsS = false;
    private bool IsA = false;
    private bool IsD = false;
    private float last_xDre;
    private float last_yDre;
    private bool isMoved = false;

    private void Start() {
        anim = this.GetComponent<Animator>();
    }

    void Update() {

        //移动
        if (KeyAble()) {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if(Mathf.Abs(x) > Mathf.Epsilon || Mathf.Abs(y) > Mathf.Epsilon)
            {
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

            if (y > 0) {
                IsW = true;
                BagData.PlayerFace = BagData.Direction.up;
            }
            else if (y < 0) {
                IsS = true;
                BagData.PlayerFace = BagData.Direction.down;
            }
            else if (x < 0) {
                IsA = true;
                BagData.PlayerFace = BagData.Direction.left;
            }
            else if (x > 0) {
                IsD = true;
                BagData.PlayerFace = BagData.Direction.right;
            }
            #region 注释
            /*
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
                IsW = true;
                BagData.PlayerFace = BagData.Direction.up;
                anim.SetFloat("yValue", 1.0f);
                anim.SetFloat("xValue", 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
                IsS = true;
                BagData.PlayerFace = BagData.Direction.down;
                anim.SetFloat("yValue", -1.0f);
                anim.SetFloat("xValue", 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
                IsA = true;
                BagData.PlayerFace = BagData.Direction.left;
                anim.SetFloat("xValue", -1.0f);
                anim.SetFloat("yValue", 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
                IsD = true;
                BagData.PlayerFace = BagData.Direction.right;
                anim.SetFloat("xValue", 1.0f);
                anim.SetFloat("yValue", 0);
            }
            */
            #endregion
        }
        if (Input.GetKeyDown(KeyCode.Space) && SwitchAble()) {
            BagData.SwitchItem(transform);
            print("Switch");
        }
        Move();
    }

    public void Move() {
        if (IsW) {
            transform.position += new Vector3(0, Speed, 0);
            Distence += Speed;
            if (Distence >= moveUnit) {
                Vector3 Pos = transform.position;
                Pos.y = Mathf.RoundToInt(Pos.y);
                transform.position = Pos;
                IsW = false;
                Distence = 0;
            }
        }
        else if (IsS) {
            transform.position += new Vector3(0, -Speed, 0);
            Distence += Speed;
            if (Distence >= moveUnit) {
                Vector3 Pos = transform.position;
                Pos.y = Mathf.RoundToInt(Pos.y);
                transform.position = Pos;
                IsS = false;
                Distence = 0;
            }
        }
        else if (IsA) {
            transform.position += new Vector3(-Speed, 0, 0);
            Distence += Speed;
            if (Distence >= moveUnit) {
                Vector3 Pos = transform.position;
                Pos.x = Mathf.RoundToInt(Pos.x);
                transform.position = Pos;
                IsA = false;
                Distence = 0;
            }
        }
        else if (IsD) {
            transform.position += new Vector3(Speed, 0, 0);
            Distence += Speed;
            if (Distence >= moveUnit) {
                Vector3 Pos = transform.position;
                Pos.x = Mathf.RoundToInt(Pos.x);
                transform.position = Pos;
                IsD = false;
                Distence = 0;
            }
        }
    }

    public bool KeyAble() {
        if (!IsW && !IsS && !IsA && !IsD) return true;
        else return false;
    }

    public bool SwitchAble() {
        
        if (transform.position.x == (int)(transform.position.x)) {
            if (transform.position.y == (int)(transform.position.y)) {
                return true;
            }
        }
        return false;
    }

}