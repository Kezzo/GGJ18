using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class MapTile : MonoBehaviour 
{
    [SerializeField]
    private Gate[] gates;

    [SerializeField]
    private Transform[] lights;

    public IEnumerable<Gate> Gates
    {
        get
        {
            return gates;
        }
    }

    public IEnumerable<Transform> Lights
    {
        get
        {
            return lights;
        }
    }
}
