using UnityEngine;

namespace System
{
	public class FadeEarly : MonoBehaviour
	{
		public Animator fadeAnimatior;
		public int fadeElement;
		private DialogueManager _dialogueManager;
		public bool blackOutWholeScreen;
		private SceneController _sceneController;

		private void Start()
		{
			_sceneController = GetComponent<SceneController>();
			_dialogueManager = GetComponent<DialogueManager>();
		}

		private void Update()
		{
			if (fadeElement != _dialogueManager.currentDialogue) return;
			if (!blackOutWholeScreen)
			{
				fadeAnimatior.transform.SetSiblingIndex(3);
			}
			fadeAnimatior.Play("fadeTransition_out 1");
		}
	}
}
