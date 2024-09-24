using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClicker : MonoBehaviour
{
    // Camera reference
    public Camera myCamera;

    // Physics values
    public float spherecastRadius = 1f;

    // Debug visuals
    public Transform clickHandleCenter;
    public Transform clickHandlePoint;

    // We do this in LateUpdate so that it happens after the cube's Update logic
    void LateUpdate()
    {
        // Get the mouse position 
        Vector2 mousePosition = Input.mousePosition;

        // Turn into a "world" ray (from the 2D screen to 3D space)
        Ray worldRay = myCamera.ScreenPointToRay(mousePosition);

        // This function will return the FIRST object hit
        //if (Physics.SphereCast(worldRay, spherecastRadius, out RaycastHit hitInfo))
        //{
        //    ClickableObject clickable = hitInfo.transform.GetComponent<ClickableObject>();
        //    if (clickable != null)
        //    {
        //        clickable.Hover();
        //    }
        //}

        // This function will return ALL objects hit
        RaycastHit[] hits = Physics.SphereCastAll(worldRay, spherecastRadius);
        foreach (RaycastHit hit in hits)
        {
            // See if the object has a ClickableObject.cs script attached
            ClickableObject clickable = hit.transform.GetComponent<ClickableObject>();
            if (clickable != null)
            {               
                clickable.Hover();
            }
        }

        // On a click, move the debug visuals
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(worldRay, out RaycastHit hitInfo))
            {
                // This goes to the center of the object we "hit"
                clickHandleCenter.position = hitInfo.transform.position;

                // This goes to the exact point where we "hit" the object
                clickHandlePoint.position = hitInfo.point;
            }
        }

        // Used for debug visuals
        Debug.DrawRay(worldRay.origin, worldRay.direction);
    }
}
