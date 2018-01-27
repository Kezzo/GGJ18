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

    private IEnumerator Start()
    {
        yield return null;

        while (true)
        {

            yield return new WaitForSeconds(enemyToGateInterval);
        }
    }

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
        var freeGate =
            from gate in mapManager.Gates
            where !targetedGates.Contains(gate)
            select gate;

        // Assign the gate
        var selectedGate = freeGate.FirstOrDefault();
        if (selectedGate != null)
        {
            targetedGates.Add(selectedGate);
            targetedGatesByUnit[agent] = selectedGate;
        }

        return selectedGate;
    }

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
