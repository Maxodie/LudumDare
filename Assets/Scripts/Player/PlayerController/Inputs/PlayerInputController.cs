using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    PlayerInputs playerInputs;


    private void Awake()
    {
        playerInputs = new PlayerInputs();

        playerInputs.Player.Mining.started += StartMining;
        playerInputs.Player.Mining.canceled += StopMining;
    }

    public void StartMining(InputAction.CallbackContext context)
    {
        PlayerController.instance.isMining = true;
    }

    public void StopMining(InputAction.CallbackContext context)
    {
        PlayerController.instance.isMining = false;
    }
}
