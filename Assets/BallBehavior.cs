using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
 
    // Use this for initialization
    void Start ()
    {
        Invoke("RestartBall", 2);
    }

 
    // Update is called once per frame
    void Update ()
    {
        this.transform.position += direction * speed;
    }

    void RestartBall()
    {
        // rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
                // Generate random values for X and Z axes separately within your desired range.
        float randomX = Random.Range(-1.0f, 1.0f);
        float randomY = Random.Range(-1.0f, 1.0f);

        // Create the direction vector using the random values and normalize it.
        direction = new Vector3(randomX, randomY, 0.0f ).normalized;
        this.speed = 0.1f;
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);
    }
}
