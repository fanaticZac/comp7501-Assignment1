using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BallBehavior : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
    
    private GameObject Ready;
 
    // Use this for initialization
    void Start ()
    {
        Ready = GameObject.Find("ReadyPrompt");
        Invoke("RestartBall", 3);
    }

 
    // Update is called once per frame
    void Update ()
    {
        this.transform.position += direction * speed;
    }

    void RestartBall()
    {
        Ready.GetComponent<TextMeshProUGUI>().text = "";

        transform.position = Vector3.zero;
        float randomX = Random.Range(-1.0f, 1.0f);
        float randomY = Random.Range(-1.0f, 1.0f);

        direction = new Vector3(randomX, randomY, 0.0f ).normalized;
        this.speed = 0.1f;
    }

    private void LastSecondTextChange (){
        Ready.GetComponent<TextMeshProUGUI>().text = "Go!";
        Invoke("RestartBall", 1);
    }
    public void StopEntirely(){
        // Set the ball's velocity to zero to stop it.
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        // Reset the ball's position and invoke the ResetBall function to restart it.
        transform.position = Vector3.zero;
        this.speed = 0.0f;
    }

    public void StopBall()
    {
        // Set the ball's velocity to zero to stop it.
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        // Reset the ball's position and invoke the ResetBall function to restart it.
        transform.position = Vector3.zero;
        Invoke("LastSecondTextChange", 1);
        this.speed = 0.0f;
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);
    }
}
