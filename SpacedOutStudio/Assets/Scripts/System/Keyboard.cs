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
        public TMP_Text characterlimitCountDown;
        private int _charactersLeft;

        public void Keypress(string character)
        {
            if (inputField.text.Length == charachterLimit) return;
            inputField.text = inputField.text.Insert(inputField.text.Length, character);
        }

        public void LimitCheck()
        {
            if (inputField.text.Length > charachterLimit)
            {
                inputField.text = inputField.text.Remove(charachterLimit-1, 1);
                //characterLimitText.SetActive(true);
            }
            else
            {
                _charactersLeft = charachterLimit - inputField.text.Length;
                characterlimitCountDown.text = "("+_charactersLeft+")";
                //characterLimitText.SetActive(false);
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
            dialogueManager.script[22] = dialogueManager.script[22].Replace(dialogueManager.playerName, inputField.text);
            dialogueManager.names[21] = inputField.text;
            dialogueManager.playerName = inputField.text;
            choiceManager.showingDialogue = false;
            choiceManager.dialogueAndNameplate.SetActive(true);
            dialogueManager.script[21] = dialogueManager.playerName;
            dialogueManager.NextDialogue();
            //TODO Log Compatibility
        }
    }
}