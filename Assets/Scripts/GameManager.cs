using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [SerializeField] CircleWipeController circleWipeController;
    [SerializeField] PlayerController playerController;
    [SerializeField] WallCreator wallCreator;
    [SerializeField] Vector2 startFadeOffset;
    public Vector2 endFadeOffset;

    void Awake() {
        if(!instance) instance = this;
        else Destroy(gameObject);
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

        StartParty();
    }
}
