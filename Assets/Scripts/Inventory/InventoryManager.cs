using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

    //inventory slots
    [SerializeField] int maxStackCount = 99;
    [SerializeField] SlotUI[] slots;
    [SerializeField] Transform slotsParent;

    [SerializeField] Ore testOre;

    public Ore ore;
    
    void Awake() {
        LoadAllSlotsAtAwake();
        StartCoroutine(test());
    }

    IEnumerator test() {
        AddOreInInventory(testOre, 5);
        yield return new WaitForSeconds(2f);

        RemoveOreInInventory(testOre, 2);
        yield return new WaitForSeconds(2f);

        RemoveOreInInventory(ore, 150);
        yield return new WaitForSeconds(2f);
    }


    public void LoadAllSlotsAtAwake() {
        slots = new SlotUI[slotsParent.childCount];

        //Add all slots in the array
        int i=0;
        
        foreach (SlotUI item in slotsParent.GetComponentsInChildren<SlotUI>()) {
            slots[i] = item;

            i++;
        }
    }

    //remove the max "amount" he can remove and return the result
    public SlotStack RemoveOreInInventory(Ore oreToChose, int amount) {
        SlotStack result = new SlotStack();
        result.item = oreToChose;

        int oreNeedToBeRemoved = amount;

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
                    int difference = oreNeedToBeRemoved - slotStack.currentStackCount;

                    if(slots[i].UpdateOreAmount(-difference)) {
                        result.currentStackCount += difference;
                        oreNeedToBeRemoved -= difference;
                    }
                }
            }

            if(oreNeedToBeRemoved <= 0)
                break;
        }

        return result;
    }

    public void AddOreInInventory(Ore newOre, int amount) {
        for (int i = 0; i < slots.Length; i++) {
            SlotStack slotStack = slots[i].GetCurrentSlotStack();

            //check if we can add an ore in another slot wich have the ore and enough place
            if(slotStack.item == newOre && slotStack.currentStackCount < maxStackCount) {
                //check if all the ore can fit in the slot
                if(slotStack.currentStackCount + amount <= maxStackCount) {
                    slotStack.currentStackCount += amount;
                    return;
                }
                else {
                    //if the slot is too small to get all the ore in one slot
                    int slotSizeDifference = slotStack.currentStackCount + amount - maxStackCount;
                    slotStack.currentStackCount += amount - slotSizeDifference;

                    AddOreInInventory(newOre, slotSizeDifference);
                    return;
                }
            }
        }

        //if there are no ore emplacement then create one in the inventory
        for (int i = 0; i < slots.Length; i++) {
            SlotStack slotStack = slots[i].GetCurrentSlotStack();

            //an empty slot
            if(slotStack.item == null) {
                slots[i].LoadItem(ore, amount);
                return;
            }
        }
    }
}

[System.Serializable]
public class SlotStack {
    public int currentStackCount = 0;
    public Ore item = null;
}