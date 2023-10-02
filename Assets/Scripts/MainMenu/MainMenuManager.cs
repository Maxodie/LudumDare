using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] CircleWipeController circleWipeController;
    [SerializeField] Vector2 startTransitionOffset;

    [SerializeField] Slider masterVolume;
    [SerializeField] Slider musicVolume;
    [SerializeField] Slider effectVolume;

    [SerializeField] GameObject optionPanel;

    void Start() {
        optionPanel.SetActive(false);
        circleWipeController.FadeOut(startTransitionOffset);

        masterVolume.value = PlayerPrefs.GetFloat("MasterVolume", masterVolume.value);
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume", musicVolume.value);
        effectVolume.value = PlayerPrefs.GetFloat("EffectsVolume", effectVolume.value);


        audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        audioMixer.SetFloat("EffectsVolume", PlayerPrefs.GetFloat("EffectsVolume"));
    }

    public void OpenOptionMenu() {
        optionPanel.SetActive(!optionPanel.activeSelf);
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();
    }

    public void SetMasterValue(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    public void SetMusicValue(float value)
    {
        audioMixer.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void SetEffectsValue(float value)
    {
        audioMixer.SetFloat("EffectsVolume", value);
        PlayerPrefs.SetFloat("EffectsVolume", value);
    }
}