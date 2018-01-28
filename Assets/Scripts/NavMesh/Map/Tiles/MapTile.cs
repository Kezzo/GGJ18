using UnityEngine;
using System.Linq;
using System.Collections.Generic;

[DefaultExecutionOrder(-100)]
public sealed class MapTile : MonoBehaviour 
{
    [SerializeField]
    private MapGate[] gates;

    [SerializeField]
    private List<MapLight> lights;

    // TODO: Make this class a little bit prettier
    private void Awake()
    {
        foreach (var light in GetComponentsInChildren<LightUpBlock>())
        {
            var lightBhv = light.GetComponent<MapLight>();
            if (lightBhv == null)
            {
                lightBhv = light.gameObject.AddComponent<MapLight>();
            }

            lights.Add(lightBhv);
        }
    }

    public IEnumerable<MapGate> Gates
    {
        get
        {
            return gates;
        }
    }

    public IEnumerable<MapItem> Lights
    {
        get
        {
            foreach (var gate in gates)
            {
                yield return gate;
            }

            foreach (var light in lights)
            {
                yield return light;
            }
        }
    }
}
