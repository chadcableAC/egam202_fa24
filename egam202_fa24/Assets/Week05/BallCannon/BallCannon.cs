using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCannon : MonoBehaviour
{
    // The object we'll create (the cannonball)
    public GameObject ballPrefab;

    // The point we'll create the cannon ball
    public Transform launchTransform;

    // How much to launch by
    public float launchForce;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Create the object at the reference position
            GameObject newObject = Instantiate(ballPrefab, launchTransform.position, Quaternion.identity);

            // Get the rigidbody
            Rigidbody objRb = newObject.GetComponent<Rigidbody>();
            if (objRb)
            {
                // Add a force
                objRb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
            }
        }
    }
}
