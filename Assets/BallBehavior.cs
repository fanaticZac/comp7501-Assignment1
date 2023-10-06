using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("StartBall", 2);
    }

    void StartBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb.AddForce(new Vector3(60, -45, 0));
        }
        else
        {
            rb.AddForce(new Vector3(-60, -45, 0));
        }
    }

    void ResetBall()
    {
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
    }

    void OnCollisionEnter (Collision coll) {
    // if(coll.collider.CompareTag("PlayerLeft") || coll.collider.CompareTag("PlayerRight")){
    //     Vector3 vel = new Vector3(0, 0, 0);
    //     vel.x = rb.velocity.x;
    //     vel.y = (rb.velocity.y) + (coll.collider.attachedRigidbody.velocity.y);
    //     // vel.x = 0;
    //     rb.velocity = vel;
    // }
}

    // Update is called once per frame
    void Update()
    {
        // rb.AddForce(dirX, dirY, dirZ, ForceMode.Impulse);

    }
}
