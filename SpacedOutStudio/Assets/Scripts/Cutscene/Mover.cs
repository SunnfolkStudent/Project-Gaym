using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Animator _animator;

    private bool _stop;
    public float speed = 4f;
    public float delay = 1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position.y < 20)
        {
            StartCoroutine(Move());
        }
        else
        {
            _animator.Play("State1");
            Invoke("DrawSword", delay);
        }
    }

    private IEnumerator Move()
    {
        transform.Translate(Vector3.up * speed *Time.deltaTime);
        yield return new WaitForFixedUpdate();
    }

    void DrawSword()
    {
        if (transform.position.y < 21)
        {
            _animator.Play("Hero Draw Sword");
        }
    }
}
