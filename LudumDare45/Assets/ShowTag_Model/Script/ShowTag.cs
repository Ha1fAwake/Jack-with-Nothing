using UnityEngine;
using UnityEngine.UI;

public class ShowTag : MonoBehaviour {

    public GameObject Tag;                  //标签组件
    public int showTime = 1;    //显示次数
    public Vector3 TagPos = new Vector3(0, 0.5f, 0);   //Tag的偏移位置

    private GameObject Tag1;                //标签实例化组件
    private string Content;                  //物品的名字
    private bool IsShowing = false;         //是否显示标签
    private bool IsSlowFade = false;
    private readonly float FadeTime = 0.2f; //玩家离开时标签慢慢消失消耗的时间
    private float TimeCount = 0;
    private int ShowCount = 0;

    private void Start() {
        Content = GetComponent<ItemIdentity>().ItemInfo.ItemName;
    }

    private void Update() {
        if (IsSlowFade) SlowFade();
    }

    private void SlowFade() {
        if (!IsShowing) {
            if (TimeCount < FadeTime) {
                TimeCount += Time.deltaTime;
                foreach (Transform child in Tag1.transform) {
                    if (child.gameObject.name == "Image") {
                        Color colors = child.gameObject.GetComponent<Image>().color;
                        colors.a -= (Time.deltaTime / FadeTime);
                        if (colors.a < 0) colors.a = 0;
                        child.gameObject.GetComponent<Image>().color = colors;
                    }
                    if (child.gameObject.name == "Text") {
                        Color colors = child.gameObject.GetComponent<Text>().color;
                        colors.a -= (Time.deltaTime / FadeTime);
                        if (colors.a < 0) colors.a = 0;
                        child.gameObject.GetComponent<Text>().color = colors;
                    }
                }
            }
            else {
                IsSlowFade = false;
                TimeCount = 0;
            }
        }
        else {
            IsSlowFade = false;
            TimeCount = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D c) {
        if (BagData.FacedItem == gameObject) {
            if (!IsShowing && c.transform.tag == "Player") {
                if (ShowCount != showTime) {
                    ShowCount++;
                    Destroy(Tag1);  //清除上一个Tag
                    Tag1 = Instantiate(Tag, new Vector3(), new Quaternion(0, 0, 0, 0)); //生成对象
                    foreach (Transform child in Tag1.transform) {
                        child.GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(transform.position + TagPos) - new Vector3(Screen.width / 2, Screen.height / 2, 0);
                        if (child.gameObject.name == "Text") {
                            child.gameObject.GetComponent<Text>().text = Content;   //修改文本
                        }
                    }
                    IsShowing = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D c) {
        if (IsShowing && c.transform.tag == "Player") {
            IsShowing = false;
            Destroy(Tag1, FadeTime);  //销毁对象
            IsSlowFade = true;
        }
    }
}