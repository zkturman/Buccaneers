#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OpponentConfirmAction))]
public class OpponentConfirmEditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        OpponentConfirmAction confirmSimulator = (OpponentConfirmAction)target;
        if (GUILayout.Button("Confirm Beastie"))
        {
            confirmSimulator.ConfirmOpponent();
        }
    }
}
#endif
