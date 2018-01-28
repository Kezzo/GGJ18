using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapManager : MonoBehaviour
{
    public abstract IEnumerable<MapTile> Tiles
    {
        get;
    }

    public virtual IEnumerable<MapGate> Gates
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

    // Since we are not using anymore the gates use the 
    public virtual IEnumerable<MapItem> Lights
    {
        get
        {
            return
                from tile in Tiles
                from light in tile.Lights
                where light != null
                select light;
        }
    }
}
