using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UtilityMenuManager : MonoBehaviour {
    [SerializeField] Tab[] tabs;
    [SerializeField] Sprite normalPanel;
    [SerializeField] Sprite selectedPanel;

    void Awake() {
        SelectPanel(0);
        StartCoroutine(Test());
    }

    IEnumerator Test() {
        yield return new WaitForSeconds(2f);
        Debug.Log("1");
        SelectPanel(1);
        yield return new WaitForSeconds(2f);
        SelectPanel(2);
    }


    void SelectPanel(int panelId) {
        if(panelId == tabs.Length-1) {
            for(int i=tabs.Length-1; i>0; i--) {
                tabs[i].tab.SetAsLastSibling();
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