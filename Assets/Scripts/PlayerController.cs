using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{

    public float xMin, xMax, yMin, yMax;

}

//kodikas apo tutorial me allages gia na kinhte sosta to diasthmoploio
public class PlayerController : MonoBehaviour

{
    private Rigidbody rb;
    public float speed = 10.0f;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    public float tilt;

    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (

            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

        rb.rotation = Quaternion.Euler(0.0f, 90.0f, rb.velocity.y * tilt); //gia na douleuei sosta h kinhsh tou diasthmoploioy
    }
}
