using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CustomBendGUI : ShaderGUI
{
    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {
        // base.OnGUI(materialEditor, properties);

        MaterialProperty fromColorProperty = FindProperty("_FromColor", properties);
        MaterialProperty toColorProperty = FindProperty("_ToColor", properties);
        MaterialProperty spinProperty = FindProperty("_Spin", properties);
        MaterialProperty smoothnessProperty = FindProperty("_Smoothness", properties);
        MaterialProperty metaliicProperty = FindProperty("_Metaliic", properties);

        GUILayout.Label("Visual", EditorStyles.boldLabel);
        materialEditor.ColorProperty(fromColorProperty, fromColorProperty.displayName);
        materialEditor.ColorProperty(toColorProperty, toColorProperty.displayName);
        materialEditor.ShaderProperty(smoothnessProperty, smoothnessProperty.displayName);
        materialEditor.ShaderProperty(metaliicProperty, metaliicProperty.displayName);

        GUILayout.Label("Bend", EditorStyles.boldLabel);
        DrawFloatProperty(materialEditor, spinProperty);

    }

    static void DrawFloatProperty(MaterialEditor materialEditor, MaterialProperty materialProperty)
    {
        materialEditor.FloatProperty(materialProperty, materialProperty.displayName);
    }
}