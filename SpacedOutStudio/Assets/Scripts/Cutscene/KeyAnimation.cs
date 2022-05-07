using UnityEngine;

namespace Cutscene
{
    public class KeyAnimation : MonoBehaviour
    {
        public Animator transition;
        public void Fade()
        {
            transition.Play("fadeTransition_out");
        }
    }
}