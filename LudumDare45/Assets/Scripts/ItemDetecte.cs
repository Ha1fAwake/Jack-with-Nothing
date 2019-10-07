/*物品检测主角状态*/
using UnityEngine;

public class ItemDetecte : MonoBehaviour {

    private float datecteDistence = 0.5f;
    [HideInInspector] public Transform player;

    private void OnTriggerEnter2D(Collider2D c) {
        if (this.name == "Cow" && c.name == "Player") {
            TouchTheCowEventHandler.touchTheCow = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        //print("Stay");
        if (other.transform.name == "Player")
        {

            player = other.transform;
            
            if (BagData.PlayerFace == BagData.Direction.up && transform.position.y > other.transform.position.y + datecteDistence) {
                BagData.FacedItem = gameObject;
                BagData.FacedItemId = GetItemId();
//                print("up");
            }
            else if (BagData.PlayerFace == BagData.Direction.down && transform.position.y + datecteDistence < other.transform.position.y) {
                BagData.FacedItem = gameObject;
                BagData.FacedItemId = GetItemId();
//                print("down");
            }
            else if (BagData.PlayerFace == BagData.Direction.left && transform.position.x + datecteDistence < other.transform.position.x) {
                BagData.FacedItem = gameObject;
                BagData.FacedItemId = GetItemId();
//                print("left");
            }
            else if (BagData.PlayerFace == BagData.Direction.right && transform.position.x > other.transform.position.x + datecteDistence) {
                BagData.FacedItem = gameObject;
                BagData.FacedItemId = GetItemId();
//                print("right")
            }

            else {
                if (BagData.FacedItem == gameObject) {
                    BagData.FacedItem = null;
                    BagData.FacedItemId = 0;
//                    print("null");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.transform.name == "Player") {
            BagData.FacedItem = null;
            BagData.FacedItemId = 0;
//            print("null");
        }
    }

    private int GetItemId() {
        return GetComponent<ItemIdentity>().ItemInfo.id;
    }
}