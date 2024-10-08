using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClickManager : MonoBehaviour
{
    public Camera myCamera;
    public float spherecastRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // First - reset all cubes to original color
            CubeClick[] allCubes = FindObjectsOfType<CubeClick>();
            foreach (CubeClick cube in allCubes)
            {
                cube.Reset();
            }

            // Turn the mouse screen position into a world position
            Vector2 mousePosition = Input.mousePosition;
            Ray worldRay = Camera.main.ScreenPointToRay(mousePosition);

            // Version 1 - get the FRIST object hit
            //if (Physics.Raycast(worldRay, out RaycastHit hitInfo))
            //{
            //    CubeClick clicked = hitInfo.transform.GetComponent<CubeClick>();
            //    if (clicked != null)
            //    {
            //        clicked.OnClick();
            //    }
            //}

            // Version 2 - get ALL objects hit
            //RaycastHit[] hits = Physics.RaycastAll(worldRay);
            //foreach (RaycastHit hit in hits)
            //{
            //    CubeClick clicked = hit.transform.GetComponent<CubeClick>();
            //    if (clicked != null)
            //    {
            //        clicked.OnClick();
            //    }
            //}

            // FIRST - lets see if an obstacle is hit by a raycast
            float obstacleDistance = Mathf.Infinity;
            if (Physics.Raycast(worldRay, out RaycastHit hitInfo))
            {
                CubeClickObstacle obstacle = hitInfo.transform.GetComponent<CubeClickObstacle>();
                if (obstacle != null &&
                    obstacle.isBlocking)
                {
                    obstacleDistance = hitInfo.distance;
                }
            }
            
            // SECOND - see if any objects are before/closer than any obstacle we find
            RaycastHit[] hits = Physics.SphereCastAll(worldRay, spherecastRadius);
            foreach (RaycastHit hit in hits)
            {
                CubeClick clicked = hit.transform.GetComponent<CubeClick>();
                if (clicked != null)
                {
                    if (hit.distance < obstacleDistance)
                    {
                        clicked.OnClick();
                    }
                }
            }
        }
    }
}
