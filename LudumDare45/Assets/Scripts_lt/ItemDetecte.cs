using UnityEngine;

public class ItemDetecte : MonoBehaviour {

    BagData bagData;

    private void Start() {
        bagData = new BagData();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.name == "Player") {
            bagData.SetFacedItem(gameObject);
        }
    }
}