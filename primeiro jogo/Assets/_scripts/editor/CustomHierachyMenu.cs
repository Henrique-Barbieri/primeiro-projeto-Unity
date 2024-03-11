using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomHierachyMenu : EditorWindow
{
    [MenuItem("GameObject/create Custom Header")]
    static void CrateCustomHeader(MenuCommand menuCommand) {
        GameObject obj = new GameObject("Header");
        Undo.RegisterCreatedObjectUndo(obj, "Crate Custom Header");
        GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);
        obj.AddComponent<CustomHeaderObject>();
        Selection.activeObject = obj;
    }
}
