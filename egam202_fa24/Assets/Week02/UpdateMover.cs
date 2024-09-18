using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMover : MonoBehaviour
{
    public float unitsPerSecond = 1f;

    Vector3 moveDirection = Vector3.forward;

    void Update()
    {
        // Move this amount every frame
        Vector3 moveAmount = moveDirection * unitsPerSecond;

        // Multipy by deltaTime to "split up" the movement into a single frame
        moveAmount *= Time.deltaTime;

        // Finally add to our current position
        transform.position += moveAmount;
    }

    public Vector3 GetDirection()
    {
        // Return our direction
        return moveDirection;
    }

    public void ChangeDirection(Vector3 newDirection)
    {
        // Set our direction to the new one
        moveDirection = newDirection;
    }
}
