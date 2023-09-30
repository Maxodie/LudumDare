using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemDataBase", menuName = "Epitaph/ShopItemDataBase", order = 0)]
public class ShopItemDataBase : ScriptableObject {
    public ShopItemScriptableObject[] shopItems;
}
