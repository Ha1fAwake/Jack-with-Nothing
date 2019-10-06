using UnityEngine;

public class MergeItem : MonoBehaviour {

    public KeyCode key = KeyCode.C;

    void Update() {
        if (Input.GetKeyDown(key)) {
            BagData.MergeItem();
        }
    }
}