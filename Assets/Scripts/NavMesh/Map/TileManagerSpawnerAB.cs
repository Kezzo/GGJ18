using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System.Collections.Generic;

[DefaultExecutionOrder(-200)]
public class TileManagerSpawnerAB : MapManager
{
    #region fields in the scene
    [SerializeField]
    private MapTile[] ATiles;
    [SerializeField]
    private MapTile[] BTiles;
    [SerializeField]
    private Transform ATileContainer;
    [SerializeField]
    private Transform BTileContainer;
    [SerializeField]
    private float tileSizeX = 4.0f;
    [SerializeField]
    private float tileSizeY = 4.0f;
    [SerializeField]
    private NavMeshLink[] navMeshLinkA;
    [SerializeField]
    private NavMeshLink[] navMeshLinkB;
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

        instanceA.gameObject.SetActive(true);
        instanceB.gameObject.SetActive(true);

        var link0 = instanceA.link0 && instanceB.link0;
        var link1 = instanceA.link1 && instanceB.link1;
        var link2 = instanceA.link2 && instanceB.link2;

        navMeshLinkA[0].gameObject.SetActive(link0);
        navMeshLinkB[0].gameObject.SetActive(link0);
        navMeshLinkA[1].gameObject.SetActive(link1);
        navMeshLinkB[1].gameObject.SetActive(link1);
        navMeshLinkA[2].gameObject.SetActive(link2);
        navMeshLinkB[2].gameObject.SetActive(link2);
    }
}
