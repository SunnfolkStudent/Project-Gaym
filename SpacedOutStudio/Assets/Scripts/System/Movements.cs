using System.Collections;
using UnityEngine;

namespace System
{
    public class Movements : MonoBehaviour
    {
        public float bobAmount;
        public bool stopmoving;
        public bool moving;
        public IEnumerator Move(GameObject whatToMove, float amount, float speed)
        {
            moving = true;
            for (var i = 0; i < MathF.Abs(amount) / speed; i++)
            {
                if (stopmoving) break;
                if (amount > 0)
                {
                    whatToMove.transform.Translate(speed, 0, 0);
                }
                else
                {
                    whatToMove.transform.Translate(-speed, 0, 0);
                }

                yield return new WaitForFixedUpdate();
            }

            if (stopmoving)
            {
                whatToMove.transform.Translate(amount,0,0);
                stopmoving = false;
            }
            
            moving = false;
        }

        public IEnumerator Bob(GameObject whatToMove, float speed)
        {
            for (var i = 0; i < bobAmount / speed; i++)
            {
                whatToMove.transform.Translate(0,speed,0);
                yield return new WaitForFixedUpdate();
            }
            for (var i = 0; i < bobAmount / speed; i++)
            {
                whatToMove.transform.Translate(0,-speed,0);
                yield return new WaitForFixedUpdate();
            }

        }
    }
}