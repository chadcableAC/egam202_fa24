using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetector : MonoBehaviour
{
    // Logic variable
    public Vector3 raycastDirection = Vector3.forward;

    // Visuals
    public Renderer myRenderer;

    public Color colorDoor = Color.blue;
    public Color colorDetect = Color.red;
    public Color colorNothing = Color.white;

    void Update()
    {
        // Create a ray (an origin and direction)
        Ray ray = new Ray(transform.position, raycastDirection);

        // Start with the "nothing" color
        Color cubeColor = colorNothing;

        // Returns TRUE if we hit a collider
        if (Physics.Raycast(ray, out RaycastHit raycastInfo))
        {
            // Switch to the "hit object" color
            cubeColor = colorDetect;

            // See if the object the raycast hit has a Door.cs script attached
            if (raycastInfo.transform.GetComponent<Door>())
            {
                cubeColor = colorDoor;
            }
        }

        // Set the color
        myRenderer.material.color = cubeColor;

        // This helps us visualize what's happening in the editor
        Debug.DrawRay(ray.origin, ray.direction);
    }
}
