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
        public int numberOfSentences = 7;

        private void Start()
        {
            _sceneController = GetComponent<SceneController>();
            _dialogueManager = GetComponent<DialogueManager>();
            _choiceManager = GetComponent<ChoiceManager>();
        }

        private void Update()
        {
            if (_startCounter && _dialogueManager.nextDialogue)
            {
                _dialogueManager.nextDialogue = false;
                _counter++;
            }

            if (_counter <= numberOfSentences) return;
            _sceneController.LoadWithTransition();
            _choiceManager.dialogueAndNameplate.SetActive(false);
        }

        public void LoadExtraScene()
        {
            _choiceManager.DecreaseScore();
            _startCounter = true;
            _dialogueManager.sceneToLoad = scene;
        }
    }
}