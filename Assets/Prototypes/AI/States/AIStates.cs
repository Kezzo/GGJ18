using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStates : MonoBehaviour 
{
    public enum State 
    {
        Idle,
        Blocking,
        Wandering,
    }

    [SerializeField]
    private NavMeshAgent enemyAgent;

    [SerializeField]
    private NavMeshAgent playerAgent;

    #region blocking fields
    [SerializeField]
    private Transform blockingTarget;
    #endregion

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
        enemyAgent.destination = enemyAgent.transform.position;
        
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
                    lastCoroutine = StartCoroutine(WanderingState(enemyAgent.transform.position));
                    break;
            }

            state = newState;

            yield return null;
        }
    }

    private IEnumerator BlockingState()
    {
        yield return null;
    }

    private IEnumerator WanderingState(Vector3 aroundPosition)
    {
        enemyAgent.destination = aroundPosition;

        float lastTime = Time.time;

        while (true)
        {
            // One it reaches the previous destination, search for another randome place wehre to go
            if (Mathf.Abs(lastTime - Time.time) > wanderingDirectionChangePeriod)
            {
                lastTime = Time.time;

                var delta = Random.rotation * Vector3.right * wanderingDistance;

                enemyAgent.speed = wanderingSpeed;
                enemyAgent.destination = aroundPosition + delta;
            }

            yield return null;
        }
    }

    private void BlockState()
    {
        var playerData = playerAgent.currentOffMeshLinkData;
        var enemyData = enemyAgent.currentOffMeshLinkData;

        var distance = Vector3.SqrMagnitude(playerEndPos - playerAgent.transform.position);
        var isFarFromWhereIAmGoing = distance > 10;

        enemyAgent.destination = playerAgent.destination;

        /*
        // Move
        enemyAgent.transform.position = Vector3.MoveTowards(
            enemyAgent.transform.position, 
            enemyEndPos, 
            enemyAgent.speed * Time.deltaTime);
        */
    }
}
