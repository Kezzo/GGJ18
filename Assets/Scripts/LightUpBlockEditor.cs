#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LightUpBlock))]
public class LightUpBlockEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Activate!"))
        {
            LightUpBlock lightUpBlock = (LightUpBlock)target;

            if (lightUpBlock != null)
            {
                lightUpBlock.Activate();
            }
        }
    }
}
#endif