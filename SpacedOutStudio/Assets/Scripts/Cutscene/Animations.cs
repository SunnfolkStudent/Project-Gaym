using UnityEngine;

namespace Cutscene
{
    public class Animations : MonoBehaviour
    {
        public Animator heroAnimator;
        public Animator bossAnimator;
        public Animator keyAnimator;

        public GameObject key;
        public GameObject boss;
        public GameObject hero;
    

        public void HeroWalk()
        {
            heroAnimator.Play("Hero Walk");
        }

        public void HeroDrawSword()
        {
            heroAnimator.Play("Hero Draw Sword");
        }

        public void BossLaugh()
        {
            bossAnimator.Play("Boss Laugh");
        }

        public void Key()
        {
            key.SetActive(true);
            keyAnimator.Play("Key Rotate");
        }
    }
}
