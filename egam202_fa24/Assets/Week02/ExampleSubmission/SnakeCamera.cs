using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCamera : MonoBehaviour
{
    public Camera cam;

    public float flashDuration = 1;

    Color originalColor = Color.blue;
    Color flashColor = Color.white;
    float flashTimer = 0;

    void Start()
    {
        // Store the starting color of the background
        originalColor = cam.backgroundColor;
    }

    void Update()
    {
        // Countdown when the timer is active (above zero)
        if (flashTimer > 0)
        {
            // Decrement the timer
            flashTimer -= Time.deltaTime;

            // Turn the timer into an interp (between 0 and 1)
            float interp = flashTimer / flashDuration;

            // Determine and set the color (go from the flash back to the original color)
            Color color = Color.Lerp(originalColor, flashColor, interp);
            cam.backgroundColor = color;
        }
    }

    public void Flash(Color color)
    {
        // Set the color
        flashColor = color;

        // Restart the timer (counts down to zero)
        flashTimer = flashDuration;
    }

    public void Set(Color color)
    {
        // Unset the timer (stop any current animations)
        flashTimer = -1;

        // Set the color here
        cam.backgroundColor = color;
    }
}
