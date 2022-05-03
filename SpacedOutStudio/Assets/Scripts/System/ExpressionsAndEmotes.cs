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
			var currentInt = _dialogueManager.currentDialogue;
			if (expressionsSprites[currentInt] != null)
			{
				rageheart.sprite = expressionsSprites[currentInt];
			}

			if (currentInt > 0)
			{
				if (emotes[_lastDialogue] != null)
				{
					emotes[_lastDialogue].SetActive(false);
				}
			}
			if (emotes[currentInt] != null)
			{
				emotes[currentInt].SetActive(true);
			}

			/*if (howMuchToMove[currentInt] != 0)
			{
				StartCoroutine(_movements.Move(SpriteToMove[currentInt], howMuchToMove[currentInt], speed[currentInt]));
			}*/
			_lastDialogue = currentInt;
			
		}
	}
}
