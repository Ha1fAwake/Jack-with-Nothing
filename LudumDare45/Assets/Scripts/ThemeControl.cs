using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class ThemeControl : MonoBehaviour {

    public Button Start, Exit;
    private float DuringTime = 0.5f;

    public void OnClickStart() {
        Start.transform.DOMoveX(1300 + Screen.width / 2, DuringTime).SetEase(Ease.InBack);
        Exit.transform.DOMoveX(1300 + Screen.width / 2, DuringTime).SetEase(Ease.InBack);
        Invoke("LoadScene", DuringTime);
    }

    public void OnClickExit() {
        Start.transform.DOMoveX(1300 + Screen.width / 2, DuringTime).SetEase(Ease.InBack);
        Exit.transform.DOMoveX(1300 + Screen.width / 2, DuringTime).SetEase(Ease.InBack);
        Invoke("Quit", 1.0f);
    }

    public void LoadScene() {
        SceneManager.LoadScene("Home");
    }

    public void Quit() {
        Application.Quit();
    }
}