using UnityEngine;

namespace Cutscene
{
    public class Animations : MonoBehaviour
    {
        public Animator heroAnimator;
        public Animator bossAnimator;
        public Animator keyAnimator;


        public void HeroWalk()
        {
            heroAnimator.enabled = true;
        }

        public void HeroStop()
        {
            heroAnimator.enabled = false;
        }

        public void HeroDrawSword()
        {
            heroAnimator.enabled = true;
            heroAnimator.Play("Hero Draw Sword");
        }

        public void BossLaugh()
        {
            bossAnimator.enabled = true;
            bossAnimator.Play("Boss Laugh");
        }

        public void KeyOn()
        {
            keyAnimator.gameObject.SetActive(true);
        }

        public void RotateKey()
        {
            keyAnimator.Play("Key Rotate");
        }
    }
}