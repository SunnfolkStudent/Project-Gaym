using System.Collections;
using UnityEngine;

namespace System
{
    [RequireComponent(typeof(AudioSource))]
    public class Transition : MonoBehaviour
    {
        public SceneController sceneController;
        public DialogueManager dialogueManager;
        //public ChoiceManager choiceManager;
        private AudioSource _audioSource;
        public float delayBefore1 = 1;
        public AudioClip Clip1;
        public float delayBefore2 = 1;
        public AudioClip Clip2;
        public float delayBefore3 = 1;
        public AudioClip Clip3;
        public float delayBeforeLoad = 1;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void LoadLevel()
        {
            StartCoroutine(LoadWithSound());
            /*if (!dialogueManager.loadFinalScene)
            {
                sceneController.LoadScene(dialogueManager.sceneToLoad);
            }
            else
            {
                if (choiceManager.relationScore > dialogueManager.scoreForFinalScene)
                {
                    sceneController.LoadScene(dialogueManager.finalSceneToLoadP);
                }
                else
                {
                    sceneController.LoadScene(dialogueManager.finalSceneToLoadN);
                }
            }*/
        }

        public void StartText()
        {
            if (dialogueManager != null)
            {
                StartCoroutine(dialogueManager.GradualText());
            }
        }

        private IEnumerator LoadWithSound()
        {
            if (Clip1)
            {
                yield return new WaitForSeconds(delayBefore1);
                _audioSource.PlayOneShot(Clip1);
            }

            if (Clip2)
            {
                yield return new WaitForSeconds(delayBefore2);
                _audioSource.PlayOneShot(Clip2);
            }

            if (Clip3)
            {
                yield return new WaitForSeconds(delayBefore3);
                _audioSource.PlayOneShot(Clip3);
            }
            yield return new WaitForSeconds(delayBeforeLoad);
            sceneController.LoadScene(dialogueManager.sceneToLoad);
        }
    }
}