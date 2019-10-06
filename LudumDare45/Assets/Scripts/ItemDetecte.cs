/*物品检测主角状态*/
using UnityEngine;

public class ItemDetecte : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D c) {
        print(c.transform.name);
        print("this:" + this.name);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.transform.name == "Player") {
            if (BagData.PlayerFace == BagData.Direction.up && transform.position.y > other.transform.position.y + 0.1f) {
                BagData.FacedItem = gameObject;
                BagData.FacedItemId = GetItemId();
                print("up");
            }
            else if (BagData.PlayerFace == BagData.Direction.down && transform.position.y + 0.1f < other.transform.position.y) {
                BagData.FacedItem = gameObject;
                BagData.FacedItemId = GetItemId();
                print("down");
            }
            else if (BagData.PlayerFace == BagData.Direction.left && transform.position.x + 0.1f < other.transform.position.x) {
                BagData.FacedItem = gameObject;
                BagData.FacedItemId = GetItemId();
                //print("left");
            }
            else if (BagData.PlayerFace == BagData.Direction.right && transform.position.x > other.transform.position.x + 0.1f) {
                BagData.FacedItem = gameObject;
                BagData.FacedItemId = GetItemId();
                //print("right");
            }

            else {
                if (BagData.FacedItem == gameObject) {
                    BagData.FacedItem = null;
                    BagData.FacedItemId = 0;
                    print("null");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.transform.name == "Player") {
            BagData.FacedItem = null;
            BagData.FacedItemId = 0;
            //print("null");
        }
    }

    private int GetItemId() {
        //返回物品id
        return GetComponent<ItemIdentity>().ItemInfo.id;
    }
}