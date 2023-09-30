using UnityEngine;

public class PlayerStats : MonoBehaviour {

    [SerializeField] float miningMaxTimeBaseStat = 10f;
    CharacterStat miningMaxTime;

    [SerializeField] float currenMoney = 0f;

    void Awake() {
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
