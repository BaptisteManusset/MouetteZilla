using Hellmade.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Interactable
{
    [SerializeField] float value = 10;
    public override void Interact()
    {
        GameManager.AddHealth(value);
        gameObject.SetActive(false);
        SoundManager.PlaySound(SoundLibrary.instance.bonusSound, 1);


    }
}
