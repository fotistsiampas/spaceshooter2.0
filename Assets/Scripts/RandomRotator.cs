using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//o kodikas apo to tutorial den douleue sosta kai brhka apo ta comments mia lush pou douleue
public class RandomRotator : MonoBehaviour
{
    public float tumble;

    void Start() 
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}
