using Inputs;
using UnityEngine;

namespace System
{
   [RequireComponent(typeof(InputManager))]
   public class PauseScript : MonoBehaviour
   {
      public static bool GameIsPaused;
      public GameObject pauseCanvas;
      public GameObject mainUI;
      private InputManager _input;
      public GameObject settings;

      private void Start()
      {
         _input = GetComponent<InputManager>();
         GameIsPaused = false;
         pauseCanvas.SetActive(false); 
      }

      private void Update()
      {
         if (!_input.pause) return;
         if (GameIsPaused)
         {
            ResumeGame();
         }
         else
         {
            PauseGame();
         }
      }

      public void PauseGame()
      {
         Time.timeScale = 0f;
         mainUI.SetActive(false);
         pauseCanvas.SetActive(true);
         GameIsPaused = true;
      }

      public void ResumeGame()
      {
         if (settings.activeSelf) return;
         pauseCanvas.SetActive(false);
         mainUI.SetActive(true);
         GameIsPaused = false;
         Time.timeScale = 1f;
      }
   }
}
