using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void QuitGame()
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
