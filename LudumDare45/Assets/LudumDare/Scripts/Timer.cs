using System;
using ReadyGamerOne.EditorExtension;
using ReadyGamerOne.Global;
using ReadyGamerOne.Script;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare.Scripts
{
    public class Timer : UnityEngine.MonoBehaviour
    {
        public GameObject timerPrefab;
        public TransformPathChooser sliderPath;
        public TransformPathChooser fillImagePath;

        private Vector3 Offset
        {
            get
            {
                if (identity.IsInBag)
                    return playerOffset;
                else
                {
                    return itemOffset;
                }
            }
        }
        public Vector3 itemOffset;
        public Vector3 playerOffset;
        private float timer = 0;
        private float seconds;
        public GameObject timerObj=null;
        private Slider slider;
        private Image fillImage;
        private Coroutine timerCor;
        
        private Transform FolloWho
        {
            get
            {
                if (identity.IsInBag)
                    return GetComponent<ItemDetecte>().player;
                else
                {
                    return transform;
                }
            }
        }
        private ItemIdentity identity;

        private void Awake()
        {
            
            identity = GetComponent<ItemIdentity>();
        }

        public void StartTimer(float second,float current=0f)
        {
            if (timerObj == null)
            {
                if (timerPrefab == null)
                    throw new Exception("我裂开了");
                timerObj= Instantiate(timerPrefab,GlobalVar.G_Canvas.transform);
                if(timerObj==null)
                    throw new Exception("我人傻了");
                timerObj.transform.position = FolloWho.position + Offset;
                slider = timerObj.transform.Find(sliderPath.Path).GetComponent<Slider>();
                slider.value = 1;
                fillImage = timerObj.transform.Find(fillImagePath.Path).GetComponent<Image>();
            }else

                timerObj.SetActive(true);

//            Debug.Log("UpdateForSeconds");
            timer = second - current;
            this.seconds = second;
            timerCor= MainLoop.Instance.UpdateForSeconds(CallBack, second, () => { timerObj.SetActive(false); });
        }

        public void Stop()
        {
            if (null != timerCor)
                MainLoop.Instance.StopCoroutine(timerCor);
            timerObj.SetActive(false);
        }

        private void CallBack()
        {
//            Debug.Log("CallBask");
            if (timerObj == null)
            {
                return;
            }
            timerObj.transform.position = FolloWho.position + Offset;
            timer -= Time.deltaTime;

            var sliderValue = timer / seconds;

            slider.value = sliderValue;
            
            if (slider.value > 0.5f)
            {
                fillImage.color = Color.Lerp(Color.green, Color.yellow, (1 - sliderValue)*2);
            }
            else
            {
                fillImage.color=Color.Lerp(Color.yellow,Color.red, (0.5f-sliderValue)*2);
            }
            

        }
    }
}