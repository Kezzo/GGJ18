using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileManagerBase : MonoBehaviour 
{
    public abstract IEnumerable<MapTile> Tiles
    {
        get;
    }

    public virtual IEnumerable<Gate> Gates
    {
        get
        {
            return
                from tile in Tiles
                from gate in tile.Gates
                where gate != null
                select gate;
        }
    }
}
