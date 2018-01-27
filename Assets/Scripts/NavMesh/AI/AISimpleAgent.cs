
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AISimpleAgent : AIAgent
{
    private IEnumerator Start()
    {
        while (true)
        {
            if (aIManager != null)
            {
                StartCoroutine(NextLightState());
            }

            yield return null;
        }
    }

    public void GoTo(GameObject current)
    {
        var nextPosition = current.transform.position;

        // Keep the same height
        nextPosition.y = transform.position.y;

        agent.destination = nextPosition;
    }

    private IEnumerator NextLightState()
    {
        agent.destination = agent.transform.position;
        
        while (true)
        {
            if (agent.destination.XZ() == agent.transform.position.XZ())
            {
                yield return new WaitForSeconds(2);

                var newGate = aIManager.AssignMeAGate(this);

                GoTo(newGate.gameObject);
            }

            yield return null;
        }
    }
}
