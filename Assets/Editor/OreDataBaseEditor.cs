using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR

[CustomEditor(typeof(OreDataBase), true)]
public class OreDataBaseEditor : Editor {

    OreDataBase oreDataBase;

    SerializedProperty ores;

    void OnEnable() {
        ores = serializedObject.FindProperty("oreList");
    }

    //On the inspector window
    public override void OnInspectorGUI() {
        serializedObject.Update();

        oreDataBase = (OreDataBase)target;

        //Button that add items in the "path" folder
        if(GUILayout.Button("Add items")) {
            oreDataBase.oreList = Resources.LoadAll<Ore>("Ores_data/");
        }

        EditorGUILayout.PropertyField(ores, true);

        serializedObject.ApplyModifiedProperties();

    }
}

#endif