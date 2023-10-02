using UnityEngine;
using UnityEngine.UI;

public class UtilityMenuManager : MonoBehaviour {
    [SerializeField] Tab[] tabs;
    [SerializeField] Sprite normalPanel;
    [SerializeField] Sprite selectedPanel;

    [SerializeField] AudioSource SwitchPanelSound;

    int currentSelectedPanel;

    void Awake() {
        SelectPanel(0);
    }

    public void SelectPanel(int panelId) {

        if (currentSelectedPanel != panelId)
        {
            SwitchPanelSound.Play();
        }

        if(panelId == tabs.Length-1) {
            for(int i=tabs.Length-1; i>=0; i--) {
                tabs[i].tab.SetAsFirstSibling();
                DisableTab(i);
            }
        }
        else {
            for(int i=0; i<tabs.Length; i++) {
                tabs[i].tab.SetAsFirstSibling();
                DisableTab(i);
            }
        }

        tabs[panelId].tab.SetAsLastSibling();
        tabs[panelId].tabImage.sprite = selectedPanel;   
        tabs[panelId].window.SetActive(true);

        currentSelectedPanel = panelId;
    }

    void DisableTab(int tabId) {
        tabs[tabId].tabImage.sprite = normalPanel; 
        tabs[tabId].window.SetActive(false);
    }
}

[System.Serializable]
public class Tab {
    public Transform tab;
    public Image tabImage;
    public GameObject window;
}