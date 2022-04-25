using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    public class SceneController : MonoBehaviour
    {
        private PauseScript _pause;
        
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            _pause.ResumeGame();
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

        //Delete selected save file.
        void DeleteSave()
        {
        
        }
    }
}
