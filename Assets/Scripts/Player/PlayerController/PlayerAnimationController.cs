using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public static PlayerAnimationController instance;

    public Animator animator;

    [SerializeField] ParticleSystem particle;

    public float TimeBetweenEachAnim = 10f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ActiveBreakingParticules()
    {
        if (PlayerController.instance.iscurrentlymining)
            particle.Play();
    }

    public void SetIdleIndex()
    {
        int randomIndex = Random.Range(0, 50);
        if (randomIndex < 30)
        {
            animator.SetInteger("indexIdle", 1);
        }
        else if (randomIndex < 35)
        {
            animator.SetInteger("indexIdle", 2);
        }
        else
            animator.SetInteger("indexIdle", 3);
    }

    public void SetInAnim()
    {
        animator.SetBool("inAnim", true);
    }

    public void RemoveInAnim()
    {
        StartCoroutine(RemoveInAnimCoroutine());
    }

    IEnumerator RemoveInAnimCoroutine()
    {
        yield return new WaitForSeconds(TimeBetweenEachAnim);

        animator.SetBool("inAnim", false);
    }
}
