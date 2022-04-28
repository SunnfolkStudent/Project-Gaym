using UnityEngine;

namespace System
{
    [RequireComponent(typeof(SceneController))]
    [RequireComponent(typeof(DialogueManager))]
    [RequireComponent(typeof(ChoiceManager))]
    public class ExtraScene : MonoBehaviour
    {
        private ChoiceManager _choiceManager;
        private DialogueManager _dialogueManager;
        private SceneController _sceneController;
        private int _counter;
        private bool _startCounter;
        public string scene;

        private void Start()
        {
            _sceneController = GetComponent<SceneController>();
            _dialogueManager = GetComponent<DialogueManager>();
            _choiceManager = GetComponent<ChoiceManager>();
        }

        private void Update()
        {
            if (_startCounter && _dialogueManager._nextDialogue)
            {
                _dialogueManager._nextDialogue = false;
                _counter++;
            }

            if (_counter > 2)
            {
                _sceneController.LoadWithTransition();
                _choiceManager.dialogueAndNameplate.SetActive(false);
            }
        }

        public void LoadExtraScene()
        {
            _choiceManager.DecreaseScore();
            _startCounter = true;
            _dialogueManager.sceneToLoad = scene;
        }
    }
}