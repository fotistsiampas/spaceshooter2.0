using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//kodikas apo tutorial
public class ScrollingScriptBg : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private float speed = -.5f;
    private float width;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        rb = GetComponent<Rigidbody2D>(); 

        width = GetComponent<MeshRenderer>().bounds.size.x;

        rb.velocity = new Vector3(speed, 0);

    }
    void FixedUpdate()
    {
        if (transform.position.x < -width)
        {

            Vector3 vector = new Vector3(width * 2f, 0, 0);
            transform.position = (Vector3)transform.position + vector;

        }
    }
}

