using UnityEngine;
using UnityEngine.UI;

namespace System
{
	[RequireComponent(typeof(DialogueManager))]
	public class Expressions : MonoBehaviour
	{
		private DialogueManager _dialogueManager;
		public Image rageheart;
		public Sprite[] expressionsSprites;

		private void Start()
		{
			_dialogueManager = GetComponent<DialogueManager>();
		}

		private void Update()
		{
			rageheart.sprite = expressionsSprites[_dialogueManager.currentDialogue];
		}
	}
}
