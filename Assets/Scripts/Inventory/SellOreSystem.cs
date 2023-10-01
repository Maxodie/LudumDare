using UnityEngine;
using UnityEngine.UI;

public class SellOreSystem : MonoBehaviour, IInventoryManager {

    public static SellOreSystem instance;
    [SerializeField] InventoryManager inventoryManager;

    public bool sellMode {get; private set;}

    [SerializeField] Image buttonImage;
    [SerializeField] Sprite selectedBtnSprite;
    [SerializeField] Sprite normalBtnSprite;

    void Awake() {
        if(!instance) instance = this;
        else Destroy(gameObject);
    }

    public void OnActiveSellMode() {
        if(!sellMode) {
            sellMode = true;

            inventoryManager.OnActiveSellMode();
            buttonImage.sprite = selectedBtnSprite;
        }
        else
            OnEndSellMode();
    }

    public void OnEndSellMode() {
        sellMode = false;

        inventoryManager.OnEndSellMode();
        buttonImage.sprite = normalBtnSprite;
    }
}
