using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace System
{
    public class Keyboard : MonoBehaviour
    {
        public GameObject[] lowerCaseKeys;
        private bool _capitilized;
        public TMP_InputField inputField;
        public int charachterLimit = 10;
        

        public void Keypress(string character)
        {
            if (inputField.text.Length > charachterLimit) return;
            inputField.text = inputField.text.Insert(inputField.text.Length, character);
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
        }
    }
}