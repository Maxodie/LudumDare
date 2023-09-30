using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour {
    [SerializeField] Image slotIcon;

    [SerializeField] TMP_Text slotNumberText;

    [SerializeField] SlotStack currentSlotStack;

    void Awake() {
        currentSlotStack = new SlotStack();
    }

    public void LoadItem(SlotStack slotStack) {
        currentSlotStack = slotStack;

        slotIcon.sprite = slotStack.item.icon;
        slotNumberText.text = slotStack.currentStackCount.ToString("0");
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
            currentSlotStack.item = null;

        return true;
    }
}
