using Hellmade.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{

    public void OnPointerEnter(PointerEventData ped)
    {
        //SoundManager.Playhover();
    }

    public void OnPointerDown(PointerEventData ped)
    {
        SoundManager.PlayClick();
    }

}
