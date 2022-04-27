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
        [HideInInspector] public int currentChoices;
        [HideInInspector] public bool showingDialogue;
        private DialogueManager _dialogueManager;


        private void Start()
        {
            _dialogueManager = GetComponent<DialogueManager>();
        }

        public void DialogueOptionsShow()
        {
            showingDialogue = true;
            dialogueAndNameplate.SetActive(false);
            dialogueOptions[currentChoices].SetActive(true);
        }

        public void DialogueOptionsHide()
        {
            showingDialogue = false;
            dialogueAndNameplate.SetActive(true);
            dialogueOptions[currentChoices].SetActive(false);
            currentChoices++;
        }

        public void IncreaseScore()
        {
            ChangeScore(scoreChangeAmount);
            DialogueOptionsHide();
            _dialogueManager.PositiveChoice(currentChoices);
        }

        public void DontChangeScore()
        {
            DialogueOptionsHide();
            _dialogueManager.NeutralChoice(currentChoices);
        }

        public void DecreaseScore()
        {
            ChangeScore(-scoreChangeAmount);
            DialogueOptionsHide();
            _dialogueManager.NegativeChoice(currentChoices);
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