using UnityEngine;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Epitaph/ShopItem", order = 0)]
public class ShopItemScriptableObject : ScriptableObject {
    [Header("Defaults")]
    public bool isSpawnAtStart = true;
    public string itemName;
    public Sprite itemIcon;
    public int cost;
    public ShopItemScriptableObject nextUpgrade;

    [Header("Boosts addition")]
    public float miningMaxTimeUpgradeboostAdd;
    public float miningRateUpgradeboostAdd;
    public int miningpowerBoostAdd;
    public int miningOreReceivedBoostAdd;

    [Header("Percent Add")]
    public float miningMaxTimeUpgradePercentAdd;
    public float miningRateUpgradePercentAdd;
    public int miningpowerPercentAdd;
    public int miningOreReceivedPercentAdd;
}
