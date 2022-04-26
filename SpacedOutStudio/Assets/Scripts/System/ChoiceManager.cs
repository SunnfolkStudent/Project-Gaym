using UnityEngine;

namespace System
{
    [RequireComponent(typeof(DialogueManager))]
    public class ChoiceManager : MonoBehaviour
    {
        public int relationScore;
        [SerializeField] [Range(0, 100)] private int critChancePercentage = 20;
        public int scoreChangeAmount = 1;
        public GameObject dialogueAndNameplate;
        public GameObject[] dialogueOptions;
        private int _currentChoices;
        public bool showingDialogue;
        private DialogueManager _dialogueManager;


        private void Start()
        {
            _dialogueManager = GetComponent<DialogueManager>();
        }

        public void DialogueOptionsShow()
        {
            showingDialogue = true;
            dialogueAndNameplate.SetActive(false);
            dialogueOptions[_currentChoices].SetActive(true);
        }

        public void DialogueOptionsHide()
        {
            showingDialogue = false;
            dialogueAndNameplate.SetActive(true);
            dialogueOptions[_currentChoices].SetActive(false);
            _currentChoices++;
            _dialogueManager.NextDialogue();
        }

        public void IncreaseScore()
        {
            ChangeScore(scoreChangeAmount);
            DialogueOptionsHide();
        }

        public void DecreaseScore()
        {
            ChangeScore(-scoreChangeAmount);
            DialogueOptionsHide();
        }

        private void ChangeScore(int change)
        {
            var critValue = UnityEngine.Random.Range(0, 99);
            if (critValue < critChancePercentage)
            {
                relationScore += change * 2;
                print("crit");
            }
            else
            {
                print("normal");
                relationScore += change;
            }
        }
    }
}