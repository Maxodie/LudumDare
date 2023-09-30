using UnityEngine;

[CreateAssetMenu(fileName = "New Ore", menuName = "Ore")]
public class Ore : ScriptableObject
{
    public GameObject prefab;
    public Sprite icon;

    public new string name;
    public int hardness;
    public int rarity;
    public int price;
}
