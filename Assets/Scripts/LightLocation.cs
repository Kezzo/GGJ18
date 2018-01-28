using UnityEngine;

public class LightLocation : MonoBehaviour {

    private void Start()
    {
        if (LightCubeLocationOrchestrator.Instance != null)
        {
            LightCubeLocationOrchestrator.Instance.LightCubeLocations.Add(this.transform);
        }
    }
}
