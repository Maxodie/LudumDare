using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerInputController : MonoBehaviour
{
    PlayerInputs playerInputs;
    
    [SerializeField] Animator amin;
    WaitForSeconds wait;

    [SerializeField] AnimationClip miningAnim;

    bool canCancelMining = true;

    void Awake() {
        wait = new WaitForSeconds(miningAnim.length/2);
    }

    private void OnEnable()
    {
        playerInputs = new PlayerInputs();
        playerInputs.Player.Enable();

        playerInputs.Player.Mining.started += StartMining;
        playerInputs.Player.Mining.canceled += StopMining;
    }


    public void StartMining(InputAction.CallbackContext context)
    {
        if(!PlayerController.instance.canPlay) return;

        PlayerController.instance.isMining = true;
        amin.SetBool("IsSleeping", false);
        amin.SetBool("isMining", true);
        amin.ResetTrigger("StartIdle");

        StartCoroutine(CheckMinimumMiningTime());
    }

    public void StopMining(InputAction.CallbackContext context)
    {
        if(!PlayerController.instance.canPlay) return;

        amin.ResetTrigger("StartIdle");
        PlayerController.instance.isMining = false;
    
        if(canCancelMining) {
            amin.SetBool("isMining", false);
        }
    }

    IEnumerator CheckMinimumMiningTime() {
        canCancelMining = false;

        yield return wait;

        if(!PlayerController.instance.isMining)
            amin.SetBool("isMining", false);

        canCancelMining = true;
    }
}
