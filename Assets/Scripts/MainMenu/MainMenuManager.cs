using UnityEngine;

public class MainMenuManager : MonoBehaviour {
    [SerializeField] CircleWipeController circleWipeController;
    [SerializeField] Vector2 startTransitionOffset;

    void Start() {
        circleWipeController.FadeOut(startTransitionOffset);
    }
}
