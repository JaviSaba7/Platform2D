using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutIntro : MonoBehaviour
    {
        public float iniAlpha;
        public float finalAlpha;
        private float currentTime = 0;
        public float timeDuration;
        public float startDelay;

        private Vector3 animValue;

        public Image image;


        private void Start()
        {
              image.color = new Color(image.color.r, image.color.g, image.color.b, iniAlpha);
        }
        // Update is called once per frame
        void Update()
        {
            startDelay -= Time.deltaTime;
            if(startDelay > 0) return;

            if(currentTime <= timeDuration)
            {
                float value = Easing.BackEaseOut(currentTime, iniAlpha, finalAlpha - iniAlpha, timeDuration);

                image.color = new Color(image.color.r, image.color.g, image.color.b, value);

                currentTime += Time.deltaTime;

                

            }

    }
    }
