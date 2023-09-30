using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour {
    [SerializeField] Image slotIcon;

    [SerializeField] TMP_Text slotNumberText;

    [SerializeField] SlotStack currentSlotStack;

    void Awake() {
        currentSlotStack = new SlotStack();

        LoadItem(null, 0);
    }

    public void LoadItem(Ore ore, int amount) {
        currentSlotStack.item = ore;

        if(ore) {
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

    bool CanUpdateAmount(int amount) {
        return currentSlotStack.currentStackCount >= amount;
    }

    public bool UpdateOreAmount(int amount) {
        if(!CanUpdateAmount(amount)) return false;

        currentSlotStack.currentStackCount += amount;

        if(currentSlotStack.currentStackCount == 0)
            LoadItem(null, 0);

        return true;
    }
}
