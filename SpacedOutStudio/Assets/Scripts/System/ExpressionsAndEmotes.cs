using UnityEngine;
using UnityEngine.UI;

namespace System
{
	[RequireComponent(typeof(DialogueManager))]
	public class ExpressionsAndEmotes : MonoBehaviour
	{
		private DialogueManager _dialogueManager;
		public Image rageheart;
		public Sprite[] expressionsSprites;
		public GameObject[] emotes;

		private void Start()
		{
			_dialogueManager = GetComponent<DialogueManager>();
		}

		public void UpdateSprite()
		{
			if (expressionsSprites[_dialogueManager.currentDialogue] != null)
			{
				rageheart.sprite = expressionsSprites[_dialogueManager.currentDialogue];
			}

			if (_dialogueManager.currentDialogue > 1)
			{
				if (emotes[_dialogueManager.currentDialogue-1] != null)
				{
					emotes[_dialogueManager.currentDialogue-1].SetActive(false);
				}
			}
			if (emotes[_dialogueManager.currentDialogue] != null)
			{
				emotes[_dialogueManager.currentDialogue].SetActive(true);
			}
		}
	}
}
