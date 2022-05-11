using UnityEngine;

namespace System
{
    public class SaveManager : MonoBehaviour
    {
        public static void Save(int relScore, string pName, int currentScene)
        {
            PlayerPrefs.SetInt("relScore", relScore);
            PlayerPrefs.SetString("pName", pName);
            PlayerPrefs.SetInt("currentScene", currentScene);
        }

        /*public static void Load(out int relScore, out string pName, out int currentScene)
        {
            relScore = PlayerPrefs.GetInt("relScore");
            pName = PlayerPrefs.GetString("pName");
            currentScene = PlayerPrefs.GetInt("currentScene");
        }*/

        public static void SaveScore(int relScore)
        {
            PlayerPrefs.SetInt("relScore", relScore);
        }

        public static void SaveName(string pName)
        {
            PlayerPrefs.SetString("pName", pName);
        }


        public static void DeleteSave()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("pName", "You");
        }
    }
}