using UnityEngine;

namespace System
{
    public class ExtraScene : MonoBehaviour
    {
        private ChoiceManager _choiceManager;
        private DialogueManager _dialogueManager;
        public string scene;

        private void Start()
        {
            _dialogueManager = GetComponent<DialogueManager>();
            _choiceManager = GetComponent<ChoiceManager>();
        }

        public void LoadExtraScene()
        {
            _choiceManager.DecreaseScore();
            _dialogueManager.sceneToLoad = scene;
        }
    }
}