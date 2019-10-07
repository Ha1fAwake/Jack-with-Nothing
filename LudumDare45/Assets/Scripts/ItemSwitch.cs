using UnityEngine;

public class ItemSwitch : MonoBehaviour {

    public KeyCode Key = KeyCode.J;

    void Update() {
        if (Input.GetKeyDown(Key))
            BagData.SwitchItem(transform);
    }
}