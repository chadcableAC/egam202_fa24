using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavAgent : MonoBehaviour
{
    // Object moving on the nav mesh
    public NavMeshAgent navAgent;

    void Update()
    {
        // Run this logic on left click
        if (Input.GetMouseButtonDown(0))
        {
            // Turn the mouse position into a world position
            Vector2 mousePosition = Input.mousePosition;
            Ray worldRay = Camera.main.ScreenPointToRay(mousePosition);

            // Move the agent to the point "hit" by the raycast
            if (Physics.Raycast(worldRay, out RaycastHit hitInfo))
            {
                navAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
