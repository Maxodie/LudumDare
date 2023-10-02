using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour {
    [SerializeField] TMP_Text statsText;
    PlayerStats playerStats;

    void Start() {
        playerStats = PlayerStats.instance;
    }

    //call with a button
    public void UpdateStatsText() {
        statsText.text = "";

       // transform.GetChil

        statsText.text += "<size=34>Space Bar Time : <b>" + playerStats.miningMaxTime.value + 
        "s<sprite=6></size> | <size=24>Details : (<color=#4DEA52>+" + playerStats.miningMaxTime.GetTotalValueByType(ModifierType.ADDITION) +
        "</color>), (<color=#4DEA52>+" + playerStats.miningMaxTime.GetTotalValueByType(ModifierType.ADD_PERCENTAGE) + "%</color>)</b></size>\n";

        statsText.text += "<size=34>Mining Power : <b>" + playerStats.miningpower.value + 
        "<sprite=8></size> | <size=24>Details : (<color=#4DEA52>+" + playerStats.miningpower.GetTotalValueByType(ModifierType.ADDITION) + 
        "</color>), (<color=#4DEA52>+" + playerStats.miningpower.GetTotalValueByType(ModifierType.ADD_PERCENTAGE) + "%</color>)</b></size>\n";

        statsText.text += "<size=34>Mining Rate : <b>" + playerStats.miningRate.value + 
        "<sprite=5></size> | <size=24>Details : (<color=#4DEA52>+" + playerStats.miningRate.GetTotalValueByType(ModifierType.ADDITION) + 
        "</color>), (<color=#4DEA52>+" + playerStats.miningRate.GetTotalValueByType(ModifierType.ADD_PERCENTAGE) + "%</color>)</b></size>\n";

        statsText.text += "<size=34>Minerals Per Drop : <b>" + playerStats.miningOreReceived.value + 
        "<sprite=9></size> | <size=24>Details : (<color=#4DEA52>+" + playerStats.miningOreReceived.GetTotalValueByType(ModifierType.ADDITION) + 
        "</color>), (<color=#4DEA52>+" + playerStats.miningOreReceived.GetTotalValueByType(ModifierType.ADD_PERCENTAGE) + "%</color>)</b></size>\n";

        statsText.text += "<size=34>Walk Speed : <b>" + playerStats.walkSpeed.value + 
        "<sprite=4></size> | <size=24>Details : (<color=#4DEA52>+" + playerStats.walkSpeed.GetTotalValueByType(ModifierType.ADDITION) + 
        "</color>), (<color=#4DEA52>+" + playerStats.walkSpeed.GetTotalValueByType(ModifierType.ADD_PERCENTAGE) + "%</color>)</b></size>\n";

    }
}
