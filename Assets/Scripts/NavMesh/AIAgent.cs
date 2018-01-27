
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIAgent : MonoBehaviour
{
    #region in scene fields

    [SerializeField]
    private NavMeshAgent agent;

    #endregion

    public void GoTo(GameObject current)
    {
        var nextPosition = current.transform.position;

        // Keep the same height
        nextPosition.y = transform.position.y;

        agent.destination = nextPosition;
    }
}
