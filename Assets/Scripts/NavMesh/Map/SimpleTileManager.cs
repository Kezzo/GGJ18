using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTileManager : TileManagerBase
{
    [SerializeField]
    private MapTile[] tiles;

    public override IEnumerable<MapTile> Tiles
    {
        get
        {
            return tiles;
        }
    }
}
