
using UnityEngine;

public sealed class AISpawner : MonoBehaviour
{
    public enum Behaviour { Random }

    #region in scene fields

    [SerializeField]
    private int numberOfEnemies;

    [SerializeField]
    private AIAgent enemyPrefab;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private AIManager aiManager;

    [SerializeField]
    private Transform enemyContainer;

    [SerializeField]
    private Behaviour behaviour;

    #endregion

    private void Awake()
    {
        var randomTiles = mapManager
            .GetTiles
            .Randomize()
            .GetEnumerator();

        for (int i = 0; i < numberOfEnemies; i++)
        {
            if (randomTiles.MoveNext())
            {
                var position = randomTiles.Current.transform.position;
                position.y = transform.position.y;

                var instance = Instantiate(enemyPrefab, position, Quaternion.identity, enemyContainer);
                instance.gameObject.SetActive(true);
                aiManager.AddEnemy(instance);
            }
        }

        // Disable the prefab so is not visible anymore
        enemyPrefab.gameObject.SetActive(true);
    }
}
