using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour {
    [SerializeField] Image slotIcon;

    [SerializeField] TMP_Text slotNumberText;

    SlotStack currentSlotStack;

    public void LoadItem(SlotStack slotStack) {
        currentSlotStack = slotStack;

        //slotIcon.sprite = item.icon
        //slotNumberText.text = slotStack.currentStackCount;
    }
}
