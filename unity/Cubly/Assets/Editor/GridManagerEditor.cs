using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GridManager))]
public class GridManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridManager myScript = (GridManager)target;
        if (GUILayout.Button("Generate Tiles"))
        {
            myScript.GenerateTiles();
        }
    }

}