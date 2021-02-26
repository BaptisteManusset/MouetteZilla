using Hellmade.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnEnable : MonoBehaviour
{

    [SerializeField] AudioClip musicToPlay;
    private void OnEnable()
    {
        SoundManager.PlayMusic(musicToPlay, 1, true, false, 1, -1);
    }
}
