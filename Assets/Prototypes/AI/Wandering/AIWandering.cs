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
        StartCoroutine(AIStates.BlockState(
            distanceThreadshold, 
            target,
            enemyAgent,
            playerAgent
            ));

        yield break;
    }
}
