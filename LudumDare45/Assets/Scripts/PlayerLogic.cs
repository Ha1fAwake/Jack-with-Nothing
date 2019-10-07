/*其它功能按键处理*/
using UnityEngine;
using LudumDare.Model;
using LudumDare.View;
public class PlayerLogic : MonoBehaviour {

    public KeyCode Switch = KeyCode.J;
    public KeyCode UseItem = KeyCode.K;
    public KeyCode ShowInfo = KeyCode.L;

    private bool isOpen = false;

    void Update() {
        if (Input.GetKeyDown(Switch)) {
            BagData.SwitchItem(transform);
        }
        if (Input.GetKeyDown(UseItem)) {
            BagData.UseItem();
        }
        if (Input.GetKeyDown(ShowInfo)) {
            if (isOpen)
                UIHelper.Hide();
            else
                UIHelper.ShowItemInfo(ItemMgr.GetItem(BagData.BagItemId));
            isOpen = !isOpen;
        }
    }
}