using UnityEngine;

using PathFinding;
using System.Linq;
using System.Collections.Generic;

[DefaultExecutionOrder(-200)]
public class TileManagerSpawner : TileManagerBase
{
    #region fields in the scene

    [SerializeField]
    public int numTilesX = 10;

    [SerializeField]
    public int numTilesY = 10;

    [SerializeField]
    public float tileSizeX = 4.0f;

    [SerializeField]
    public float tileSizeY = 4.0f;

    [SerializeField]
    public Transform tileContainer;

    [SerializeField]
    public MapTileList tiles;

    #endregion

    private Dictionary<Point, MapTile> tileInstances = new Dictionary<Point, MapTile>();

    public override IEnumerable<MapTile> Tiles
    {
        get
        {
            return tileInstances.Values;
        }
    }

    void Awake()
    {
        Random.InitState(23431);

        var map = RandomizedTileIndexes(numTilesX, numTilesY);

        // Instantiate the tiles
        for (int y = 0; y < numTilesX; y++)
        {
            for (int x = 0; x < numTilesY; x++)
            {
                var pos = new Vector3(x * tileSizeX, 0, y * tileSizeY);
                var mapType = map[x + y * numTilesX];
                var tile = tiles.GetTile(mapType);
                if (tile != null)
                {
                    var point = new Point(x, y);
                    var instance = Instantiate(tile, pos, Quaternion.identity, tileContainer);
                    instance.gameObject.SetActive(true);
                    tileInstances[point] = instance;
                }
            }
        }
    }

    private static int[] RandomizedTileIndexes(int width, int height)
    {
        var map = new int[width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                bool px = false;
                bool py = false;

                if (x > 0)
                    px = (map[(x - 1) + y * width] & 1) != 0;

                if (y > 0)
                    py = (map[x + (y - 1) * width] & 2) != 0;

                int tile = 0;

                if (px) tile |= 4;
                if (py) tile |= 8;
                if (x + 1 < width && Random.value > 0.5f) tile |= 1;
                if (y + 1 < height && Random.value > 0.5f) tile |= 2;

                map[x + y * width] = tile;
            }
        }

        return map;
    }
}
