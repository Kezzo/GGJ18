using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIFullAgent : AIAgent 
{
    public enum State 
    {
        Idle,
        Blocking,
        Wandering,
    }

    [SerializeField]
    private NavMeshAgent playerAgent;

    #region wandering parameters
    [SerializeField]
    private float wanderingSpeed = 4;

    [SerializeField]
    private float wanderingDistance = 1;

    [SerializeField]
    private float wanderingDirectionChangePeriod = 1;
    #endregion

    #region private fields
    private State state = State.Idle;
    private Vector3 enemyEndPos;
    private Vector3 playerEndPos;
    private Coroutine lastCoroutine;
    #endregion

    IEnumerator Start () 
    {
        yield return null;

        // Initial positions
        enemyEndPos = transform.position;
        playerEndPos = playerAgent.transform.position;
        agent.destination = agent.transform.position;
        
        while (true)
        {
            // Evaluate condition to change the behaviour
            var newState = State.Wandering;

            // Stop previous behaviour if the state changes
            if (newState != state && lastCoroutine != null)
            {
                StopCoroutine(lastCoroutine);
            }

            // Select new state
            switch (state)
            {
                case State.Wandering:
                    lastCoroutine = StartCoroutine(
                        AIStates.WanderingState(
                            agent.transform.position,
                            wanderingDirectionChangePeriod,
                            wanderingDistance,
                            wanderingSpeed,
                            agent));
                    break;
            }

            state = newState;

            yield return null;
        }
    }

    private IEnumerator BlockingState()
    {
        yield break;
    }


}
