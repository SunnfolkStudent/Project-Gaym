using TMPro;
using UnityEngine;

namespace System
{
    public class Keyboard : MonoBehaviour
    {
        public GameObject[] lowerCaseKeys;
        private bool _capitilized;
        public TMP_InputField inputField;
        public GameObject characterLimitText;
        public int charachterLimit = 10;
        public DialogueManager dialogueManager;
        public ChoiceManager choiceManager;


        private void Start()
        {
            choiceManager = GetComponent<ChoiceManager>();
            dialogueManager = GetComponent<DialogueManager>();
        }

        public void Keypress(string character)
        {
            inputField.text = inputField.text.Insert(inputField.text.Length, character);
        }

        public void LimitCheck()
        {
            if (inputField.text.Length >= charachterLimit)
            {
                inputField.text = inputField.text.Remove(charachterLimit-1, 1);
                characterLimitText.SetActive(true);
            }
            else
            {
                characterLimitText.SetActive(false);
            }
        }

        public void Capslock()
        {
            if (_capitilized)
            {
                foreach (var keys in lowerCaseKeys)
                {
                    keys.SetActive(true);
                }

                _capitilized = false;
            }
            else
            {
                foreach (var keys in lowerCaseKeys)
                {
                    keys.SetActive(false);
                }

                _capitilized = true;
            }
        }

        public void BackSpace()
        {
            if (inputField.text.Length < 1) return;
            inputField.text = inputField.text.Remove(inputField.text.Length - 1, 1);
        }

        public void Enter()
        {
            PlayerPrefs.SetString("pName", inputField.text);
            gameObject.SetActive(false);
            dialogueManager.playerName = inputField.text;
            choiceManager.showingDialogue = false;
            choiceManager.dialogueAndNameplate.SetActive(true);
        }
    }
}