using UnityEngine;
using System.Linq;
using System.Collections.Generic;

[DefaultExecutionOrder(-200)]
public class TileManagerSpawnerAB : MapManager
{
    #region fields in the scene
    [SerializeField]
    private GameObject[] ATiles;
    [SerializeField]
    private GameObject[] BTiles;
    [SerializeField]
    private Transform ATileContainer;
    [SerializeField]
    private Transform BTileContainer;
    [SerializeField]
    public float tileSizeX = 4.0f;
    [SerializeField]
    public float tileSizeY = 4.0f;
    #endregion

    private List<MapTile> tiles = new List<MapTile>();

    public override IEnumerable<MapTile> Tiles
    {
        get
        {
            return tiles;
        }
    }

    void Awake()
    {
        var aTile = ATiles.Randomize().First();
        var bTile = BTiles.Randomize().First();

        var posA = new Vector3(0 * tileSizeX, 0, 0 * tileSizeY);
        var posB = new Vector3(1 * tileSizeX, 0, 0 * tileSizeY);

        var instanceA = Instantiate(aTile, posA, Quaternion.identity, ATileContainer);
        var instanceB = Instantiate(bTile, posB, Quaternion.identity, ATileContainer);

        tiles.AddRange(instanceA.GetComponentsInChildren<MapTile>());
        tiles.AddRange(instanceB.GetComponentsInChildren<MapTile>());

        // Disable the prefabs
        foreach (var tile in ATiles)
        {
            tile.gameObject.SetActive(false);
        }

        foreach (var tile in BTiles)
        {
            tile.gameObject.SetActive(false);
        }
    }
}
