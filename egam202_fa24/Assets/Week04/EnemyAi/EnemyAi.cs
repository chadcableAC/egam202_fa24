using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public enum AiStates
    {
        Patrol,
        Chase,
        RunAway,
        Random
    }

    public AiStates currentState;
    private AiStates lastState;

    public NavMeshAgent navAgent;

    public Transform[] patrolTransforms;
    public int patrolIndex;

    public Transform chaseTransform;


    void Update()
    {
        if (currentState != lastState)
        {
            lastState = currentState;
            SwitchingStates();
        }


        switch (currentState)
        {
            case AiStates.Patrol:
                PatrolUpdate();
                break;
            case AiStates.Chase:
                ChaseUpdate();
                break;
            case AiStates.RunAway:
                RunAwayUpdate();
                break;
            case AiStates.Random:
                RandomUpdate();
                break;
        }
    }

    void SwitchingStates()
    {

        switch (currentState)
        {
            case AiStates.Patrol:
                Vector3 targetPosition = patrolTransforms[patrolIndex].position;
                navAgent.destination = targetPosition;
                break;
        }
    }

    void PatrolUpdate()
    {
        if (navAgent.remainingDistance < 0.1f)
        {
            patrolIndex++;

            if (patrolIndex >= patrolTransforms.Length)
            {
                patrolIndex = 0;
            }

            Vector3 targetPosition = patrolTransforms[patrolIndex].position;
            navAgent.destination = targetPosition;
        }
    }

    void ChaseUpdate()
    {
        // Move to the target position
        Vector3 targetPosition = chaseTransform.position;
        navAgent.destination = targetPosition;
    }

    void RunAwayUpdate()
    {
        // Direction of A to B = B - A
        Vector3 delta = chaseTransform.position - transform.position;
        Vector3 direction = delta.normalized;

        // Move in teh opposite direction
        navAgent.destination = transform.position - direction;
    }

    void RandomUpdate()
    {
        if (navAgent.remainingDistance < 0.1f ||
            navAgent.hasPath == false)
        {
            Vector3 newPosition = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            navAgent.destination = newPosition;
        }
    }
}
