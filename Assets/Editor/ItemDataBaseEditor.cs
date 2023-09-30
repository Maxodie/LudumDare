using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR

[CustomEditor(typeof(ShopItemDataBase), true)]
public class ItemDataBaseEditor : Editor {

    ShopItemDataBase shopItemDataBase;

    SerializedProperty shopItem;

    void OnEnable() {
        shopItem = serializedObject.FindProperty("shopItems");
    }

    //On the inspector window
    public override void OnInspectorGUI() {
        serializedObject.Update();

        shopItemDataBase = (ShopItemDataBase)target;

        //Button that add items in the "path" folder
        if(GUILayout.Button("Add items")) {
            shopItemDataBase.shopItems = Resources.LoadAll<ShopItemScriptableObject>("ShopItems/");
        }

        EditorGUILayout.PropertyField(shopItem, true);

        serializedObject.ApplyModifiedProperties();

    }
}

#endif