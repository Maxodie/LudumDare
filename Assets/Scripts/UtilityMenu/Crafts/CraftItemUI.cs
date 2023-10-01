using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftItemUI : MonoBehaviour {
    CraftScriptableObject craft;
    CraftManager craftManager;

    [SerializeField] Image icon;
    [SerializeField] TMP_Text textTitle;
    [SerializeField] TMP_Text textDescription;
    [SerializeField] TMP_Text textPrice;

    public void LoadCraftUI(CraftScriptableObject craft, CraftManager craftManager) {
        this.craft = craft;
        this.craftManager = craftManager;

        icon.sprite = craft.craftVisual;

        if(craft.isCraftGiveEquipedItem) {
            textTitle.text = craft.itemGived.itemName;
            textDescription.text = craftManager.GetItemDescription(craft);
        }
        else {
            textTitle.text = craft.oreGived.itemName;
            textDescription.text = craft.oreGived.defaultDescription;
        }

        
        textPrice.text = craftManager.GetPriceText(craft);
    }

    public void CraftItem() {
        if(!craftManager.OnCraft(craft, this)) {
            NotificationSystem.instance.MakeNotif(new Color(255, 150, 150), "Not enough resources to craft it");
        }
    }
}
