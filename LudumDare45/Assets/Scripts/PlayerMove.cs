/*主角按键检测处理*/
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private float Speed = 0.05f;
    private float Distence = 0;
    private float moveUnit = 1.0f;
    private bool IsW = false;
    private bool IsS = false;
    private bool IsA = false;
    private bool IsD = false;

    void Update() {
        //移动
        if (KeyAble()) {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
                IsW = true;
                BagData.PlayerFace = BagData.Direction.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
                IsS = true;
                BagData.PlayerFace = BagData.Direction.down;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
                IsA = true;
                BagData.PlayerFace = BagData.Direction.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
                IsD = true;
                BagData.PlayerFace = BagData.Direction.right;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && SwitchAble()) BagData.SwitchItem(transform);
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