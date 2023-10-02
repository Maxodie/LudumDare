using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [SerializeField] PlayerController playerController;
    [SerializeField] WallCreator wallCreator;

    void Awake() {
        if(!instance) instance = this;
        else Destroy(gameObject);
    }

    void Start() {
        StartParty();
    }

    void StartParty() {
        playerController.ResetPlayer();

        wallCreator.StartGeneration();
    }

    public void EndParty() {
        CircleWipeController.instance.FadeOut();
        wallCreator.ResetWall();

        StartParty();
    }
}
