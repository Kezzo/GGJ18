using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileList : MonoBehaviour 
{
    #region fields in the scene

    [SerializeField]
    private MapTile[] tiles;

    #endregion

    private void Awake()
    {
        // Make sure the tiles are disabled in the scene
        foreach (var tile in tiles)
        {
            tile.gameObject.SetActive(false);
        }
    }

    public MapTile GetTile(int index)
    {
        //index = Math.Abs(index) % tiles.Length;
        return tiles[index];
    }
}
