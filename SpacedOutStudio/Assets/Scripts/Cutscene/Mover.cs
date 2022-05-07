using System;
using System.Collections;
using UnityEngine;

namespace Cutscene
{
    public class Mover : MonoBehaviour
    {
        private Animator _animator;

        private bool _stop;
        public float speed = 4f;
        public float delay = 1f;
        [HideInInspector]public bool drawnSword;
        public GameObject gameCamera;


        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (transform.position.y < 20)
            {
                transform.Translate(Vector3.up * (speed * Time.deltaTime));
            }
            else
            {
                _animator.Play("Hero Draw Sword");
            }
        }

        private void DrawSword()
        {
            if (transform.position.y < 21)
            {
                _animator.Play("Hero Draw Sword");
                drawnSword = true;
            }
        }
    }
}
