using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR

[CustomEditor(typeof(CraftDataBase), true)]
public class CraftDataBaseEditor : Editor {

    CraftDataBase craftDataBase;

    SerializedProperty crafts;

    void OnEnable() {
        crafts = serializedObject.FindProperty("crafts");
    }

    //On the inspector window
    public override void OnInspectorGUI() {
        serializedObject.Update();

        craftDataBase = (CraftDataBase)target;

        //Button that add items in the "path" folder
        if(GUILayout.Button("Add items")) {
            craftDataBase.crafts = Resources.LoadAll<CraftScriptableObject>("Crafts/");
        }

        EditorGUILayout.PropertyField(crafts, true);

        serializedObject.ApplyModifiedProperties();

    }
}

#endif