using UnityEngine;

namespace Cutscene
{
    public class KeyAnimation : MonoBehaviour
    {
        public Animator transition;
        private int _counter;
        public void Fade()
        {
            _counter++;
            if (_counter == 2)
            {
                transition.Play("fadeTransition_out");
            }
        }
    }
}