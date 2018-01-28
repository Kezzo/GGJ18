using System;
using System.Collections;
using UnityEngine;

public class AIFullAgent : AIAgent
{
    public enum State
    {
        Idle,
        Blocker,
        Wandering,
        SearchingNewLight,
    }

    #region blocking parameters
    [SerializeField]
    private float distanceThreadshold = 10;
    [SerializeField]
    private float blockingDistance = 4;
    #endregion

    #region wandering parameters
    [SerializeField]
    private float wanderingSpeed = 4;
    [SerializeField]
    private float wanderingDistance = 1;
    [SerializeField]
    private float wanderingDirectionChangePeriod = 1;
    [SerializeField]
    private float wanderingTime = 4;
    #endregion

    #region private fields
    private State state = State.Idle;
    private Coroutine lastCoroutine;
    private float lastStateChange;
    #endregion

    IEnumerator Start()
    {
        // Initialize states of the state machine
        var blockerState = new AIStates.BlockState(
            distanceThreadshold,
            null,
            agent);
        
        var wanderingState = new AIStates.WanderingState(
            agent.transform.position,
            wanderingDirectionChangePeriod,
            wanderingDistance,
            wanderingSpeed,
            agent);

        var nextLightState = new AIStates.NextLightState(
            this,
            agent,
            aIManager
        );

        yield return null;

        // Initial positions
        agent.destination = agent.transform.position;

        while (true)
        {
            var newState = state;
            try
            {
                var lastLight = nextLightState.light;

                // Evaluate conditions to change the behaviour
                {
                    // If the enemy is close to the previous light and to the player then jump into blocker mode
                    if (lastLight != null && 
                        PlayerAgent.instance.transform.position.NearlyEqual(lastLight.transform.position, blockingDistance) &&
                        PlayerAgent.instance.transform.position.NearlyEqual(transform.position, blockingDistance))
                    {
                        newState = State.Blocker;
                    }
                    else
                    {
                        switch (state)
                        {
                            case State.Idle:
                                {
                                    newState = State.Wandering;
                                }
                                break;

                            case State.Wandering:
                                {
                                    if (Time.time - lastStateChange > wanderingTime)
                                    {
                                        newState = State.SearchingNewLight;
                                    }
                                }
                                break;

                            case State.Blocker:
                                {
                                    if (!PlayerAgent.instance.transform.position.NearlyEqual(agent.transform.position, blockingDistance))
                                    {
                                        newState = State.Wandering;
                                    }
                                }
                                break;

                            case State.SearchingNewLight:
                                {

                                }
                                break;
                        }
                    }
                }

                if (newState != state)
                {
                    // Exit the previous state
                    if (lastCoroutine != null)
                    {
                        Debug.Log("Stopping previous state " + state);

                        StopCoroutine(lastCoroutine);

                        switch (state)
                        {
                            case State.Wandering:
                                wanderingState.Exit();
                                break;

                            case State.Blocker:
                                blockerState.Exit();
                                break;

                            case State.SearchingNewLight:
                                nextLightState.Exit();
                                break;
                        }
                    }

                    Debug.Log("Starting new state state " + newState);

                    // Enter the new state
                    switch (newState)
                    {
                        case State.Wandering:
                            {
                                wanderingState.aroundPosition = agent.transform.position;
                                lastCoroutine = StartCoroutine(wanderingState.Enter());
                            }
                            break;

                        case State.Blocker:
                            {
                                blockerState.target = lastLight.transform;
                                lastCoroutine = StartCoroutine(blockerState.Enter());
                            }
                            break;

                        case State.SearchingNewLight:
                            {
                                lastCoroutine = StartCoroutine(nextLightState.Enter());
                            }
                            break;
                    }
                    state = newState;
                    lastStateChange = Time.time;
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                newState = State.Idle;
            }

            yield return null;
        }
    }
}
