using UnityEngine;

public class BagData : MonoBehaviour {

    private static int bagItemId;  //背包id
    private static int facedItemId;
    private static GameObject bagItem;   //背包物品
    private static GameObject facedItem;
    private Vector3 farAway = new Vector3(999, 999, 0);

    public BagData() {
        bagItemId = 0;
    }

    public BagData(int item) {
        bagItemId = item;
    }

    public void SetBagItemId(int id) {
        bagItemId = id;
    }

    public int GetBagItemId() {
        return bagItemId;
    }

    public void SetFacedItemId(int id) {
        facedItemId = id;
    }

    public int GetFacedItemId() {
        return facedItemId;
    }

    public void SetBagItem(GameObject item) {
        bagItem = item;
    }

    public GameObject GetBagItem() {
        return bagItem;
    }

    public void SetFacedItem(GameObject item) {
        facedItem = item;
    }

    public GameObject GetFacedItem() {
        return facedItem;
    }

    public void SwitchItem() {
        if (facedItem == null)  //无法交换
            return;

        if (bagItem != null) bagItem.transform.position = facedItem.transform.position;
        facedItem.transform.position = farAway;
        bagItemId = facedItemId;
        bagItem = facedItem;
    }

}