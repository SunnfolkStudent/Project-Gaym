using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace System
{
    public class SettingsMenu : MonoBehaviour
    {
        public AudioMixer mixer;
        public Slider masterSlider;
        public Slider musicSlider;
        public Slider sfxSlider;
        
        public void UpdateVolume()
        {
            mixer.SetFloat("masterVol", masterSlider.value);
            mixer.SetFloat("musicVol", musicSlider.value);
            mixer.SetFloat("sfxVol", sfxSlider.value);
        }
    }
}