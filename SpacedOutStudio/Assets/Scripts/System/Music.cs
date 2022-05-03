using UnityEngine;

namespace System
{
	public class Music : MonoBehaviour
	{
		private AudioSource _audio;
		public AudioClip startClip;
		public AudioClip loopClip;

		private void Start()
		{
			_audio = GetComponent<AudioSource>();
			if (startClip != null)
			{
				_audio.PlayOneShot(startClip);
			}
		}

		private void Update()
		{
			if (_audio.isPlaying) return;
			_audio.PlayOneShot(loopClip);
			_audio.loop = true;
		}
	}
}
