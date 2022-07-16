using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreateNewPersonageController))]
public class ConnectRefParam : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        CreateNewPersonageController obj = (CreateNewPersonageController)target;
        if (GUILayout.Button("ConnectRefParam")) obj.CreateNewModel();
    }
}
