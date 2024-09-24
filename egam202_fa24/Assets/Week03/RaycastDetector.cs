using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDetector : MonoBehaviour
{
    public Vector3 raycastDirection = Vector3.forward;

    public Renderer myRenderer;

    public Color colorDoor = Color.blue;
    public Color colorDetect = Color.red;
    public Color colorNothing = Color.white;


    void Update()
    {
        Ray ray = new Ray(transform.position, raycastDirection);

        Color cubeColor = colorNothing;
        if (Physics.Raycast(ray, out RaycastHit raycastInfo))
        {
            cubeColor = colorDetect;

            if (raycastInfo.transform.GetComponent<Door>())
            {
                cubeColor = colorDoor;
            }
        }

        myRenderer.material.color = cubeColor;

        Debug.DrawRay(ray.origin, ray.direction);
    }
}
