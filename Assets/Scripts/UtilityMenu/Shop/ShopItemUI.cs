using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemUI : MonoBehaviour {
    [SerializeField] ShopItemScriptableObject shopItem;
    ShopManager shopManager;

    [SerializeField] Image icon;
    [SerializeField] TMP_Text textTitle;
    [SerializeField] TMP_Text textDescription;

    public void LoadShopUI(ShopItemScriptableObject shopItem, ShopManager shopManager) {
        this.shopItem = shopItem;
        this.shopManager = shopManager;

        icon.sprite = shopItem.itemIcon;
        textTitle.text = shopItem.itemName;


    }

    public void BuyBtn() {
        if(PlayerStats.instance.UpdateMoney(-shopItem.cost))
            shopManager.BuyItem(shopItem);
        //else
            //TODO notif not enough money
    }
}
