using UnityEngine;

namespace System
{
	[RequireComponent(typeof(DialogueManager))]
	public class Expressions : MonoBehaviour
	{
		private DialogueManager _dialogueManager;

		private void Start()
		{
			_dialogueManager = GetComponent<DialogueManager>();
		}
	}
}
