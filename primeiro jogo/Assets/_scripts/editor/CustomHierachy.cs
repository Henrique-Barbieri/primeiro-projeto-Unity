using UnityEngine;
using UnityEditor;
using System;

[InitializeOnLoad]
public class CustomHierachy
{
    static CustomHierachy() {
        EditorApplication.hierarchyWindowItemOnGUI += RenderOjects;
    }

    private static void RenderOjects(int instanceID, Rect selectionRect)
    {
        GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if(gameObject == null) return;

        if(gameObject.TryGetComponent<CustomHeaderObject>(out var customHeaderObject)){
        EditorGUI.DrawRect(selectionRect, customHeaderObject.backgroundColor);
        EditorGUI.LabelField(selectionRect, gameObject.name.ToUpper(), new GUIStyle(){
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold,
            normal = new GUIStyleState(){ textColor = customHeaderObject.textColor}
            });
        }
    }
}
