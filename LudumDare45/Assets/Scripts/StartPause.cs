using UnityEngine;

public class StartPause : MonoBehaviour {

    public GameObject player;
    public GameObject Bean;
    public GameObject Merchant;

    private void OnStart() {
        player.GetComponent<PlayerMove2>().enabled = false;
        player.GetComponent<PlayerLogic>().enabled = false;
    }

    private void OnEnd() {
        player.GetComponent<PlayerMove2>().enabled = true;
        player.GetComponent<PlayerLogic>().enabled = true;
    }

    private void OnCreateBean() {
        Instantiate(Bean, Merchant.transform.position + new Vector3(0, -1, 0), new Quaternion());
    }
}