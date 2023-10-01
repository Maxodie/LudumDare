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

        statsText.text += "Space Bar Time <b>" + playerStats.miningMaxTime.GetBaseValue() + "(<color=#4DEA52>" + playerStats.miningMaxTime.GetTotalModifierValue() + "</color>)s</b><sprite=6>\n";
        statsText.text += "";

        statsText.text += "Mining Rate <b>" + playerStats.miningpower.GetBaseValue() + "(<color=#4DEA52>" + playerStats.miningpower.GetTotalModifierValue() + "</color>)</b><sprite=5>\n";

        statsText.text += "Mining Power <b>" + playerStats.miningRate.GetBaseValue() + "(<color=#4DEA52>" + playerStats.miningRate.GetTotalModifierValue() + "</color>)</b><sprite=4>\n";
        
        statsText.text += "Ore Per Drop <b>" + playerStats.miningOreReceived.GetBaseValue() + "(<color=#4DEA52>" + playerStats.miningOreReceived.GetTotalModifierValue() + "</color>)</b><sprite=9>\n";

    }
}
