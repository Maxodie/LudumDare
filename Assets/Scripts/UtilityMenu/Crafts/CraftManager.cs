using UnityEngine;
using System.Collections.Generic;

public class CraftManager : MonoBehaviour {
    [SerializeField] CraftDataBase craftDataBase;
    [SerializeField] ShopManager shopManager;
    [SerializeField] InventoryManager inventoryManager;

    [SerializeField] Transform craftUISpanwnPoint;
    [SerializeField] GameObject craftUIPrefab;
    List<CraftItemUI> craftItemUI = new List<CraftItemUI>();

    void Awake() {
        LoadCrafts();
    }

    void LoadCrafts() {
        for(int i=0; i<craftDataBase.crafts.Length; i++) {
            if(craftDataBase.crafts[i].isSpawnAtStart)
                InstantiateCraftUIItem(craftDataBase.crafts[i]);
        }
    }

    void InstantiateCraftUIItem(CraftScriptableObject craftData, int siblingId = 0) {
        CraftItemUI craftItem_ = Instantiate(craftUIPrefab, craftUISpanwnPoint).GetComponent<CraftItemUI>();
        craftUISpanwnPoint.GetChild(craftUISpanwnPoint.childCount-1).SetSiblingIndex(siblingId);

        craftItem_.LoadCraftUI(craftData, this);

        craftItemUI.Add(craftItem_);
    }

    public string GetPriceText(CraftScriptableObject craft) {
        string result = "";

        for(int i=0; i<craft.craftRequiredItems.Length; i++) {
            result += craft.craftRequiredItems[i].requiredNumber + " <sprite=" + craft.craftRequiredItems[i].requiredOre.emoteId + ">\n";
        }

        return result;
    }

    public string GetItemDescription(CraftScriptableObject craft) {
        return shopManager.GetItemDescription(craft.itemGived);
    }

    public bool OnCraft(CraftScriptableObject craftedItem, CraftItemUI craftedItemUI) {

        if(!craftedItem.isCraftGiveEquipedItem && !inventoryManager.IsStillEmptySlot()) {
                return false;
        }

        //Check if there is enough ore for each ore that the craft need
        for(int i=0; i<craftedItem.craftRequiredItems.Length; i++) {
            if(!inventoryManager.IsItemInInventory(craftedItem.craftRequiredItems[i].requiredOre, craftedItem.craftRequiredItems[i].requiredNumber))
                return false;
        }

        //Remove the ore that the craft need
        for(int i=0; i<craftedItem.craftRequiredItems.Length; i++) {
            inventoryManager.RemoveItemFromInventory(craftedItem.craftRequiredItems[i].requiredOre, craftedItem.craftRequiredItems[i].requiredNumber);
        }

        if(craftedItem.isCraftGiveEquipedItem) {
            //Add the item
            shopManager.ActiveItemBonus(craftedItem.itemGived);

            //link with the skin
            PlayerSkinManager.instance.ChangePlayerSkin(craftedItem.equipementType, craftedItem.craftVisual);
        }
        else {
            inventoryManager.AddItemInInventory(craftedItem.oreGived, craftedItem.oreGivedNumber);
        }

        //add the next item to craft
        if(craftedItem.nextcraft)
            InstantiateCraftUIItem(craftedItem.nextcraft, craftedItemUI.transform.GetSiblingIndex());

        craftItemUI.Remove(craftedItemUI);
        Destroy(craftedItemUI.gameObject);

        return true;
    }
}
