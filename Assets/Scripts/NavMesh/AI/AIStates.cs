using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public static class AIStates
{
    public static IEnumerator WanderingState(
        Vector3 aroundPosition, 
        float wanderingDirectionChangePeriod,
        float wanderingDistance,
        float wanderingSpeed,
        NavMeshAgent agent
    )
    {
        agent.destination = aroundPosition;

        float lastTime = Time.time;

        while (true)
        {
            // One it reaches the previous destination, search for another randome place wehre to go
            if (Mathf.Abs(Time.time - lastTime) > wanderingDirectionChangePeriod)
            {
                lastTime = Time.time;

                var delta = Random.rotation * Vector3.right * wanderingDistance;

                agent.speed = wanderingSpeed;
                agent.destination = aroundPosition + delta;
            }

            yield return null;
        }
    }

    public static IEnumerator BlockState(
        float distanceThreadshold,
        Transform target,
        NavMeshAgent enemyAgent,
        NavMeshAgent playerAgent
    )
    {
        while (true)
        {
            var distance =
                (target.transform.position - playerAgent.transform.position).sqrMagnitude;

            // Tries to get in between the target and the player
            if (distance < distanceThreadshold * distanceThreadshold)
            {
                enemyAgent.destination = Vector3.Lerp(
                    target.transform.position,
                    playerAgent.transform.position, 0.5f);
            }
            else
            {
                var direction = playerAgent.transform.position - target.transform.position;

                enemyAgent.destination =
                    target.transform.position + direction.normalized * distanceThreadshold;
            }

            yield return null;
        }
    }
}
