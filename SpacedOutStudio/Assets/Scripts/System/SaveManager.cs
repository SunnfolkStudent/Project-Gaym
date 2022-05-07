using UnityEngine;

namespace System
{
    public class SaveManager : MonoBehaviour
    {
        public static void Save(int relScore, string pName)
        {
            PlayerPrefs.SetInt("relScore", relScore);
            PlayerPrefs.SetString("pName", pName);
        }
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
            PlayerPrefs.DeleteKey("relScore");
            PlayerPrefs.SetString("pName", "You");
        }
    }
}