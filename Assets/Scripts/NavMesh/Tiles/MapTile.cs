using UnityEngine;

[DefaultExecutionOrder(-100)]
public class MapTile : MonoBehaviour 
{
    [SerializeField]
    private Transform[] gates;

    [SerializeField]
    private LightUpBlock lightItem;

    private void Awake()
    {
        // For now disable the script to prevent it from crashing
        if (lightItem != null)
        {
            lightItem.enabled = false;
        }
    }
}
