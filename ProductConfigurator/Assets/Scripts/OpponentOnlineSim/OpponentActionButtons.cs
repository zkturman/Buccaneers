#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OpponentTurnAction))]
public class OpponentActionButtons : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        OpponentTurnAction actionSimulator = (OpponentTurnAction)target;
        if (GUILayout.Button("Move Beastie"))
        {
            actionSimulator.MoveBeastie();
        }
    }
}
#endif
