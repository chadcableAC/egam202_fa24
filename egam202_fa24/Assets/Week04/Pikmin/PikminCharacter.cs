using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PikminCharacter : MonoBehaviour
{
    public enum PikminColors
    {
        Red,
        Blue,
        Yellow
    }

    public PikminColors currentColor;
    private PikminColors lastColor;

    public Renderer myRenderer;

    public NavMeshAgent navAgent;




    // Start is called before the first frame update
    void Start()
    {
        ApplyColors();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentColor != lastColor)
        {
            ApplyColors();
        }
    }

    void ApplyColors()
    {
        lastColor = currentColor;

        switch (currentColor)
        {
            case PikminColors.Red:
                // Update color
                myRenderer.material.color = Color.red;

                // Switch where the agent can navigate (Walkable OR fire)
                navAgent.areaMask = 0;
                navAgent.areaMask |= 1 << NavMesh.GetAreaFromName("Walkable");
                navAgent.areaMask |= 1 << NavMesh.GetAreaFromName("Fire");
                break;

            case PikminColors.Yellow:
                // Update color
                myRenderer.material.color = Color.yellow;

                // Switch where the agent can navigate (Walkable OR fire)
                navAgent.areaMask = 0;
                navAgent.areaMask |= 1 << NavMesh.GetAreaFromName("Walkable");
                navAgent.areaMask |= 1 << NavMesh.GetAreaFromName("Lightning");
                break;

            case PikminColors.Blue:
                // Update color
                myRenderer.material.color = Color.blue;

                // Switch where the agent can navigate (Walkable OR fire)
                navAgent.areaMask = 0;
                navAgent.areaMask |= 1 << NavMesh.GetAreaFromName("Walkable");
                navAgent.areaMask |= 1 << NavMesh.GetAreaFromName("Water");
                break;
        }
    }
}
