
using UnityEngine;
using UnityEngine.AI;

[DefaultExecutionOrder(-1)]
public sealed class PlayerAgent : MonoBehaviour 
{
    [SerializeField]
    public NavMeshAgent agent;

    public static PlayerAgent instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
