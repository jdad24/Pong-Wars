using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody playerRigidbody;
    float speed = 250f;
    int direction = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.drag = 5;
    }

    void handlePlayerInput() {
        if(Input.GetKey(KeyCode.UpArrow)) {
            direction = 1;
        } else if(Input.GetKey(KeyCode.DownArrow)) {
            direction = -1;
        } else {
            direction = 0;
        }

        if(Math.Pow(direction, direction) != 0) {
            // playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            playerRigidbody.AddForce(new Vector3(direction * speed, 0, 0));
        } 
    }

    void OnCollisionEnter(Collision collision) {

    }

    void OnCollisionExit(Collision collision) {
       
    }

    void FixedUpdate() {
        handlePlayerInput(); 
        // playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
