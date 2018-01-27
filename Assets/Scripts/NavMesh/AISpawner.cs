using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AISpawner : MonoBehaviour
{
    #region in scene fields

    [SerializeField]
    private int numberOfEnemies;

    [SerializeField]
    private AIAgent enemyPrefab;

    [SerializeField]
    private AIManager aiManager;

    [SerializeField]
    private Transform enemyContainer;

    #endregion

    private void Awake()
    {
        
        for (int i = 0; i < numberOfEnemies; i++)
        {
            var instance = Instantiate(enemyPrefab, enemyContainer);

            aiManager.AddEnemy(instance);
        }
    }
}
