using UnityEngine;

namespace System
{
    public class SaveManager : MonoBehaviour
    {
        private DialogueManager _dialogueManager;
        private ChoiceManager _choiceManager;

        private void Start()
        {
            _choiceManager = GetComponent<ChoiceManager>();
            _dialogueManager = GetComponent<DialogueManager>();
        }

        public static void Save(int relScore, string pName)
        {
            PlayerPrefs.SetInt("relScore", relScore);
            PlayerPrefs.SetString("pName", pName);
        }

        public static void DeleteSave()
        {
            PlayerPrefs.DeleteKey("relScore");
            PlayerPrefs.DeleteKey("pName");
        }
    }
}