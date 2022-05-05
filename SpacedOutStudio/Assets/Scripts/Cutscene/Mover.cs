using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject heroEndPosition;
    public GameObject cameraEndPosition;

    public Animator heroWalk;
    public Animator heroDrawSword;
    //public Animator bossLaugh;
    //public Animator key;
    private bool _stop;
    public float speed = 2f;


    private void Update()
    {
        if (transform.position.y < 20)
        {
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        transform.Translate(Vector3.up * speed *Time.deltaTime);
        yield return new WaitForFixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _stop = true;
    }
}
