using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LudumDare.Model;
using LudumDare.View;
public class PlayerUI : MonoBehaviour {

    public KeyCode ShowInfo = KeyCode.Q;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(ShowInfo)) {

            if (isOpen) {
                UIHelper.Hide();
                print("hide");
            }
            else
                UIHelper.ShowItemInfo(ItemMgr.GetItem(BagData.BagItemId));
            isOpen = !isOpen;
        }
    }
}