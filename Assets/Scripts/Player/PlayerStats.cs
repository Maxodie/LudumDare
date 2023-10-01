using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats instance;

    [SerializeField] float miningMaxTimeBaseStat = 10f;
    public CharacterStat miningMaxTime;

    [SerializeField] float miningRateBaseStat = 5f;
    public CharacterStat miningRate;

    [SerializeField] int miningpowerBaseStat = 1;
    public CharacterStat miningpower;

    [SerializeField] int miningOreReceivedBaseStat = 1;
    public CharacterStat miningOreReceived;

    [SerializeField] float currentMoney = 0f;

    [SerializeField] TMP_Text currentMoneyText;

    public int depth = 0;

    void Awake() {
        if(!instance) instance = this;
        else Destroy(gameObject);

        miningMaxTime = new CharacterStat(miningMaxTimeBaseStat);
        miningRate = new CharacterStat(miningRateBaseStat);
        miningpower = new CharacterStat(miningpowerBaseStat);
        miningOreReceived = new CharacterStat(miningOreReceivedBaseStat);

        UpdateMoneyUI();
    }

    public ref CharacterStat GetCharacterStat() {
        return ref miningMaxTime;
    }

    bool canUpdateMoney(float amount) {
        return currentMoney + amount >= 0;
    }

    public bool UpdateMoney(float amount) {
        if(!canUpdateMoney(amount)) return false;

        currentMoney += amount;
        UpdateMoneyUI();
        return true;
    }

    void UpdateMoneyUI() {
        currentMoneyText.text = currentMoney.ToString("0") + "<sprite=3>";
    }
}
