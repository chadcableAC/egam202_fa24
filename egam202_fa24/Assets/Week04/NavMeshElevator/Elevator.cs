using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Elevator : MonoBehaviour
{
    // Positions for entering / leaving the elevator
    public Transform enterPosition;
    public Transform exitPosition;

    // Position to stand in the elevator
    public Transform standPosition;

    // Positions the elevator should move between
    public Transform lowerPosition;
    public Transform upperPosition;

    // Value between 0 and 1 that moves the elevator from lower to upper position
    public float elevatorInterp;

    // How long the rise should take
    public float riseDuration = 3f;

    // The trigger for knowing a player has entered the elevator
    public Collider trigger;

    // Whether the elevator is at the top or not
    public bool isUpTop = false;

    private void OnTriggerEnter(Collider other)
    {
        // If there's an agent, make teh elevator move
        TestNavAgent agent = other.GetComponent<TestNavAgent>();
        if (agent)
        {
            StartCoroutine(ExecuteLift(agent));
        }
    }

    IEnumerator ExecuteLift(TestNavAgent agent)
    {
        // Move onto elevator
        agent.enabled = false;
        trigger.enabled = false;

        // Wait until it gets close enough to the standing position
        agent.navAgent.destination = standPosition.position;
        yield return null;

        while (agent.navAgent.remainingDistance > 0.1f)
        {
            yield return null;
        }

        // Now we'll make the elevator move 
        agent.navAgent.enabled = false;
        agent.transform.SetParent(transform, true);

        float timer = 0;
        while (timer < riseDuration)
        {
            yield return null;
            timer += Time.deltaTime;

            Vector3 fromPosition = lowerPosition.position;
            Vector3 toPosition = upperPosition.position;
            if (isUpTop)
            {
                fromPosition = upperPosition.position;
                toPosition = lowerPosition.position;
            }

            float interp = timer / riseDuration;
            Vector3 newPosition = Vector3.Lerp(fromPosition, toPosition, interp);
            transform.position = newPosition;
        }

        // MOve onto elevator
        agent.transform.SetParent(null, true);
        agent.navAgent.enabled = true;

        if (isUpTop)
        {
            agent.navAgent.destination = enterPosition.position;
        }
        else
        {
            agent.navAgent.destination = exitPosition.position;
        }

        yield return null;
        while (agent.navAgent.remainingDistance > 0.1f)
        {
            yield return null;
        }

        trigger.enabled = true;
        agent.enabled = true;

        isUpTop = !isUpTop;
    }
}
