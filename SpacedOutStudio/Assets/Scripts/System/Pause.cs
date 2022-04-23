using Inputs;
using UnityEngine;

namespace System
{
   [RequireComponent(typeof(InputManager))]
   public class Pause : MonoBehaviour
   {
      public bool gameIsPaused;
      public GameObject pauseCanvas;
      private InputManager _input;
      

      private void Start()
      {
         _input = GetComponent<InputManager>();
         gameIsPaused = false;
         pauseCanvas.SetActive(false); 
      }

      private void Update()
      {
         if (!_input.pause) return;
         if (gameIsPaused)
         {
            ResumeGame();
         }
         else
         {
            PauseGame();
         }
      }

      private void PauseGame()
      {
         Time.timeScale = 0f;
         pauseCanvas.SetActive(true);
         gameIsPaused = true;
      }

      public void ResumeGame()
      {
         pauseCanvas.SetActive(false);
         gameIsPaused = false;
         Time.timeScale = 1f;
      }
      
   }
}
