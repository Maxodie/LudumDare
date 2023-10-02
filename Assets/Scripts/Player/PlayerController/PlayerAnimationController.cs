using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;

    [SerializeField] ParticleSystem particle;

    public float timeBetweenEachAnim = 10f;

    public float timer = 0f;

    void Start() {
        animator = GetComponent<Animator>();

        DoIdleAnim();
    }

    public void ResetAnim() {
        animator.SetBool("IsDeath", false);
    }

    void Update() {
        timer += Time.deltaTime;

        if(timer >= timeBetweenEachAnim) {
            DoIdleAnim();
            timer = 0f;
        }
    }

    public void ActiveBreakingParticules()
    {
        if (PlayerController.instance.iscurrentlymining)
            particle.Play();
    }

    public void DoIdleAnim()
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

        animator.SetTrigger("StartIdle");
    }

    public void OnDeath() {
        animator.SetBool("IsDeath", true);
    }
}
