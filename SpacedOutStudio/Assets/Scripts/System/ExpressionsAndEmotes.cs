using UnityEngine;
using UnityEngine.UI;

namespace System
{
	[RequireComponent(typeof(Movements))]
	[RequireComponent(typeof(DialogueManager))]
	public class ExpressionsAndEmotes : MonoBehaviour
	{
		private DialogueManager _dialogueManager;
		private Movements _movements;
		public Image rageheart;
		[Header("Expressions and Emotes")]
		public Sprite[] expressionsSprites;
		public GameObject[] emotes;
		[Header("Movements")]
		public GameObject[] SpriteToMove;
		public float[] howMuchToMove;
		public float[] speed;
		public bool[] bob;
		private int _lastDialogue;

		private void Start()
		{
			_movements = GetComponent<Movements>();
			_dialogueManager = GetComponent<DialogueManager>();
		}

		public void UpdateSprite()
		{
			if (expressionsSprites[_dialogueManager.currentDialogue] != null)
			{
				rageheart.sprite = expressionsSprites[_dialogueManager.currentDialogue];
			}

			if (_dialogueManager.currentDialogue > 0)
			{
				if (emotes[_lastDialogue] != null)
				{
					emotes[_lastDialogue].SetActive(false);
				}
			}
			if (emotes[_dialogueManager.currentDialogue] != null)
			{
				emotes[_dialogueManager.currentDialogue].SetActive(true);
			}

			/*if (howMuchToMove[_dialogueManager.currentDialogue] != 0)
			{
				
			}*/
			//print(_lastDialogue);
			_lastDialogue = _dialogueManager.currentDialogue;
			
		}
	}
}
