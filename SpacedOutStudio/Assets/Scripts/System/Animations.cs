using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public bool playAnimation;
    // Start is called before the first frame update

    private void Update()
    {
        if (playAnimation == true)
        {
            GetComponent<Animation>().Stop();
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        playAnimation = false;
    }
}
