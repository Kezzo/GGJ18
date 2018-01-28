using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIWandering : MonoBehaviour
{
    public NavMeshAgent enemyAgent;

    #region wandering parameters
    [SerializeField]
    private float wanderingSpeed = 4;
    [SerializeField]
    private float wanderingDistance = 1;
    [SerializeField]
    private float wanderingDirectionChangePeriod = 1;
    #endregion

    IEnumerator Start()
    {
        var wanderingState = new AIStates.WanderingState(
            enemyAgent.transform.position,
            wanderingDirectionChangePeriod,
            wanderingDistance,
            wanderingSpeed,
            enemyAgent);
        
        StartCoroutine(wanderingState.Enter());

        yield break;
    }
}