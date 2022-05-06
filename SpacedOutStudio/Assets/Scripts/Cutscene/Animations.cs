using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public bool playAnimation;

    private void Update()
    {
        if (playAnimation == true)
        {
            GetComponent<Animation>().Stop();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        playAnimation = false;
    }
}
