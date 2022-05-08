using UnityEngine;

namespace Cutscene
{
    public class BossAnimation : MonoBehaviour
    {
        public Animations animations;
        

        public void RotateKey()
        { 
            animations.RotateKey();  
        }
    }
}