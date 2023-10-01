using UnityEngine;

[CreateAssetMenu(fileName = "New Ore", menuName = "Epitaph/Ore")]
public class Ore : InventoryItemScriptableObject
{
    public Sprite[] sprites;
    public int hardness;
    public int rarityWeight;
    public int depthMin;
    public int depthMax;
}
