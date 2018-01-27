using System.Collections.Generic;
using UnityEngine;

public class LightCubeLocationOrchestrator : MonoBehaviour
{
    [SerializeField]
    private List<Transform> m_lightCubeLocations;

    public static LightCubeLocationOrchestrator Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetToRandomVacantLocation(LightUpBlock lightUpBlock)
    {
        ListHelper.ShuffleList(ref m_lightCubeLocations);

        foreach (Transform lightCubeLocation in m_lightCubeLocations)
        {
            if (lightCubeLocation.childCount == 0)
            {
                lightUpBlock.transform.SetParent(lightCubeLocation);
                lightUpBlock.transform.localPosition = new Vector3(0f, 2f, 0f);
                break;
            }
        }
    }
}
