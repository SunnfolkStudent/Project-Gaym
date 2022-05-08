using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    public class SceneController : MonoBehaviour
    {
        private PauseScript _pause;
        public Animator transitionAnimator;
        public bool isMainMenu;
        public GameObject quitCanvas;
        public GameObject pauseCanvas;
        public GameObject settingsCanvas;
        public GameObject buttons;
        public GameObject title;
        public GameObject credits;
        public GameObject mainMenu;
        public GameObject particles;

        private void Start()
        {
            if (!isMainMenu)
            {
                _pause = GetComponent<PauseScript>();
            }
            transitionAnimator.Play("fadeTransition_in");
        }

        public void StartScene(string sceneName)
        {
            SaveManager.DeleteSave();
            LoadScene(sceneName);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            if (!isMainMenu)
            {
                quitCanvas.SetActive(false);
                _pause.ResumeGame();
            }
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

        public void DoYouWantToQuit()
        {
            pauseCanvas.SetActive(false);
            quitCanvas.SetActive(true);
        }
        
        public void NoQuit()
        {
            quitCanvas.SetActive(false);
            pauseCanvas.SetActive(true);
        }

        public void OpenSettings()
        {
            buttons.SetActive(false);
            title.SetActive(false);
            settingsCanvas.SetActive(true);
        }

        public void CloseSettings()
        {
            buttons.SetActive(true);
            title.SetActive(true);
            settingsCanvas.SetActive(false);
        }

        public void OpenCredits()
        {
            credits.SetActive(true);
            mainMenu.SetActive(false);
            particles.SetActive(false);
        }

        public void CloseCredits()
        {
            credits.SetActive(false);
            mainMenu.SetActive(true);
            particles.SetActive(true);
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
