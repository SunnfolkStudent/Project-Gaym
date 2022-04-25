using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    [RequireComponent(typeof(PauseScript))]
    public class SceneController : MonoBehaviour
    {
        private PauseScript _pause;
        public Animator transitionAnimator;

        private void Start()
        {
            _pause = GetComponent<PauseScript>();
            transitionAnimator.Play("fadeTransition_in");
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            _pause.ResumeGame();
        }

        public void LoadWithTransition()
        {
            transitionAnimator.Play("fadeTransition_out");
        }
        
        public void QuitGame()
        {
#if  UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        //Continues your last played save file.
        void Continue()
        {
        
        }

        //Starts a new game, without deleting existing save files. 
        void NewGame()
        {
        
        }

        //Deletes all existing save files.
        void ResetGame()
        {
        
        }
    }
}
