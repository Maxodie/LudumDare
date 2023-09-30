using UnityEngine;

[CreateAssetMenu(fileName = "New Ore", menuName = "Ore")]
public class Ore : ScriptableObject
{
    public GameObject prefab;
    public Sprite icon;

    public new string name;
    public int rarity; // 1 = super rare, 30 = rare, 100 = common;
    public int price;
}
