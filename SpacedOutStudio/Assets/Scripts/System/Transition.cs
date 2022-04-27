using UnityEngine;

namespace System
{
    public class Transition : MonoBehaviour
    {
        public SceneController sceneController;
        public DialogueManager dialogueManager;
        public void LoadLevel()
        {
            sceneController.LoadScene(dialogueManager.sceneToLoad);
        }

        public void StartText()
        {
            StartCoroutine(dialogueManager.GradualText());
        }
    }
}
