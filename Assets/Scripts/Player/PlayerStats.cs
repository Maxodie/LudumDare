using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats instance;

    [SerializeField] float miningMaxTimeBaseStat = 10f;
    CharacterStat miningMaxTime;

    [SerializeField] float currenMoney = 0f;

    void Awake() {
        if(!instance) instance = this;
        else Destroy(gameObject);

        miningMaxTime = new CharacterStat(miningMaxTimeBaseStat);
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
