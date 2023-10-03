using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [SerializeField] CircleWipeController circleWipeController;
    [SerializeField] PlayerController playerController;
    [SerializeField] WallCreator wallCreator;
    [SerializeField] Vector2 startFadeOffset;
    public Vector2 endFadeOffset;

    [SerializeField] AudioMixer audioMixer;

    public EnvironnementManager[] environnementManagers;

    void Awake() {
        if(!instance) instance = this;
        else Destroy(gameObject);

        
        audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        audioMixer.SetFloat("EffectsVolume", PlayerPrefs.GetFloat("EffectsVolume"));
    }

    void Start() {
        StartParty();
    }

    void StartParty() {
        circleWipeController.FadeOut(startFadeOffset);
        playerController.ResetPlayer();

        wallCreator.StartGeneration();
    }

    public void EndParty() {
        wallCreator.ResetWall();

        ResetEnvironnement();

        StartParty();
    }

    public void ResetEnvironnement()
    {
        foreach (EnvironnementManager manager in environnementManagers)
        {
            manager.ResetEnvironnement();
        }
    }
}
