using TMPro;
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
        [HideInInspector] public int currentNChoice;
        [HideInInspector] public bool showingDialogue;
        private DialogueManager _dialogueManager;


        private void Start()
        {
            _dialogueManager = GetComponent<DialogueManager>();
            relationScore = PlayerPrefs.GetInt("relScore");
        }

        public void DialogueOptionsShow()
        {
            showingDialogue = true;
            dialogueAndNameplate.SetActive(false);
            dialogueOptions[currentChoices].SetActive(true);
        }

        private void DialogueOptionsHide()
        {
            showingDialogue = false;
            dialogueAndNameplate.SetActive(true);
            dialogueOptions[currentChoices].SetActive(false);
            if (dialogueOptions[currentChoices].transform.GetChild(2).gameObject.name == "Choice2")
            {
                currentNChoice++;
            }
            currentChoices++;
        }

        public void IncreaseScore()
        {
            ChangeScore(scoreChangeAmount);
            DialogueOptionsHide();
            _dialogueManager.dialoguesChosen[_dialogueManager.currentDialogue] = dialogueOptions[currentChoices].transform.GetChild(1).GetComponentInChildren<TMP_Text>().text;
            _dialogueManager.PositiveChoice(currentChoices);
        }

        public void DontChangeScore()
        {
            DialogueOptionsHide();
            _dialogueManager.dialoguesChosen[_dialogueManager.currentDialogue] = dialogueOptions[currentChoices].transform.GetChild(2).GetComponentInChildren<TMP_Text>().text;
            _dialogueManager.NeutralChoice(currentNChoice);
        }

        public void DecreaseScore()
        {
            ChangeScore(-scoreChangeAmount);
            DialogueOptionsHide();
            if (dialogueOptions[currentChoices].transform.childCount == 4)
            {
                _dialogueManager.dialoguesChosen[_dialogueManager.currentDialogue] = dialogueOptions[currentChoices].transform.GetChild(3).GetComponentInChildren<TMP_Text>().text;
            }
            else
            {
                _dialogueManager.dialoguesChosen[_dialogueManager.currentDialogue] = dialogueOptions[currentChoices].transform.GetChild(2).GetComponentInChildren<TMP_Text>().text;
            }
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