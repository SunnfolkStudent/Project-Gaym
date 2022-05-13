using System.Collections;
using Cutscene;
using UnityEngine;

namespace System
{
    public class Transition : MonoBehaviour
    {
        public SceneController sceneController;
        public DialogueManager dialogueManager;
        public AudioSource audioSource;
        public Music music;
        public float delayBefore1 = 1;
        public AudioClip Clip1;
        public float delayBefore2 = 1;
        public AudioClip Clip2;
        public float delayBefore3 = 1;
        public AudioClip Clip3;
        public float delayBeforeLoad = 1;
        public Mover mover;
        public string sceneToLoad;
        public static bool started;


        public void LoadLevel()
        {
            StartCoroutine(LoadWithSound());
        }

        public void StartText()
        {
            if (mover)
            {
                mover.startCutscene = true;
            }
            if (!dialogueManager) return;
            StartCoroutine(dialogueManager.GradualText());
            started = true;
        }

        private IEnumerator LoadWithSound()
        {
            if (music)
            {
                music.stop = true;
                audioSource.Stop();
            }
            if (Clip1)
            {
                yield return new WaitForSeconds(delayBefore1);
                audioSource.PlayOneShot(Clip1);
            }

            if (Clip2)
            {
                yield return new WaitForSeconds(delayBefore2);
                audioSource.PlayOneShot(Clip2);
            }

            if (Clip3)
            {
                yield return new WaitForSeconds(delayBefore3);
                audioSource.PlayOneShot(Clip3);
            }
            yield return new WaitForSeconds(delayBeforeLoad);
            sceneController.LoadScene(dialogueManager ? dialogueManager.sceneToLoad : sceneToLoad);
        }
    }
}