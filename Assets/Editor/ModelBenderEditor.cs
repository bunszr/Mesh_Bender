using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Bender), true)]
public class BenderEditor : Editor
{
    Bender bender;

    private void OnEnable()
    {
        bender = (Bender)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    private void OnSceneGUI()
    {
        if (Application.isPlaying)
            return;

        if (Event.current.type == EventType.Layout)
        {
            bender.SendToShader();
        }
    }
}