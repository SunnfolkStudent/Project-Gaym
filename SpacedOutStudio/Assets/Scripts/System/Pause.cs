using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
   public bool gameIsPaused;
   private bool pauseButton;
   public GameObject pauseCanvas;
   private ActionInputs input;

   private void Awake()
   {
      input = new ActionInputs();
   }

   private void Start()
   {
      gameIsPaused = false;
      pauseCanvas.SetActive(false); 
   }

   private void Update()
   {
      pauseButton = input.Player.Pause.triggered;
      
      if (pauseButton)
      {
         Debug.Log("Pause is triggered");
         if (gameIsPaused)
         {
            ResumeGame();
         }
         else
         {
            PauseGame();
         }
      }
   }

   void PauseGame()
   {
      Time.timeScale = 0f;
      pauseCanvas.SetActive(true);
      gameIsPaused = true;
   }

   void ResumeGame()
   {
      pauseCanvas.SetActive(false);
      gameIsPaused = false;
      Time.timeScale = 1f;
   }

   private void OnEnable()
   {
      input.Enable();
   }

   private void OnDisable()
   {
      input.Disable();
   }
}
