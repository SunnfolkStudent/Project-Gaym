using UnityEngine;
using UnityEngine.UI;

namespace System
{
	[RequireComponent(typeof(Movements))]
	[RequireComponent(typeof(DialogueManager))]
	public class ExpressionsEmotesAndMovements : MonoBehaviour
	{
		private DialogueManager _dialogueManager;
		private Movements _movements;
		public Image rageheart;
		[Header("Expressions and Emotes")]
		[Space]
		public Sprite[] expressionsSprites;
		public GameObject[] emotes;
		[Header("Movements")]
		[Space]
		public GameObject[] spriteToMove;
		public bool[] bob;
		public float[] howMuchToMove;
		public float[] speed;
		
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

			if (howMuchToMove[currentInt] != 0)
			{
				StartCoroutine(_movements.Move(spriteToMove[currentInt], howMuchToMove[currentInt], speed[currentInt]));
			}

			if (bob[currentInt])
			{
				StartCoroutine(_movements.Bob(spriteToMove[currentInt], speed[currentInt]));
			}
			_lastDialogue = currentInt;
			
		}
	}
}
