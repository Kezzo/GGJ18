using UnityEngine;

/// <summary>
/// Disable lights to prevent it crashing in the MapTile
/// </summary>
[DefaultExecutionOrder(-1000)]
public sealed class DisableLights : MonoBehaviour 
{
    private void Awake()
    {
        foreach (var lightBhv in GetComponentsInChildren<LightUpBlock>())
        {
            lightBhv.enabled = false;
        }
    }
}
