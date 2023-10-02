using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemUI : MonoBehaviour {
    ShopItemScriptableObject shopItem;
    ShopManager shopManager;

    [SerializeField] Image icon;
    [SerializeField] TMP_Text textTitle;
    [SerializeField] TMP_Text textDescription;
    [SerializeField] TMP_Text textPrice;

    AudioSource audioSource;

    public void LoadShopUI(ShopItemScriptableObject shopItem, ShopManager shopManager, AudioSource audioSource) {
        this.shopItem = shopItem;
        this.shopManager = shopManager;
        this.audioSource = audioSource;

        icon.sprite = shopItem.itemIcon;
        textTitle.text = shopItem.itemName;

        textDescription.text = shopManager.GetItemDescription(shopItem);
        textPrice.text = shopItem.cost.ToString("0") + "<sprite=3>";
    }

    public void BuyBtn() {
        audioSource.Play();

        if(PlayerStats.instance.UpdateMoney(-shopItem.cost))
            shopManager.BuyItem(shopItem, this);
        else
            NotificationSystem.instance.MakeNotif(new Color(255, 150, 150), "Not enough money to buy it");
    }
}
