using UnityEngine;

namespace System
{
	public class Keyboard : MonoBehaviour
	{
		private int _currentKey;
		public string nameText;
		public void Keypress(string character)
		{
			nameText= nameText.Insert(_currentKey++, character);
		}
	}
}
