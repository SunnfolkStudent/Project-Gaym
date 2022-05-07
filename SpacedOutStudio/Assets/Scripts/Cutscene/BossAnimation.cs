using UnityEngine;

namespace Cutscene
{
    public class BossAnimation : MonoBehaviour
    {
        public Animations animations;

        public void PullOutKey()
        {
            animations.KeyOn();
        }

        public void RotateKey()
        { 
            animations.RotateKey();  
        }
    }
}