#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BlockLightUp))]
public class BlockLightUpEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Activate!"))
        {
            BlockLightUp blockLightUp = (BlockLightUp)target;

            if (blockLightUp != null)
            {
                blockLightUp.Activate();
            }
        }
    }
}
#endif