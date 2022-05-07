using System.Collections;
using UnityEngine;
namespace Cutscene
{
    public class CameraMove : MonoBehaviour
    {
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
    }
}
