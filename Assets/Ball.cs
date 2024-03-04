using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    int speed = 30;
    GameObject player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.black;
        rb = GetComponent<Rigidbody>();

        addStartingForce();

        player1 = GameObject.Find("Player1");
        // player2 = GameObject.Find("Player2");
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Player1" | collision.gameObject.name == "Player2"){
            rb.velocity = -rb.velocity.normalized * speed;
        }
    }

    private void addStartingForce() {
        float zDirection = UnityEngine.Random.value > 0.5f ? 1.0f : -1.0f;
        rb.velocity = new Vector3(zDirection * speed, 0, zDirection * speed);
        // rb.AddForce(new Vector3(0,0,zSpeed) * zDirection);
        // rb.AddForce(new Vector3(400,0,0) * zDirection);

    }

    private void FixedUpdate() {
        rb.velocity = rb.velocity.normalized * speed;

        if(rb.position.z > player1.GetComponent<Rigidbody>().position.z + 2 ) { //Later make a trigger in order to account for this
            print("Lost");
            rb.MovePosition(new Vector3(0,5,0));
            
            addStartingForce();
        }

        // if(rb.position.z < player2.GetComponent<Rigidbody>().position.z - 2) {
        //     print("Lost");
        //      rb.MovePosition(new Vector3(0,5,0));
        //      addStartingForce();
        // }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
