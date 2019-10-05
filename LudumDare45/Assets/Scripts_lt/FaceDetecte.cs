using UnityEngine;

public class FaceDetecte : MonoBehaviour {

    void Update() {
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
}