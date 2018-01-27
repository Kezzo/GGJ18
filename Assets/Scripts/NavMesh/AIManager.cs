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

    private IEnumerator Start()
    {
        yield return null;

        while (true)
        {
            AssignEnemiesToTile();

            yield return new WaitForSeconds(enemyToGateInterval);
        }
    }

    public void AddEnemy(AIAgent instance)
    {
        enemies.Add(instance);
    }

    private void AssignEnemiesToTile()
    {
        var tiles = mapManager
            .GetTiles
            .Randomize()
            .Take(enemies.Count)
            .GetEnumerator();

        foreach (var enemy in enemies)
        {
            if (tiles.MoveNext())
            {
                enemy.GoTo(tiles.Current.gameObject);
            }
        }
    }
}
