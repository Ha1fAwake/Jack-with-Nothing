using UnityEngine;
using UnityEngine.UI;

public class SlowShow : MonoBehaviour {

    private float TimeCount = 0;
    private float ShowTime = 0.2f;  //玩家靠近时标签慢慢浮现消耗的时间
    private float Alpha = 1f;

    void Update() {
        if (TimeCount < ShowTime) {
            TimeCount += Time.deltaTime;
            foreach (Transform child in transform) {
                if (child.gameObject.name == "Image") {
                    Color colors = child.gameObject.GetComponent<Image>().color;
                    colors.a += (Time.deltaTime / ShowTime);
                    if (colors.a > Alpha) colors.a = Alpha;
                    child.gameObject.GetComponent<Image>().color = colors;
                }
                if (child.gameObject.name == "Text") {
                    Color colors = child.gameObject.GetComponent<Text>().color;
                    colors.a += (Time.deltaTime / ShowTime);
                    if (colors.a > Alpha) colors.a = Alpha;
                    child.gameObject.GetComponent<Text>().color = colors;
                }
            }
        }
    }
}