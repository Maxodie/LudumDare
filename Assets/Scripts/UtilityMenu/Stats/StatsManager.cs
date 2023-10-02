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

        statsText.text += "<size=36>Space Bar Time : <b>" + playerStats.miningMaxTime.value + 
        "s</size>\n<size=25>Details : (<color=#4DEA52>+" + playerStats.miningMaxTime.GetTotalValueByType(ModifierType.ADDITION) +
        "</color>), (<color=#4DEA52>+" + playerStats.miningMaxTime.GetTotalValueByType(ModifierType.ADD_PERCENTAGE) + "%</color>)</b><sprite=6></size>\n";

        statsText.text += "<size=36>Mining Power : <b>" + playerStats.miningpower.value + 
        "</size>\n<size=25>Details : (<color=#4DEA52>+" + playerStats.miningpower.GetTotalValueByType(ModifierType.ADDITION) + 
        "</color>), (<color=#4DEA52>+" + playerStats.miningpower.GetTotalValueByType(ModifierType.ADD_PERCENTAGE) + "%</color>)</b><sprite=8></size>\n";

        statsText.text += "<size=36>Mining Rate : <b>" + playerStats.miningRate.value + 
        "</size>\n<size=25>Details : (<color=#4DEA52>+" + playerStats.miningRate.GetTotalValueByType(ModifierType.ADDITION) + 
        "</color>), (<color=#4DEA52>+" + playerStats.miningRate.GetTotalValueByType(ModifierType.ADD_PERCENTAGE) + "%</color>)</b><sprite=5></size>\n";

        statsText.text += "<size=36>Minerals Per Drop : <b>" + playerStats.miningOreReceived.value + 
        "</size>\n<size=25>Details : (<color=#4DEA52>+" + playerStats.miningOreReceived.GetTotalValueByType(ModifierType.ADDITION) + 
        "</color>), (<color=#4DEA52>+" + playerStats.miningOreReceived.GetTotalValueByType(ModifierType.ADD_PERCENTAGE) + "%</color>)</b><sprite=9></size>\n";

        statsText.text += "<size=36>Walk Speed : <b>" + playerStats.walkSpeed.value + 
        "</size>\n<size=25>Details : (<color=#4DEA52>+" + playerStats.walkSpeed.GetTotalValueByType(ModifierType.ADDITION) + 
        "</color>), (<color=#4DEA52>+" + playerStats.walkSpeed.GetTotalValueByType(ModifierType.ADD_PERCENTAGE) + "%</color>)</b><sprite=4></size>\n";

    }
}
