using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private TileManagerBase tileManager;

    public IEnumerable<Gate> Gates
    {
        get
        {
            return tileManager.Gates;
        }
    }

    public IEnumerable<MapTile> Tiles
    {
        get
        {
            return tileManager.Tiles;
        }
    }
}
