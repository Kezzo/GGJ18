using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIBlocker : MonoBehaviour 
{
    public NavMeshAgent enemyAgent;
    public NavMeshAgent playerAgent;
    public Transform target;

    public float distanceThreadshold;

    IEnumerator Start () 
    {
        StartCoroutine(BlockState());

        yield break;
    }

    private IEnumerator BlockState()
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
