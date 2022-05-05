using UnityEngine;
using UnityEngine.Audio;

namespace System
{
	public class Music : MonoBehaviour
	{
		private AudioSource _audio;
		public AudioClip startClip;
		public AudioClip loopClip;
		public bool stop;
		public AudioMixerGroup musicMixer;

		private void Start()
		{
			_audio = GetComponent<AudioSource>();
			if (startClip != null)
			{
				_audio.outputAudioMixerGroup = musicMixer;
				_audio.PlayOneShot(startClip);
			}
		}

		private void Update()
		{
			if (_audio.isPlaying || stop) return;
			_audio.outputAudioMixerGroup = musicMixer;
			_audio.PlayOneShot(loopClip);
			_audio.loop = true;
		}
	}
}
