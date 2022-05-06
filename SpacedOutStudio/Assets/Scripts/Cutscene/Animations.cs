using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator heroAnimator;
    public Animator bossAnimator;
    public Animator keyAnimator;

    public GameObject key;
    public GameObject boss;
    public GameObject hero;
    
    /*private void Update()
    {
        StartCoroutine(Cutscene());
    }*/

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

    /*private IEnumerator Cutscene()
    {
        HeroWalk();
        yield return new WaitForSeconds(5);
        HeroDrawSword();
        yield return new WaitForSeconds(1);
        BossLaugh();
        yield return new WaitForSeconds(3);
        Key();
    }*/
}
