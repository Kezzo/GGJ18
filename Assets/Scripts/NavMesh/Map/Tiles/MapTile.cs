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

    [SerializeField]
    public bool link0;

    [SerializeField]
    public bool link1;

    [SerializeField]
    public bool link2;

    private void Awake()
    {
        lights.AddRange(
            from light in GetComponentsInChildren<LightUpBlock>()
            let lightBhv = light.GetOrAddComponent<MapLight>()
            select lightBhv);

        // Make sure that we have a single instance in the list
        lights = lights.Distinct().ToList();
    }

    public IEnumerable<MapGate> Gates
    {
        get
        {
            return gates;
        }
    }

    // Let's consider the gates as lights as well (too late to refactor ir further)
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
