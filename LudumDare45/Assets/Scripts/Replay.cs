using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour {

    public void rePlay() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}