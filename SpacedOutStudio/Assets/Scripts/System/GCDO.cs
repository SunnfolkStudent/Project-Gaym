using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCDO : MonoBehaviour
{
    private Vector3 rotationEuler;
    public int spinSpeed = 45;
    void Update()
    {
        rotationEuler+= Vector3.forward*spinSpeed*Time.deltaTime; //increment 30 degrees every second
        transform.rotation = Quaternion.Euler(rotationEuler);
    }
}
