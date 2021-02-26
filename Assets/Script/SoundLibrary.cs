using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour
{
  public static SoundLibrary instance;

  public AudioClip helicopterExplosion;
  public AudioClip interestDestroyBonus;
  public AudioClip uiButtonHover;
  public AudioClip uiButtonClick;
  public AudioClip explotionFat;
  public AudioClip bonusSound;
  public AudioClip collision;
  public AudioClip musicLevel;

  void Awake()
  {
    if (instance == null)
    {
      instance = this;

    } 
  }



}
