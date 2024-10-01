using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTester : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ENTER");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("STAY");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("EXIT");
    }

    private void Update()
    {
        //Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //Time.fixedDeltaTime;
    }
}
