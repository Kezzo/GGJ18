using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    #region in scene fields
    [SerializeField]
    private MapManager mapManager;
    [SerializeField]
    private float enemyToGateInterval;
    #endregion

    private List<AIAgent> enemies = new List<AIAgent>();
    private List<Gate> targetedGates = new List<Gate>();
    private Dictionary<AIAgent, Gate> targetedGatesByUnit = new Dictionary<AIAgent, Gate>();

    public void AddEnemy(AIAgent instance)
    {
        enemies.Add(instance);
        instance.Init(this);
    }

    public Gate AssignMeAGate(AIAgent agent)
    {
        // Return previously targeted gate
        Gate oldGate = null;
        if (targetedGatesByUnit.TryGetValue(agent, out oldGate))
        {
            targetedGates.Remove(oldGate);
            targetedGatesByUnit.Remove(agent);
        }

        // Search for a free gate
        var freeGates =
            from gate in mapManager.Gates.Randomize()
            where !targetedGates.Contains(gate)
            select gate;

        // Assign the gate
        var selectedGate = freeGates.FirstOrDefault();
        if (selectedGate != null)
        {
            targetedGates.Add(selectedGate);
            targetedGatesByUnit[agent] = selectedGate;
            agent.AssignedLight(selectedGate);
        }

        return selectedGate;
    }

    public void ReturnAGate(AIAgent agent)
    {
        Gate oldGate = null;
        if (targetedGatesByUnit.TryGetValue(agent, out oldGate))
        {
            targetedGates.Remove(oldGate);
            targetedGatesByUnit.Remove(agent);
        }
    }

    [ContextMenu("Print debug info")]
    private void PrintDebugInfo()
    {
        Debug.Log("AIManager");
        Debug.Log("---------");
        foreach (var entry in targetedGatesByUnit)
        {
            Debug.Log(entry.Key + " " + entry.Value);
        }
    }
}
