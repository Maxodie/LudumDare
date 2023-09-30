using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats instance;

    [SerializeField] float miningMaxTimeBaseStat = 10f;
    public CharacterStat miningMaxTime;

    [SerializeField] float miningRateBaseStat = 5f;
    public CharacterStat miningRate;

    [SerializeField] int miningpowerBaseStat = 1;
    public CharacterStat miningpower;

    [SerializeField] float currenMoney = 0f;

    void Awake() {
        if(!instance) instance = this;
        else Destroy(gameObject);

        miningMaxTime = new CharacterStat(miningMaxTimeBaseStat);
        miningRate = new CharacterStat(miningRateBaseStat);
        miningpower = new CharacterStat(miningpowerBaseStat);
    }

    public ref CharacterStat GetCharacterStat() {
        return ref miningMaxTime;
    }

    bool canUpdateMoney(float amount) {
        return amount <= currenMoney;
    }

    public bool UpdateMoney(float amount) {
        if(!canUpdateMoney(amount)) return false;

        currenMoney += amount;
        return true;
    }
}
