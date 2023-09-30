using UnityEngine;

public class InventoryManager : MonoBehaviour {

    //inventory slots
    [SerializeField] int maxStackCount = 99;
    SlotUI[] slots;
    [SerializeField] Transform slotsParent;
    
    void Awake() {
        LoadAllSlotsAtAwake();
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

    //SlotStack GetSlotStack() {

    //}
}

public class SlotStack {
    public int currentStackCount = 0;
    //[SerializeField] item;
}