using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    
    public void SetMasterVolume(float volume)
    {
        mixer.SetFloat("masterVol", volume);
    }    
    
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("musicVol", volume);
    }
    
    public void SetSfxVolume(float volume)
    {
        mixer.SetFloat("sfxVol", volume);
    }
}
