using UnityEngine;

using PathFinding;
using System.Collections.Generic;

[DefaultExecutionOrder(-200)]
public class MapManager : MonoBehaviour
{
    #region fields in the scene

    [SerializeField]
    public int width = 10;

    [SerializeField]
    public int height = 10;

    [SerializeField]
    public float spacing = 4.0f;

    [SerializeField]
    public Transform tileContainer;

    [SerializeField]
    public MapTileList tiles;

    #endregion

    private Dictionary<Point, MapTile> tileInstances = new Dictionary<Point, MapTile>();

    public IEnumerable<MapTile> GetTiles
    {
        get
        {
            return tileInstances.Values;
        }
    }

    void Awake()
    {
        Random.InitState(23431);

        var map = RandomizedTileIndexes(width, height);

        // Instantiate the tiles
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var pos = new Vector3(x * spacing, 0, y * spacing);
                var mapType = map[x + y * width];
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
