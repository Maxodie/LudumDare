using UnityEngine;

[CreateAssetMenu(fileName = "New Ore", menuName = "Epitaph/Ore")]
public class Ore : InventoryItemScriptableObject
{
    public Sprite[] sprites;

    public Sprite damagedCorner;

    public Sprite damagedBorder;

    public int hardness;
    public int rarityWeight;
    public int depthMin;
    public int depthMax;
}
