using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private float Speed = 0.05f;
    private float Distence = 0;
    private bool IsW = false;
    private bool IsS = false;
    private bool IsA = false;
    private bool IsD = false;

    void Update() {
        //移动
        if (KeyAble()) {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) IsW = true;
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) IsS = true;
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) IsA = true;
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) IsD = true;
        }
        if (Input.GetKeyDown(KeyCode.Space)) BagData.SwitchItem(transform);
        Move();

        //判断朝向
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            BagData.PlayerFace = BagData.Direction.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            BagData.PlayerFace = BagData.Direction.down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            BagData.PlayerFace = BagData.Direction.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            BagData.PlayerFace = BagData.Direction.right;
        }
    }

    public void Move() {
        if (IsW) {
            transform.position += new Vector3(0, Speed, 0);
            Distence += Speed;
            if (Distence >= 1) {
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
            if (Distence >= 1) {
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
            if (Distence >= 1) {
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
            if (Distence >= 1) {
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
}