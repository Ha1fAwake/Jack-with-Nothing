/*显示头顶物品*/
using UnityEngine;
using LudumDare.View;
using LudumDare.Model;

public class ShowBag : MonoBehaviour {

    void Start() {
        ShowItem(0);
    }

    void Update() {
        ShowItem(BagData.BagItemId);
    }

    private void ShowItem(int id) {
        transform.GetComponent<SpriteRenderer>().sprite = ItemMgr.GetItem(id).fontSprite;
    }
}