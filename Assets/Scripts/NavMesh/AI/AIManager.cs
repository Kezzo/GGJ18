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
    private List<MapItem> targetedLights = new List<MapItem>();
    private Dictionary<AIAgent, MapItem> targetedLightsByUnit = new Dictionary<AIAgent, MapItem>();

    public void AddEnemy(AIAgent instance)
    {
        enemies.Add(instance);
        instance.Init(this);
    }

    public MapItem AssignMeALight(AIAgent agent)
    {
        // Return previously targeted gate
        MapItem oldGate = null;
        if (targetedLightsByUnit.TryGetValue(agent, out oldGate))
        {
            targetedLights.Remove(oldGate);
            targetedLightsByUnit.Remove(agent);
        }

        // Search for a free gate
        var freeGates =
            from gate in mapManager.Lights.Randomize()
            where !targetedLights.Contains(gate)
            select gate;

        // Assign the gate
        var selectedGate = freeGates.FirstOrDefault();
        if (selectedGate != null)
        {
            targetedLights.Add(selectedGate);
            targetedLightsByUnit[agent] = selectedGate;
        }

        return selectedGate;
    }

    public void ReturnALight(AIAgent agent)
    {
        MapItem oldGate = null;
        if (targetedLightsByUnit.TryGetValue(agent, out oldGate))
        {
            targetedLights.Remove(oldGate);
            targetedLightsByUnit.Remove(agent);
        }
    }

    [ContextMenu("Print debug info")]
    private void PrintDebugInfo()
    {
        Debug.Log("AIManager");
        Debug.Log("---------");
        foreach (var entry in targetedLightsByUnit)
        {
            Debug.Log(entry.Key + " " + entry.Value);
        }
    }
}
