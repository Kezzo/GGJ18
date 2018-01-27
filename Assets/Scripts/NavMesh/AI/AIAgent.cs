using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class AIAgent : MonoBehaviour
{
    #region in scene fields

    [SerializeField]
    protected NavMeshAgent agent;
    protected AIManager aIManager;

    #endregion

    public virtual void Init(AIManager aIManager)
    {
        this.aIManager = aIManager;
    }
}
