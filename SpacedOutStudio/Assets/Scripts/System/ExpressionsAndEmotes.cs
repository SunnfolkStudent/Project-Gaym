using UnityEngine;
using UnityEngine.UI;

namespace System
{
	[RequireComponent(typeof(DialogueManager))]
	public class ExpressionsAndEmotes : MonoBehaviour
	{
		private DialogueManager _dialogueManager;
		public Image rageheart;
		public Image emote;
		public Sprite[] expressionsSprites;
		public Sprite[] emoteSprite;

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

			if (emoteSprite[_dialogueManager.currentDialogue] != null)
			{
				emote.sprite = emoteSprite[_dialogueManager.currentDialogue];
			}
		}
	}
}
