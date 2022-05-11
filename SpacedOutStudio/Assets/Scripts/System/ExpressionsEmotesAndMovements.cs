using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace System
{
    [RequireComponent(typeof(Movements))]
    [RequireComponent(typeof(DialogueManager))]
    public class ExpressionsEmotesAndMovements : MonoBehaviour
    {
        private DialogueManager _dialogueManager;
        private Movements _movements;
        public Image rageheart;

        [Space] [Header("Expressions and Emotes")] [Space]
        public Sprite[] expressionsSprites;

        public GameObject[] emotes;
        [Space] [Header("Movements")] [Space] public GameObject[] spriteToMove;
        public bool[] bob;
        public float[] howMuchToMove;
        public float[] speed;
        public float critDelay = 0.1f;
        public float critMoveAmount = 0.1f;
        [Space] [Header("Audio")] [Space] public AudioClip[] audioClips;
        private AudioSource _audio;
        public AudioClip critSfx;
        [Space] [Header("Background")] [Space] public Image background;
        public int changeToBackgroundOne;
        public Sprite backgroundOne;
        public int changeBackFromBgOne;
        public int changeToBackgroundTwo;
        public Sprite backgroundTwo;
        public int changeBackFromBgTwo;
        public bool isInBackground;
        private Sprite _currentBackground;

        private int _lastDialogue;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            _movements = GetComponent<Movements>();
            _dialogueManager = GetComponent<DialogueManager>();
        }

        public void UpdateSprite()
        {
            var currentInt = _dialogueManager.currentDialogue;
            if (expressionsSprites[currentInt])
            {
                rageheart.sprite = expressionsSprites[currentInt];
            }

            if (currentInt > 0)
            {
                if (emotes[_lastDialogue])
                {
                    emotes[_lastDialogue].SetActive(false);
                }
            }

            _lastDialogue = currentInt;
            if (emotes[currentInt])
            {
                emotes[currentInt].SetActive(true);
            }

            if (howMuchToMove[currentInt] != 0)
            {
                StartCoroutine(_movements.Move(spriteToMove[currentInt], howMuchToMove[currentInt], speed[currentInt]));
            }

            if (bob[currentInt])
            {
                StartCoroutine(_movements.Bob(spriteToMove[currentInt], speed[currentInt]));
            }

            if (audioClips[currentInt])
            {
                _audio.PlayOneShot(audioClips[currentInt]);
            }

            if (!backgroundOne) return;
            if (changeToBackgroundOne == currentInt)
            {
                _currentBackground = background.sprite;
                if (!isInBackground)
                {
                    background.transform.SetSiblingIndex(2);
                }

                background.sprite = backgroundOne;
            }

            if (changeBackFromBgOne == currentInt)
            {
                if (!isInBackground)
                {
                    background.transform.SetSiblingIndex(1);
                }

                background.sprite = _currentBackground;
            }

            if (!backgroundTwo) return;
            if (changeToBackgroundTwo == currentInt)
            {
                _currentBackground = background.sprite;
                if (!isInBackground)
                {
                    background.transform.SetSiblingIndex(2);
                }

                background.sprite = backgroundTwo;
            }
            else if (changeBackFromBgTwo == currentInt)
            {
                if (!isInBackground)
                {
                    background.transform.SetSiblingIndex(1);
                }

                background.sprite = _currentBackground;
            }
        }

        public IEnumerator CritAnim()
        {
            yield return new WaitForSeconds(critDelay);
            rageheart.color = new Color(1,0.2f,0.2f);
            _audio.PlayOneShot(critSfx);
            
            var rageTransform = rageheart.transform;
            rageTransform.localPosition += Vector3.left * critMoveAmount;
            yield return new WaitForSeconds(critDelay);
            rageTransform.localPosition += Vector3.right * (critMoveAmount * 2);
            yield return new WaitForSeconds(critDelay);
            rageTransform.localPosition += Vector3.left * critMoveAmount;
            rageheart.color = Color.white;

        }
    }
}