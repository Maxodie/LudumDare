using UnityEngine;

public class InventoryManager : MonoBehaviour, IInventoryManager {

    //inventory slots
    [SerializeField] int maxStackCount = 99;
    [SerializeField] SlotUI[] slots;
    [SerializeField] Transform slotsParent;

    [SerializeField] Color32 activeSellModeColor;
    [SerializeField] Color32 normalModeColor;
    public Ore re;
    
    void Awake() {
        LoadAllSlotsAtAwake();
    }

    void Start( ) {
        AddItemInInventory(re, 15);
    }

    public void LoadAllSlotsAtAwake() {
        slots = new SlotUI[slotsParent.childCount];

        //Add all slots in the array
        int i=0;
        
        foreach (SlotUI item in slotsParent.GetComponentsInChildren<SlotUI>()) {
            slots[i] = item;
            item.slotBackground.color = normalModeColor;

            i++;
        }
    }

    public bool IsItemInInventory(InventoryItemScriptableObject itemToCheck, int amount) {
        int itemNb = 0;

        for (int i = 0; i < slots.Length; i++) {

            SlotStack slotStack = slots[i].GetCurrentSlotStack();

            if(slotStack.item == itemToCheck) {
                itemNb += slotStack.currentStackCount;
            }

            if(itemNb >= amount) {
                
                return true;
            
            }
        }

        return false;
    }

    public bool IsStillEmptySlot() {
        for(int i=0; i<slots.Length; i++) {
            if(!slots[i].GetCurrentSlotStack().item)
                return true;
        }

        return false;
    }

    //remove the max "amount" he can remove and return the result
    public SlotStack RemoveItemFromInventory(InventoryItemScriptableObject itemToChose, int amount) {
        SlotStack result = new SlotStack();
        result.item = itemToChose;

        int itemNeedToBeRemoved = amount;

        for (int i = 0; i < slots.Length; i++) {

            SlotStack slotStack = slots[i].GetCurrentSlotStack();

            //if the ore in the slot is the good one
            if(slotStack.item == itemToChose) {
                //if there are enough ore in the slot
                if(slots[i].UpdateOreAmount(-itemNeedToBeRemoved)) {
                    result.currentStackCount += itemNeedToBeRemoved;
                    break;
                }
                else { //if we need to get the ore in little amount
                    itemNeedToBeRemoved -= slotStack.currentStackCount;

                    if(slots[i].UpdateOreAmount(-slotStack.currentStackCount)) {
                        result.currentStackCount += slotStack.currentStackCount;
                    }
                }
            }

            if(itemNeedToBeRemoved <= 0)
                break;
        }

        return result;
    }

    /*public SlotStack RemoveOnlIfOreInInventory(Ore oreToChose, int amount) {
        SlotStack result = new SlotStack();
        result.item = oreToChose;

        int oreNeedToBeRemoved = amount;

        List<int> slotStackToRemove = new List<int>();

        for (int i = 0; i < slots.Length; i++) {

            SlotStack slotStack = slots[i].GetCurrentSlotStack();

            //if the ore in the slot is the good one
            if(slotStack.item == oreToChose) {
                //if there are enough ore in the slot
                if(slots[i].UpdateOreAmount(-oreNeedToBeRemoved)) {
                    result.currentStackCount += oreNeedToBeRemoved;
                    break;
                }
                else { //if we need to get the ore in little amount
                    oreNeedToBeRemoved -= slotStack.currentStackCount;

                    //if(slots[i].UpdateAmount(-slotStack.currentStackCount)) {
                    if(slots[i].CanUpdateAmount(-slotStack.currentStackCount)) {
                        result.currentStackCount += slotStack.currentStackCount;

                        slotStackToRemove.Add(i);
                    }
                }
            }

            if(oreNeedToBeRemoved <= 0)
                break;
        }

        if(oreNeedToBeRemoved > 0)
            return null;

        for (int i=0; i<slotStackToRemove.Count; i++) {
            slots[slotStackToRemove[i]].LoadItem(null, 0);
        }


        return result;
    }*/

    public void AddItemInInventory(InventoryItemScriptableObject newItem, int amount) {
        for (int i = 0; i < slots.Length; i++) {
            SlotStack slotStack = slots[i].GetCurrentSlotStack();

            //check if we can add an ore in another slot wich have the ore and enough place
            if(slotStack.item == newItem && slotStack.currentStackCount < maxStackCount) {
                //check if all the ore can fit in the slot
                if(slotStack.currentStackCount + amount <= maxStackCount) {
                    slots[i].UpdateOreAmount(amount);
                    return;
                }
                else {
                    //if the slot is too small to get all the ore in one slot
                    int slotSizeDifference = slotStack.currentStackCount + amount - maxStackCount;
                    slots[i].UpdateOreAmount(amount - slotSizeDifference);

                    AddItemInInventory(newItem, slotSizeDifference);
                    return;
                }
            }
        }

        //if there are no ore emplacement then create one in the inventory
        for (int i = 0; i < slots.Length; i++) {
            SlotStack slotStack = slots[i].GetCurrentSlotStack();

            //an empty slot
            if(slotStack.item == null) {

                if(amount > maxStackCount) {
                    slots[i].LoadItem(newItem, maxStackCount);
                    AddItemInInventory(newItem, amount - maxStackCount);
                }
                else
                    slots[i].LoadItem(newItem, amount);

                return;
            }
        }
    }

    //call when sell mode is actived
    public void OnActiveSellMode() {
        ChangeSlotsColor(activeSellModeColor);
    }

    //call when the sell mode is over
    public void OnEndSellMode() {
        ChangeSlotsColor(normalModeColor);
    }

    void ChangeSlotsColor(Color32 color) {
        for(int i=0; i<slots.Length; i++) {
            slots[i].slotBackground.color = color;
        }
    }
}

public class SlotStack {
    public int currentStackCount = 0;
    public InventoryItemScriptableObject item = null;
}

public interface IInventoryManager {
    public void OnActiveSellMode();
    public void OnEndSellMode();
}