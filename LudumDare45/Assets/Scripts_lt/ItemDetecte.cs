using UnityEngine;

public class ItemDetecte : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D other) {
        if (other.transform.name == "Player") {
            if (BagData.PlayerFace == BagData.Direction.up && transform.position.y > other.transform.position.y) {
                BagData.FacedItem = gameObject;
            }
            else if (BagData.PlayerFace == BagData.Direction.down && transform.position.y < other.transform.position.y) {
                BagData.FacedItem = gameObject;
            }
            else if (BagData.PlayerFace == BagData.Direction.left && transform.position.x < other.transform.position.x) {
                BagData.FacedItem = gameObject;
            }
            else if (BagData.PlayerFace == BagData.Direction.right && transform.position.x > other.transform.position.x) {
                BagData.FacedItem = gameObject;
            }
        }
    }
}