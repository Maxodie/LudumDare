using UnityEngine;

[CreateAssetMenu(fileName = "New Ore", menuName = "Epitaph/Ore")]
public class Ore : ScriptableObject
{
    public GameObject prefab;
    public Sprite icon;
    public Sprite[] sprites;

    public new string name;
    public int hardness;
    public int rarityWeight;
    public int price;
    public int depthMin;
    public int depthMax;
}
