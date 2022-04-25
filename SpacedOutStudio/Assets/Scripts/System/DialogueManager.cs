using Inputs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    [RequireComponent(typeof(SceneController))]
    [RequireComponent(typeof(InputManager))]
    public class DialogueManager : MonoBehaviour
    {
        public string[] script;

        public string sceneToLoad;
        //public GameObject dialogueGameObject;
        public GameObject logGameObject;
        public TMP_Text dialogueText;
        public TMP_Text namePlate;
        public string replaceString;
        public string playerName;
        private InputManager _inputManager;
        private int _currentDialogue;
        private TMP_Text _logText;
        private string[] _names;
        private SceneController _sceneController;


        private void Start()
        {
            _sceneController = GetComponent<SceneController>();
            _logText = logGameObject.GetComponentInChildren<TMP_Text>();
            _inputManager = GetComponent<InputManager>();
            //_dialogueText = dialogueGameObject.GetComponent<TMP_Text>();
            ExtractAndReplaceNames();
            dialogueText.text = script[_currentDialogue];
            namePlate.text = _names[_currentDialogue];
        }

        private void Update()
        {
            if (_inputManager.interact)
            {
                NextDialogue();
            }

            if (_inputManager.log)
            {
                Log();
            }
        }

        public void NextDialogue()
        {
            if (logGameObject.activeSelf) return;
        
            if (_currentDialogue < script.Length -1)
            {
                _currentDialogue++;
            }
            else
            {
                _sceneController.LoadScene(sceneToLoad);
            }

            var test = script[_currentDialogue].ToCharArray();

            for (int i = 0; i < script[_currentDialogue].Length; i++)
            {
                
                dialogueText.text.Insert(i,);
            }
            dialogueText.text = script[_currentDialogue];
            namePlate.text = _names[_currentDialogue];
        }

        public void Log()
        {
            if (!logGameObject.activeSelf)
            {
                logGameObject.SetActive(true);
                for (var i = 0; i < _currentDialogue+1; i++)
                {
                    _logText.text += "\n" + _names[i] + ": " + script[i];
                }
            }
            else
            {
                logGameObject.SetActive(false);
                _logText.text = "Log:";
            }
        }
//TODO inputfield.GetComponent<Text>().text

        private void ExtractAndReplaceNames()
        {
            _names = new string[script.Length];
            for (var i = 0; i < script.Length; i++)
            {
                script[i] = script[i].Replace(replaceString, playerName);
                _names[i] = script[i].Split(":")[0];
                script[i] = script[i].Remove(0, script[i].IndexOf(":", StringComparison.Ordinal)+2);
            }
        }
    }
}