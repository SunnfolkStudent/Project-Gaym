using System.Collections;
using UnityEngine;

namespace Cutscene
{
    public class Animations : MonoBehaviour
    {
        public Animator heroAnimator;
        public Animator bossAnimator;
        public Animator keyAnimator;
        public GameObject shakeObjects;
        public float keyFloatSpeed = 1;
        private bool _moveKey;
        private bool _shaking;
        public float shakeDelay = 0.2f;
        private AudioSource _audioSource;
        public AudioClip rumbleClip;
        public AudioSource musicSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            if (!_moveKey) return;
            keyAnimator.transform.Translate(Vector3.up * (keyFloatSpeed * Time.deltaTime));
            StartCoroutine(Shake());
        }

        public void HeroWalk()
        {
            heroAnimator.enabled = true;
        }

        public void HeroStop()
        {
            heroAnimator.enabled = false;
        }

        public void HeroDrawSword()
        {
            heroAnimator.enabled = true;
            heroAnimator.Play("Hero Draw Sword");
        }

        public void BossLaugh()
        {
            bossAnimator.enabled = true;
            bossAnimator.Play("Boss Laugh");
        }

        public void KeyOn()
        {
            keyAnimator.gameObject.SetActive(true);
        }

        public void RotateKey()
        {
            keyAnimator.Play("Key Rotate");
            shakeObjects.transform.Translate(Vector3.left * 0.1f);
            _moveKey = true;
            musicSource.Stop();
            _audioSource.PlayOneShot(rumbleClip);
        }

        private IEnumerator Shake()
        {
            if (_shaking) yield break;
            _shaking = true;
            shakeObjects.transform.Translate(Vector3.right * 0.2f);
            yield return new WaitForSeconds(shakeDelay);
            shakeObjects.transform.Translate(Vector3.left * 0.2f);
            yield return new WaitForSeconds(shakeDelay);
            _shaking = false;
        }
    }
}