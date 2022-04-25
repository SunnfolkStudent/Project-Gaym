using System.Collections;
using Inputs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    [RequireComponent(typeof(ChoiceManager))]
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
        public float textSpeed = 1;
        public bool loop;
        private bool _generatingDialogue;
        private bool _stopGeneratingDialogue;
        private bool[] _choiceDialogues;
        private ChoiceManager _choiceManager;


        private void Start()
        {
            _choiceManager = GetComponent<ChoiceManager>();
            _sceneController = GetComponent<SceneController>();
            _logText = logGameObject.GetComponentInChildren<TMP_Text>();
            _inputManager = GetComponent<InputManager>();
            ExtractAndReplaceNames();
            dialogueText.text = "";
            namePlate.text = _names[_currentDialogue];
        }

        private void Update()
        {
            if (_inputManager.interact)
            {
                if (!_generatingDialogue)
                {
                    NextDialogue();
                }
                else
                {
                    _stopGeneratingDialogue = true;
                }
            }

            if (_inputManager.log)
            {
                Log();
            }
        }

        public void NextDialogue()
        {
            if (logGameObject.activeSelf || _choiceManager.showingDialogue) return;
        
            if (_currentDialogue < script.Length -1)
            {
                _currentDialogue++;
            }
            else
            {
                if (!loop)
                {
                    _sceneController.LoadWithTransition();
                    return;
                }
                _currentDialogue = 0;
            }

            if (!_choiceDialogues[_currentDialogue])
            {
                StartCoroutine(GradualText());
            }
            else
            {
                _choiceManager.DialogueOptionsShow();
            }
        }
        

        public IEnumerator GradualText()
        {
            _generatingDialogue = true;
            namePlate.text = _names[_currentDialogue];
            dialogueText.text = "";
            var test = script[_currentDialogue].ToCharArray();
            for (var i = 0; i < test.Length; i++)
            {
                if (_stopGeneratingDialogue) continue;
                yield return new WaitForSeconds(textSpeed/100);
                dialogueText.text = dialogueText.text.Insert(i,test[i].ToString());
            }

            if (_stopGeneratingDialogue)
            {
                dialogueText.text = script[_currentDialogue];
            }
            _stopGeneratingDialogue = false;

            _generatingDialogue = false;
        }

        public void Log()
        {
            //TODO Fix log with dialogue choices
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
            //TODO positive and negative choices
            _names = new string[script.Length];
            _choiceDialogues = new bool[script.Length];
            for (var i = 0; i < script.Length; i++)
            {
                if (script[i].Contains("/choice/"))
                {
                    _choiceDialogues[i] = true;
                }
                script[i] = script[i].Replace(replaceString, playerName);
                _names[i] = script[i].Split(":")[0];
                script[i] = script[i].Remove(0, script[i].IndexOf(":", StringComparison.Ordinal)+2);
            }
        }
    }
}