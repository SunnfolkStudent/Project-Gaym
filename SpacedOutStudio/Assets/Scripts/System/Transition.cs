using UnityEngine;

namespace System
{
    public class Transition : MonoBehaviour
    {
        public SceneController sceneController;
        public DialogueManager dialogueManager;
        public ChoiceManager choiceManager;
        public void LoadLevel()
        {
            sceneController.LoadScene(dialogueManager.sceneToLoad);
            /*if (!dialogueManager.loadFinalScene)
            {
                sceneController.LoadScene(dialogueManager.sceneToLoad);
            }
            else
            {
                if (choiceManager.relationScore > dialogueManager.scoreForFinalScene)
                {
                    sceneController.LoadScene(dialogueManager.finalSceneToLoadP);
                }
                else
                {
                    sceneController.LoadScene(dialogueManager.finalSceneToLoadN);
                }
            }*/
        }

        public void StartText()
        {
            if (dialogueManager != null)
            {
                StartCoroutine(dialogueManager.GradualText());
            }
        }
    }
}
