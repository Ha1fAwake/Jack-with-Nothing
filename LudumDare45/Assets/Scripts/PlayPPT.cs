using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayPPT : MonoBehaviour {

    public Sprite[] sprite = new Sprite[6];
    private float StayTime = 2.0f;
    private float ShowTime = 1.0f;

    private void Start() {
        Play1();
    }

    void Play1() {
        GetComponent<SpriteRenderer>().sprite = sprite[0];
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), ShowTime);
        Invoke("Play2", StayTime + ShowTime);
    }
    void Play2() {
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), ShowTime);
        Invoke("Play3", ShowTime);
    }

    void Play3() {
        GetComponent<SpriteRenderer>().sprite = sprite[1];
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), ShowTime);
        Invoke("Play4", StayTime + ShowTime);
    }
    void Play4() {
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), ShowTime);
        Invoke("Play5", ShowTime);
    }

    void Play5() {
        GetComponent<SpriteRenderer>().sprite = sprite[2];
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), ShowTime);
        Invoke("Play6", StayTime + ShowTime);
    }
    void Play6() {
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), ShowTime);
        Invoke("Play7", ShowTime);
    }

    void Play7() {
        GetComponent<SpriteRenderer>().sprite = sprite[3];
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), ShowTime);
        Invoke("Play8", StayTime + ShowTime);
    }
    void Play8() {
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), ShowTime);
        Invoke("Play9", ShowTime);
    }

    void Play9() {
        GetComponent<SpriteRenderer>().sprite = sprite[4];
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), ShowTime);
        Invoke("Play10", StayTime + ShowTime);
    }
    void Play10() {
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), ShowTime);
        Invoke("Play11", ShowTime);
    }

    void Play11() {
        GetComponent<SpriteRenderer>().sprite = sprite[5];
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), ShowTime);
        Invoke("Play12", StayTime + ShowTime);
    }
    void Play12() {
        GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), ShowTime);
        SceneManager.LoadScene("FlowerGarden");
    }
}