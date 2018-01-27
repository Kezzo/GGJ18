using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public sealed class AIBlocker : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent enemyAgent;
    [SerializeField]
    private NavMeshAgent playerAgent;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distanceThreadshold;

    IEnumerator Start()
    {
        var blockerState = new AIStates.BlockState(
            distanceThreadshold,
            target,
            enemyAgent);

        StartCoroutine(blockerState.Enter());

        yield break;
    }
}
