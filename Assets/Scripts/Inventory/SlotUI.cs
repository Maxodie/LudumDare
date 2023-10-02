using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour {
    SellOreSystem sellOreSystem;

    [SerializeField] Image slotIcon;
    public Image slotBackground;

    [SerializeField] TMP_Text slotNumberText;

    SlotStack currentSlotStack;

    [SerializeField] AudioSource audioSource;

    void Awake() {
        currentSlotStack = new SlotStack();

        LoadItem(null, 0);
    }

    void Start() {
        sellOreSystem = SellOreSystem.instance;
    }

    public void LoadItem(InventoryItemScriptableObject item, int amount) {
        currentSlotStack.item = item;

        if(item) {
            currentSlotStack.currentStackCount = amount;
            slotIcon.sprite = currentSlotStack.item.icon;
            slotIcon.color = Color.white;
        }
        else {
            slotIcon.sprite = null;
            currentSlotStack.currentStackCount = 0;
            slotIcon.color = new Color(0, 0, 0, 0);
        }

        slotNumberText.text = currentSlotStack.currentStackCount.ToString("0");
    }

    public ref SlotStack GetCurrentSlotStack() {
        return ref currentSlotStack;
    }

    public bool CanUpdateAmount(int amount) {
        return currentSlotStack.currentStackCount + amount >= 0;
    }

    public bool UpdateOreAmount(int amount) {
        if(!CanUpdateAmount(amount)) return false;

        currentSlotStack.currentStackCount += amount;

        slotNumberText.text = currentSlotStack.currentStackCount.ToString("0");

        if(currentSlotStack.currentStackCount == 0)
            LoadItem(null, 0);

        return true;
    }

    //used on sell mode activated
    public void OnClick() {
        if(!sellOreSystem.sellMode) return;

        audioSource.Play();

        if(!currentSlotStack.item) {
            sellOreSystem.OnEndSellMode();
            return;
        }

        int price = currentSlotStack.item.price * currentSlotStack.currentStackCount;

        PlayerStats.instance.UpdateMoney(price);

        NotificationSystem.instance.MakeNotif(new Color(142, 255, 136), $"{currentSlotStack.item.itemName} has been sold for {price}<sprite=3>");

        LoadItem(null, 0);

        sellOreSystem.OnEndSellMode();
    }
}
