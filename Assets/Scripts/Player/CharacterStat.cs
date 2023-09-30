using System;
using System.Collections.Generic;

[Serializable]
public class CharacterStat {
    //Check if 'lastValue' should be modified and update it or not
    public float value {get {
        return isDirty ? UpdateDirtyValue() : lastValue;
    }}

    List<Modifier> modifiers = new List<Modifier>();

    float baseValue;
    float lastValue = 0f;
    bool isDirty = true;

    //Constructor
    public CharacterStat(float defaultValue) {
        baseValue = defaultValue;
        isDirty = true;
    }

    //Change the baseValue
    public void ChangeBaseValue(float newValue) {
        baseValue = newValue;
        isDirty = true;
    }

    public float GetBaseValue() {
        return baseValue;
    }

    //Add a modifier item on 'modifiers'
    public void AddModifier(Modifier newModifier) {
        modifiers.Add(newModifier);
        isDirty = true;
    }

    //Remove the first iterated modifier from 'modifiers' list
    public void RemoveModifier(Modifier modifierToRemove) {
        for(int i=0; i<modifiers.Count; i++) {
            if(modifiers[i].value == modifierToRemove.value && modifiers[i].modifierType == modifierToRemove.modifierType) {
                modifiers.RemoveAt(i);
                isDirty = true;
                return;
            }
        }
    }

    //Update the value
    float UpdateDirtyValue() {
        float total = baseValue;
        float totalPercentage = 0;
        //It place 'addition' first and 'AddPercentage' in second
        modifiers.Sort(new SortModifier());

        //Add modifier to the baseValue
        foreach(Modifier mod in modifiers) {
            if(mod.modifierType == ModifierType.ADDITION)
                total += mod.value;
            else if(mod.modifierType == ModifierType.ADD_PERCENTAGE)
                totalPercentage += mod.value;
        }

        //Add final percentage and round it with '0.00' format
        total *= 1+totalPercentage;
        lastValue = (float)Math.Round(total, 2);

        isDirty = false;
        return lastValue;
    }

    public float GetTotalModifierValue() {
        return value - baseValue;
    }
}

//Used to sort modifiers list to have the addition modifier in first and AddPercentage modifier in second
public class SortModifier : IComparer<Modifier> {
    public int Compare(Modifier a, Modifier b) {
        return a.modifierType == ModifierType.ADD_PERCENTAGE ? -1 : 1;
    }
}

public enum CharacterStatGeneralTypes {
    PHYSIC = 0,
    MAGIC = 1
}