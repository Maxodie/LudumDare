using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour {
    [SerializeField] ShopItemDataBase shopItemDataBase;

    [SerializeField] GameObject shopItemUIPrefab;
    [SerializeField] Transform spawnItemPos;

    List<ShopItemUI> shopItemUI = new List<ShopItemUI>();

    void Start() {
        LoadShopItems();
    }

    void LoadShopItems() {
        for(int i=0; i<shopItemDataBase.shopItems.Length; i++) {
            InstantiateUIItem(shopItemDataBase.shopItems[i]);
        }
    }

    void InstantiateUIItem(ShopItemScriptableObject shopItem) {
        ShopItemUI shopItem_ = Instantiate(shopItemUIPrefab, spawnItemPos).GetComponent<ShopItemUI>();

        shopItem_.LoadShopUI(shopItem, this);

        shopItemUI.Add(shopItem_);
    }

    public string GetItemDescription(ShopItemScriptableObject shopItem) {
        string result = "";

        //Additional Boosts
        if(shopItem.miningMaxTimeUpgradeboostAdd != 0)
            result = "" + "<color=#4DEA52>" + shopItem.miningMaxTimeUpgradeboostAdd.ToString("+#;-#;0") + "</color>";

        if(shopItem.miningRateUpgradeboostAdd != 0)
            player.miningRate.AddModifier(new Modifier(shopItem.miningRateUpgradeboostAdd, ModifierType.ADDITION));

        if(shopItem.miningpowerBoostAdd != 0)
            player.miningpower.AddModifier(new Modifier(shopItem.miningpowerBoostAdd, ModifierType.ADDITION));

        //Percentage Boosts
        if(shopItem.miningMaxTimeUpgradePercentAdd != 0)
            player.miningMaxTime.AddModifier(new Modifier(shopItem.miningMaxTimeUpgradePercentAdd, ModifierType.ADD_PERCENTAGE));

        if(shopItem.miningRateUpgradePercentAdd != 0)
            player.miningRate.AddModifier(new Modifier(shopItem.miningRateUpgradePercentAdd, ModifierType.ADD_PERCENTAGE));

        if(shopItem.miningpowerPercentAdd != 0)
            player.miningpower.AddModifier(new Modifier(shopItem.miningpowerPercentAdd, ModifierType.ADD_PERCENTAGE));

        return result;
    }

    public void BuyItem(ShopItemScriptableObject shopItem) {
        ActiveItemBonus(shopItem);

        if(shopItem.nextUpgrade)
            InstantiateUIItem(shopItem.nextUpgrade);
    }

    void ActiveItemBonus(ShopItemScriptableObject shopItem) {
        PlayerStats player = PlayerStats.instance;

        //Additional Boosts
        if(shopItem.miningMaxTimeUpgradeboostAdd != 0)
            player.miningMaxTime.AddModifier(new Modifier(shopItem.miningMaxTimeUpgradeboostAdd, ModifierType.ADDITION));

        if(shopItem.miningRateUpgradeboostAdd != 0)
            player.miningRate.AddModifier(new Modifier(shopItem.miningRateUpgradeboostAdd, ModifierType.ADDITION));

        if(shopItem.miningpowerBoostAdd != 0)
            player.miningpower.AddModifier(new Modifier(shopItem.miningpowerBoostAdd, ModifierType.ADDITION));

        //Percentage Boosts
        if(shopItem.miningMaxTimeUpgradePercentAdd != 0)
            player.miningMaxTime.AddModifier(new Modifier(shopItem.miningMaxTimeUpgradePercentAdd, ModifierType.ADD_PERCENTAGE));

        if(shopItem.miningRateUpgradePercentAdd != 0)
            player.miningRate.AddModifier(new Modifier(shopItem.miningRateUpgradePercentAdd, ModifierType.ADD_PERCENTAGE));

        if(shopItem.miningpowerPercentAdd != 0)
            player.miningpower.AddModifier(new Modifier(shopItem.miningpowerPercentAdd, ModifierType.ADD_PERCENTAGE));
    }
}
