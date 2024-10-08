using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBall : MonoBehaviour
{
    public float speed;

    public Rigidbody myRb;

    // Use FixedUpdate when dealing with physics objects
    void FixedUpdate()
    {
        // WHich direction is pressed?
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector3.back;
        }

        // Move by setting the velocity
        myRb.velocity = direction * speed;

        // Try not to adjust a rigidbody's transform - use the rigidbody velocity or AddForce instead
        //transform.position += direction * speed * Time.fixedDeltaTime;
    }
}
