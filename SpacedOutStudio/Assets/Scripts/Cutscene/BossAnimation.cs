using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    //public GameObject _camera;

    private Animator _animator;
    private Mover _mover;
    public float delay = 1f;

    private void Start()
    {
        _mover = GetComponent<Mover>();
        //_animator.GetComponent<Animator>().enabled = false;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        /*if (_camera.transform.position.y < 23)
        {
            if (_camera.transform.position.y > 23)
            {
                _animator.Play("Hero Draw Sword");
            }
        }*/

        if (_mover.drawnSword)
        {
            _animator.GetComponent<Animator>().enabled = true;
            StartCoroutine(Laugh());
        }
    }

    private IEnumerator Laugh()
    {
        yield return new WaitForSeconds(delay);
        _animator.Play("Boss Laugh");
    }
}