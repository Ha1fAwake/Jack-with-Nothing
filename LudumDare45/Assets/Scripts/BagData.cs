using UnityEngine;

public class BagData {

    public enum Direction {
        up,
        down,
        left,
        right
    };
    private static int bagItemId = 0;  //背包id
    private static int facedItemId;
    private static GameObject bagItem;   //背包物品
    private static GameObject facedItem;
    private static Direction playerFace = Direction.down;  //主角朝向
    private static Vector3 farAway = new Vector3(9, 9, 0);  //背包位置

    public static int BagItemId { get => bagItemId; set => bagItemId = value; }
    public static int FacedItemId { get => facedItemId; set => facedItemId = value; }
    public static GameObject BagItem { get => bagItem; set => bagItem = value; }
    public static GameObject FacedItem { get => facedItem; set => facedItem = value; }
    public static Direction PlayerFace { get => playerFace; set => playerFace = value; }

    public static void SwitchItem(Transform Player) {

        //无效操作
        if (facedItem == null && bagItem == null) {
            return;
        }

        //放置物体
        else if (facedItem == null) {
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
        }

        //获得物体
        else if (bagItem == null) {
            bagItem = facedItem;
            facedItem.transform.position = farAway;
        }

        //交换物体
        else {
            bagItem.transform.position = facedItem.transform.position;
            facedItem.transform.position = farAway;
            bagItem = facedItem;
        }
    }
}