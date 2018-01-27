using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class MapTile : MonoBehaviour 
{
    [SerializeField]
    private Gate[] gates;

    [SerializeField]
    private Transform lightItem;

    public IEnumerable<Gate> Gates
    {
        get
        {
            return gates;
        }
    }
}
