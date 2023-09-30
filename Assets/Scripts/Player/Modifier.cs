//Used to modify character stats. Can be an addition mlodifier or a percentage modifier
//AddPercentage modifier needs to be from 0 to 1
public class Modifier {
    //Type and value
    public ModifierType modifierType;
    public float value;

    //Constructor
    public Modifier(float value, ModifierType mType) {
        this.value = value;
        modifierType = mType;
    }
}

//Modifier type
public enum ModifierType {
    ADDITION = 0,
    ADD_PERCENTAGE = 1
}