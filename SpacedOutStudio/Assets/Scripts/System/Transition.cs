using UnityEngine;

namespace System
{
    public class Transition : MonoBehaviour
    {
        public SceneController sceneController;
        public DialogueManager dialogueManager;
        public void LoadLevel()
        {
            sceneController.LoadScene("Test 2");
        }

        public void StartText()
        {
            StartCoroutine(dialogueManager.GradualText());
        }
    }
}
