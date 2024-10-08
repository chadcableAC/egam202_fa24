using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Rigidbody myRb;

    public float force;

    public ForceMode mode;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Add the force when clicked
            myRb.AddForce(transform.forward * force, mode);
        }
    }
}
