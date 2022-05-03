using System.Collections;
using UnityEngine;

namespace System
{
	public class Movements : MonoBehaviour
	{
		public IEnumerator Move(GameObject whatToMove,float amount, float speed)
		{
			whatToMove.transform.Translate(amount/10,0,0);
			yield return new WaitForSeconds(speed/10);
		}
	}
}
