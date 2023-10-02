using UnityEngine;

[CreateAssetMenu(fileName = "CraftData", menuName = "Epitaph/CraftData", order = 0)]
public class CraftScriptableObject : ScriptableObject {

    public bool isSpawnAtStart = true;

    public bool isCraftGiveEquipedItem;
    public ShopItemScriptableObject itemGived;
    public InventoryItemScriptableObject oreGived;
    public int oreGivedNumber;

    public Sprite craftVisual;
    public EquipmentType equipementType;

    public CraftRequiredItem[] craftRequiredItems;

    public CraftScriptableObject nextcraft;
}

[System.Serializable]
public class CraftRequiredItem {
    public InventoryItemScriptableObject requiredOre;
    public int requiredNumber;
}

public enum EquipmentType {
    HELMET = 0,
    PICKAXE = 1,
    BEARD = 2,
    PANTS = 3,
    FACE = 4,
    ARM = 5,
    ITEM = 6,
}