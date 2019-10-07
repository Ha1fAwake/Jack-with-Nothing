/*背包数据处理类*/
using UnityEngine;
using LudumDare.Model;

public class BagData {

    public enum Direction {
        up,
        down,
        left,
        right
    };
    private static int bagItemId = 0;  //背包物品的id
    private static int facedItemId;
    private static GameObject bagItem;   //背包物品
    private static GameObject facedItem;
    private static Direction playerFace = Direction.down;  //主角朝向
    private static Vector3 farAway = new Vector3(999, 999, 0);  //背包位置

    public static int BagItemId { get => bagItemId; set => bagItemId = value; }
    public static int FacedItemId { get => facedItemId; set => facedItemId = value; }
    public static GameObject BagItem { get => bagItem; set => bagItem = value; }
    public static GameObject FacedItem { get => facedItem; set => facedItem = value; }
    public static Direction PlayerFace { get => playerFace; set => playerFace = value; }

    //交换或拾取
    public static void SwitchItem(Transform Player) {

        //无效操作
        if (facedItem == null && bagItem == null) {
            return;
        }

        //扔掉物体
        if (facedItem == null) {
            #region 扔掉
            /*
            bagItem.GetComponent<ItemIdentity>().OnLeaveBag();
            if (playerFace == Direction.up) {
                bagItem.transform.position = Player.position + new Vector3(0, 1, 0);
            }
            if (playerFace == Direction.down) {
                bagItem.transform.position = Player.position + new Vector3(0, -1, 0);
            }
            if (playerFace == Direction.left) {
                bagItem.transform.position = Player.position + new Vector3(-1, 0, 0);
            }
            if (playerFace == Direction.right) {
                bagItem.transform.position = Player.position + new Vector3(1, 0, 0);
            }
            bagItem = null;
            bagItemId = 0;  //nothing
            */
            #endregion
            return;
        }

        //获得物体
        if (bagItem == null) {
            bagItem = facedItem;
            facedItem.transform.position = farAway;
            bagItemId = facedItemId;
            bagItem.GetComponent<ItemIdentity>().OnAddToBag();
            return;
        }

        //交换物体
        bagItem.GetComponent<ItemIdentity>().OnLeaveBag();
        facedItem.GetComponent<ItemIdentity>().OnAddToBag();
        bagItem.transform.position = facedItem.transform.position;
        facedItem.transform.position = farAway;
        bagItem = facedItem;
        bagItemId = facedItemId;
        return;
    }

    public static void MergeItem() {
        if (facedItem != null && bagItem != null) {
            BasicItem item;
            if (ItemMgr.IsMergeOk(bagItemId, facedItemId, out item)) {
                GameObject.Instantiate(item.Prefab, facedItem.transform.position, new Quaternion());
                GameObject.Destroy(bagItem);
                GameObject.Destroy(facedItem);
                bagItemId = 0;
            }
        }
    }

    public static void UseItem() {
        if (bagItem == null) return;
        if (facedItem == null) {
            bagItem.GetComponent<ItemIdentity>().UseOnTo(null);
        }
        else {
            bagItem.GetComponent<ItemIdentity>().UseOnTo(facedItem.GetComponent<ItemIdentity>());
            bagItem = null;
            BagItemId = 0;
        }
    }
}