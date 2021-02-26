using Hellmade.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSoundManager : MonoBehaviour
{
    public bool global = false;
    public Audio.AudioType audioType;


    public void ChangeSoundManagerVolume(float volume)
    {
        if (global) {
            SoundManager.GlobalVolume = volume;
            return;
        }

        switch (audioType)
        {
            case Audio.AudioType.Music:
                SoundManager.GlobalMusicVolume = volume;
                break;
            case Audio.AudioType.Sound:
                SoundManager.GlobalSoundsVolume = volume;
                break;
            case Audio.AudioType.UISound:
                SoundManager.GlobalUISoundsVolume = volume;
                break;
        }
    }
}
