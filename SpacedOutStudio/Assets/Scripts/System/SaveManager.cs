using UnityEngine;

namespace System
{
	public class SaveManager : MonoBehaviour
	{
		private DialogueManager _dialogueManager;
		private ChoiceManager _choiceManager;

		private void Start()
		{
			_choiceManager = GetComponent<ChoiceManager>();
			_dialogueManager = GetComponent<DialogueManager>();
		}

		public void Save()
		{
			PlayerPrefs.SetInt("relScore",_choiceManager.relationScore);
		}
	}
}
