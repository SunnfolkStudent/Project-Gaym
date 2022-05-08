using System.Collections;
using UnityEngine;

namespace System
{
    public class Movements : MonoBehaviour
    {
        public float bobAmount;
        [HideInInspector]public bool stopMoving;
        [HideInInspector]public bool moving;
        private Vector3 _startPoint;
        
        public IEnumerator Move(GameObject whatToMove, float amount, float speed)
        {
            moving = true;
            _startPoint = whatToMove.transform.position;
            for (var i = 0; i < MathF.Abs(amount) / speed; i++)
            {
                if (stopMoving) break;
                if (amount > 0)
                {
                    whatToMove.transform.localPosition += Vector3.right * speed;
                }
                else
                {
                    whatToMove.transform.localPosition += Vector3.left * speed;
                }

                yield return new WaitForFixedUpdate();
            }

            if (stopMoving)
            {
                whatToMove.transform.position = _startPoint;
                whatToMove.transform.Translate(amount,0,0);
                stopMoving = false;
            }
            
            moving = false;
        }

        public IEnumerator Bob(GameObject whatToMove, float speed)
        {
            for (var i = 0; i < bobAmount / speed; i++)
            {
                whatToMove.transform.localPosition += Vector3.up * speed;
                yield return new WaitForFixedUpdate();
            }
            for (var i = 0; i < bobAmount / speed; i++)
            {
                whatToMove.transform.localPosition += Vector3.down * speed;
                yield return new WaitForFixedUpdate();
            }

        }
    }
}