using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    public GameObject _camera;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_camera.transform.position.y < 23)
        {
            if (_camera.transform.position.y > 23)
            {
                _animator.Play("Hero Draw Sword");
            }
        }
    }
}
