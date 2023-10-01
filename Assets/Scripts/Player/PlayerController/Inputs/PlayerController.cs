using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] WallCreator wallCreator;

    public Transform raycastOrigin;

    public bool isMining;
    public bool iscurrentlymining;

    [SerializeField] float distanceToMine = 2f;

    GameObject targetedObject;

    float spaceBarTimer;

    MiningState miningState;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        ResetSpaceBarTimer();
    }

    public void ResetSpaceBarTimer()
    {
        spaceBarTimer = PlayerStats.instance.miningMaxTime.value;
    }

    private void Update()
    {
        if (isMining)
        {
            if (spaceBarTimer > 0f)
            {
                spaceBarTimer -= Time.deltaTime;
                if (targetedObject == null)
                {
                    RaycastHit2D hit;
                    hit = Physics2D.Raycast(raycastOrigin.position, transform.right, distanceToMine);
                    if (hit) targetedObject = hit.transform.gameObject;
                    else
                    {
                        transform.position += Vector3.right * 1 * Time.deltaTime;
                    }
                }
                else if (!iscurrentlymining)
                {
                    iscurrentlymining = true;
                    StartCoroutine(MiningCoroutine(targetedObject.transform.GetComponent<ObjectData>().objectData));
                }
            }
        }
        
    }

    public IEnumerator MiningCoroutine(Ore objectData)
    {
        int blocHardness = objectData.hardness;
        int numberOfState = objectData.sprites.Length;

        int durabilityBetweenState = blocHardness / numberOfState;

        if (miningState == null)
        {
            int currentState = numberOfState - 1;

            int remainingDurability = blocHardness;

            miningState = new MiningState(currentState, remainingDurability);
        }

        while (miningState.remainingDurability > 0)
        {
            Debug.Log(miningState.remainingDurability);
            if (miningState.remainingDurability <= durabilityBetweenState * miningState.currentState)
            {
                targetedObject.transform.GetComponent<SpriteRenderer>().sprite = objectData.sprites[miningState.currentState];

                miningState.currentState --;
            }

            miningState.remainingDurability -= (int)PlayerStats.instance.miningpower.value;
            yield return new WaitForSeconds(PlayerStats.instance.miningRate.value);
            if (spaceBarTimer < 0f || !isMining)
            {
                iscurrentlymining = false;
                yield break;
            }
        }
        miningState = null;
        iscurrentlymining = false;

        GameObject blockBelow = targetedObject.transform.GetComponent<ObjectData>().blockBelow;

        if (!blockBelow) wallCreator.CreateWall();
        
        Destroy(targetedObject.transform.gameObject);
        
        if (blockBelow != null)
        {
            targetedObject = blockBelow;
        }
    }
}

public class MiningState
{
    public int currentState;
    public int remainingDurability;

    public MiningState(int currentState, int remainingDurability)
    {
        this.currentState = currentState;
        this.remainingDurability = remainingDurability;
    }
}
