using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSnake : MonoBehaviour
{
    // Physics
    public Rigidbody rb;

    Vector3 moveDirection = Vector3.forward;

    public float moveSpeedMin = 1f;
    public float moveSpeedMax = 10f;

    public float moveCountMin = 1f;
    public float moveCountMax = 20f;

    public int size = 1;

    // State
    public bool isAlive = true;

    // Effects
    SnakeCamera snakeCam;
    public Color flashColor = Color.red;

    public Transform rotateHandle;

    private void Start()
    {
        // Find the script
        snakeCam = FindObjectOfType<SnakeCamera>();

        // Set the initial direction
        ChangeDirection(moveDirection);
    }

    public Vector3 GetDirection()
    {
        // Return our direction
        return moveDirection;
    }

    public void ChangeDirection(Vector3 newDirection)
    {
        // Set our direction to the new one
        if (newDirection.sqrMagnitude > Mathf.Epsilon)
        {
            moveDirection = newDirection.normalized;

            rb.velocity = moveDirection * GetSpeed();

            // Make the character change directions too
            rotateHandle.LookAt(rotateHandle.position + moveDirection, Vector3.up);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if this is an apple
        SnakeApple apple = other.GetComponentInParent<SnakeApple>();
        if (apple != null)
        {
            // Collect the apple
            apple.Collect();

            // Increase our size and speed
            size++;
            ChangeDirection(moveDirection);

            // Feedback
            snakeCam.Flash(flashColor);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Assume this is game over...
        if (isAlive)
        {
            // Set to false
            isAlive = false;            
            ChangeDirection(moveDirection);

            // Feedback
            snakeCam.Set(Color.black);
        }
    }

    float GetSpeed()
    {
        // Determine the speed based on how many apples we've eaten
        float countInterp = (size - moveCountMin) / (moveCountMax - moveCountMin);
        float speed = Mathf.Lerp(moveSpeedMin, moveSpeedMax, countInterp);

        // If we're dead, set the speed to zero (stop moving)
        if (!isAlive)
        {
            speed = 0;
        }

        return speed;
    }
}
