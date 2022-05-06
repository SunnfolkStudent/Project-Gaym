using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private bool _stop;
    public float speed = 4f;
    
    private void Update()
    {
        if (transform.position.y < 22)
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
