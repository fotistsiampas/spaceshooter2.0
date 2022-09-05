using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//apo tutorial
public class Mover : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody>().velocity = transform.right * speed;

    }

}
