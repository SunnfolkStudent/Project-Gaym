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

    private void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _dialogueText = dialogueGameObject.GetComponent<TMP_Text>();
        _dialogueText.text = script[_currentDialogue];
    }

    private void Update()
    {
        if (_inputManager.pause)
        {
            NextDialogue();
        }
    }

    public void NextDialogue()
    {
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
        var logText = logGameObject.GetComponent<TMP_Text>();
        if (!logGameObject.activeSelf)
        {
            logGameObject.SetActive(true);
            for (var i = 0; i < _currentDialogue+1; i++)
            {
                logText.text += "\n" + script[i];
            }
        }
        else
        {
            logGameObject.SetActive(false);
            logText.text = "Log:";
        }
    }
}