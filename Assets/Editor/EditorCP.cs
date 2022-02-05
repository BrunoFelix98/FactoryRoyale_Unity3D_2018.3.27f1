using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(AiCheckPoints))]
public class EditorCP : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AiCheckPoints script = (AiCheckPoints)target;

        GUI.backgroundColor = Color.green;
        if(GUILayout.Button("Angle Waypoints") == true)
        {
            script.AnglesSizeCheckpointWalls();
        }
    }
}
