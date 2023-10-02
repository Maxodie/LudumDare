using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour {
    [SerializeField] ShopItemDataBase shopItemDataBase;
    [SerializeField] InventoryManager inventoryManager;

    [SerializeField] GameObject shopItemUIPrefab;
    [SerializeField] Transform spawnItemPos;

    List<ShopItemUI> shopItemUI = new List<ShopItemUI>();

    void Start() {
        LoadShopItems();
    }

    void LoadShopItems() {
        for(int i=0; i<shopItemDataBase.shopItems.Length; i++) {
            if(shopItemDataBase.shopItems[i].isSpawnAtStart)
                InstantiateUIItem(shopItemDataBase.shopItems[i]);
        }
    }

    void InstantiateUIItem(ShopItemScriptableObject shopItem, int siblingId = 0) {
        ShopItemUI shopItem_ = Instantiate(shopItemUIPrefab, spawnItemPos).GetComponent<ShopItemUI>();
        spawnItemPos.GetChild(spawnItemPos.childCount-1).SetSiblingIndex(siblingId);

        shopItem_.LoadShopUI(shopItem, this);

        shopItemUI.Add(shopItem_);
    }

    public string GetItemDescription(ShopItemScriptableObject shopItem) {
        string result = "";

        //Additional Boosts
        if(shopItem.miningMaxTimeUpgradeboostAdd != 0)
            result += "Space Bar Time <b><color=#4DEA52>" + shopItem.miningMaxTimeUpgradeboostAdd.ToString("0") + "s</color></b><sprite=6>\n";

        if(shopItem.miningRateUpgradeboostAdd != 0)
            result += "Mining Rate <b><color=#4DEA52>" + shopItem.miningRateUpgradeboostAdd.ToString("+#;-#;0") + "</color></b><sprite=5>\n";

        if(shopItem.miningpowerBoostAdd != 0)
            result += "Mining Power <b><color=#4DEA52>" + shopItem.miningpowerBoostAdd.ToString("+#;-#;0") + "</color></b><sprite=8>\n";

        if(shopItem.miningOreReceivedBoostAdd != 0)
            result += "Mining Power <b><color=#4DEA52>" + (shopItem.miningOreReceivedBoostAdd*100).ToString("+#;-#;0") + "</color></b><sprite=9>\n";
        
        if(shopItem.walkSpeedBoostAdd != 0)
            result += "Walk Speed <b><color=#4DEA52>" + (shopItem.walkSpeedBoostAdd*100).ToString("+#;-#;0") + "</color></b><sprite=4>\n";

        //Percentage Boosts
        if(shopItem.miningMaxTimeUpgradePercentAdd != 0)
            result += "Space Bar Time <b><color=#4DEA52>" + shopItem.miningMaxTimeUpgradePercentAdd*100 + "%</color></b><sprite=6>\n";

        if(shopItem.miningRateUpgradePercentAdd != 0)
            result += "Mining Rate <b><color=#4DEA52>" + (shopItem.miningRateUpgradePercentAdd*100).ToString("+#;-#;0") + "%</color></b><sprite=5>\n";

        if(shopItem.miningpowerPercentAdd != 0)
            result += "Mining Power <b><color=#4DEA52>" + (shopItem.miningpowerPercentAdd*100).ToString("+#;-#;0") + "%</color></b><sprite=8>\n";

        if(shopItem.miningOreReceivedPercentAdd != 0)
            result += "Minerals Per Drop <b><color=#4DEA52>" + (shopItem.miningOreReceivedPercentAdd*100).ToString("+#;-#;0") + "%</color></b><sprite=9>\n";
        
        if(shopItem.walkSpeedPercentAdd != 0)
            result += "Walk Speed <b><color=#4DEA52>" + (shopItem.walkSpeedPercentAdd*100).ToString("+#;-#;0") + "%</color></b><sprite=4>\n";

        return result;
    }

    public void BuyItem(ShopItemScriptableObject shopItem, ShopItemUI shopItemUI) {

        if(shopItem.isBoost)
            ActiveItemBonus(shopItem);
        else {
            inventoryManager.AddItemInInventory(shopItem.itemGived, shopItem.itemGivedNumber);
        }

        if(shopItem.nextUpgrade)
            InstantiateUIItem(shopItem.nextUpgrade, shopItemUI.transform.GetSiblingIndex());

        this.shopItemUI.Remove(shopItemUI);
        Destroy(shopItemUI.gameObject);
    }

    public void ActiveItemBonus(ShopItemScriptableObject shopItem) {
        PlayerStats player = PlayerStats.instance;

        //Additional Boosts
        if(shopItem.miningMaxTimeUpgradeboostAdd != 0)
            player.miningMaxTime.AddModifier(new Modifier(shopItem.miningMaxTimeUpgradeboostAdd, ModifierType.ADDITION));

        if(shopItem.miningRateUpgradeboostAdd != 0)
            player.miningRate.AddModifier(new Modifier(shopItem.miningRateUpgradeboostAdd, ModifierType.ADDITION));

        if(shopItem.miningpowerBoostAdd != 0)
            player.miningpower.AddModifier(new Modifier(shopItem.miningpowerBoostAdd, ModifierType.ADDITION));

        if(shopItem.miningOreReceivedBoostAdd != 0)
            player.miningOreReceived.AddModifier(new Modifier(shopItem.miningOreReceivedBoostAdd, ModifierType.ADDITION));

        if(shopItem.walkSpeedBoostAdd != 0)
            player.walkSpeed.AddModifier(new Modifier(shopItem.walkSpeedBoostAdd, ModifierType.ADDITION));

        //Percentage Boosts
        if(shopItem.miningMaxTimeUpgradePercentAdd != 0)
            player.miningMaxTime.AddModifier(new Modifier(shopItem.miningMaxTimeUpgradePercentAdd, ModifierType.ADD_PERCENTAGE));

        if(shopItem.miningRateUpgradePercentAdd != 0)
            player.miningRate.AddModifier(new Modifier(shopItem.miningRateUpgradePercentAdd, ModifierType.ADD_PERCENTAGE));

        if(shopItem.miningpowerPercentAdd != 0)
            player.miningpower.AddModifier(new Modifier(shopItem.miningpowerPercentAdd, ModifierType.ADD_PERCENTAGE));

        if(shopItem.miningOreReceivedPercentAdd != 0)
            player.miningOreReceived.AddModifier(new Modifier(shopItem.miningOreReceivedPercentAdd, ModifierType.ADD_PERCENTAGE));

        if(shopItem.walkSpeedPercentAdd != 0)
            player.walkSpeed.AddModifier(new Modifier(shopItem.walkSpeedPercentAdd, ModifierType.ADD_PERCENTAGE));
    }
}
