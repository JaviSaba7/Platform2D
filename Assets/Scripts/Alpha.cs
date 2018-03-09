using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alpha : MonoBehaviour
{
    public float initialAlpha;
    public float finalAlpha;
    public float currentTime = 0;
    public float timeDuration;

    public float delayTime;

    public Image image;
    public float diference;

    private void Start()
    {
        
        image.color = new Color(image.color.r, image.color.g, image.color.b, initialAlpha);
    }
    // Update is called once per frame
    void Update()
    {
         delayTime -= Time.deltaTime;
         if(delayTime > 0) return;

         if(currentTime <= timeDuration)
         {
             float value = Easing.BackEaseOut(currentTime, initialAlpha, finalAlpha - initialAlpha, timeDuration);

            image.color = new Color(image.color.r, image.color.g, image.color.b, value);
             currentTime += Time.deltaTime;
         }
    }
}
