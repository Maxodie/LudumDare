using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Epitaph/InventoryItem", order = 0)]
public class InventoryItemScriptableObject : ScriptableObject {
    public Sprite icon;

    public string itemName;
    public string defaultDescription;
    public int emoteId;

    public int price;
}
