using UnityEngine;
using System.Collections;
using TMPro;

public class NotificationSystem : MonoBehaviour {
    public static NotificationSystem instance;
    [SerializeField] TMP_Text notifText;
    float animTime = 2f;

    bool isCurrentNotifs = false;

    void Awake() {
        if(!instance) instance = this;

        notifText.gameObject.SetActive(false);
    }

    public void MakeNotif(Color textColor, string text) {
        if(isCurrentNotifs) return;

        notifText.gameObject.SetActive(true);
        notifText.color = textColor;
        notifText.text = $"{text}";

        isCurrentNotifs = true;
        StartCoroutine(NotifCoroutine());
    }

    IEnumerator NotifCoroutine() {
        yield return new WaitForSeconds(animTime);

        notifText.gameObject.SetActive(false);
        isCurrentNotifs = false;
    }
}
