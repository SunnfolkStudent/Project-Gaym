using System;
using Inputs;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class DialogueManager : MonoBehaviour
{
    public string[] script;
    public GameObject dialogueGameObject;
    public GameObject logGameObject;
    private TMP_Text _dialogueText;
    private InputManager _inputManager;
    private int _currentDialogue;
    private TMP_Text _logText;

    private void Start()
    {
        _logText = logGameObject.GetComponentInChildren<TMP_Text>();
        _inputManager = GetComponent<InputManager>();
        _dialogueText = dialogueGameObject.GetComponent<TMP_Text>();
        _dialogueText.text = script[_currentDialogue];
    }

    private void Update()
    {
        if (_inputManager.interact)
        {
            NextDialogue();
        }

        if (_inputManager.log)
        {
            Log();
        }
    }

    public void NextDialogue()
    {
        if (logGameObject.activeSelf) return;
        
        if (_currentDialogue < script.Length -1)
        {
            _currentDialogue++;
        }
        else
        {
            _currentDialogue = 0;
        }
        _dialogueText.text = script[_currentDialogue];
    }

    public void Log()
    {
        if (!logGameObject.activeSelf)
        {
            logGameObject.SetActive(true);
            for (var i = 0; i < _currentDialogue+1; i++)
            {
                _logText.text += "\n" + script[i];
            }
        }
        else
        {
            logGameObject.SetActive(false);
            _logText.text = "Log:";
        }
    }
}