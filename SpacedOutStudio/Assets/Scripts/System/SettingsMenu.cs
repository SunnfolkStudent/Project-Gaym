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
        public bool wait;

        private void Start()
        {
            wait = true;
            mixer.GetFloat("masterVol", out var masterVol);
            masterSlider.value = masterVol;
            mixer.GetFloat("musicVol", out var musicVol);
            musicSlider.value = musicVol;
            mixer.GetFloat("sfxVol", out var sfxVol);
            sfxSlider.value = sfxVol;
            wait = false;
        }

        public void UpdateVolume()
        {
            if (wait) return;
            mixer.SetFloat("masterVol", masterSlider.value);
            mixer.SetFloat("musicVol", musicSlider.value);
            mixer.SetFloat("sfxVol", sfxSlider.value);
        }
    }
}