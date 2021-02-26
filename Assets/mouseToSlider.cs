using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mouseToSlider : MonoBehaviour, IPointerDownHandler
{

    float mx; //calculated x position of mouse
    float xMax; //max value mx can get, required for calculation

    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>(); //get attached slider script
        xMax = Camera.main.pixelWidth;   //max value mx can get is width of cam
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mx = Input.mousePosition.x; //get mouse x
        mx = mx / xMax;             //find ratio, get value between 1 and 0
        slider.value = mx;          //slider.value can get value between 1 and 0    }
    }
}