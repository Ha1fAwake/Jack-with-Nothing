using System;
using ReadyGamerOne.EditorExtension;
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
        public Vector3 offset;
        private float timer = 0;
        private float seconds;
        private GameObject timerObj=null;
        private Slider slider;
        private Image fillImage;
        public Transform folloWho;

        private void Start()
        {
            folloWho = transform;
        }

        public void StartTimer(float second,float current=0f)
        {
            if (timerObj == null)
            {
                var canvas = FindObjectOfType<Canvas>();
                if (null == canvas)
                    throw new Exception("场景中需要有Canvas");
                
                timerObj= Instantiate(timerPrefab,canvas.transform);
                timerObj.transform.position = folloWho.position + offset;
                slider = timerObj.transform.Find(sliderPath.Path).GetComponent<Slider>();
                slider.value = 1;
                fillImage = timerObj.transform.Find(fillImagePath.Path).GetComponent<Image>();
            }

            timer = second - current;
            this.seconds = second;
            MainLoop.Instance.UpdateForSeconds(CallBack, second, () => { timerObj.SetActive(false); });
        }

        private void CallBack()
        {
            
            timerObj.transform.position = folloWho.position + offset;
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