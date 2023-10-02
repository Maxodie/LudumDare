using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    public PlayerController controller;

    [SerializeField] ParticleSystem breakingParticle;
    [SerializeField] ParticleSystem deathParticle;

    public float timeBetweenEachAnim = 10f;

    public float timer = 0f;

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void ResetAnim() {
        timer = 0f;
        animator.SetBool("IsDeath", false);
        animator.SetTrigger("Spawn");
    }

    //Called in death annimation
    public void FadeInEndScreen() {
        CircleWipeController.instance.FadeIn(GameManager.instance.endFadeOffset);
    }

    public void ReactivePlayMode() {
        PlayerController.instance.canPlay = true;
    }

    void Update() {
        timer += Time.deltaTime;

        if(timer >= timeBetweenEachAnim) {
            DoIdleAnim();
            timer = 0f;
        }

        if (controller.targetedObject != null)
            animator.SetFloat("MiningSpeed", 1 + (60 * PlayerStats.instance.miningRate.value /controller.targetedObject.GetComponent<ObjectData>().objectData.hardness));
    }

    public void ActiveBreakingParticules()
    {
        if (PlayerController.instance.iscurrentlymining)
            breakingParticle.Play();
    }

    public void ActiveDeathParticules()
    {
        if (PlayerController.instance.iscurrentlymining)
            deathParticle.Play();
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

        animator.SetInteger("indexIdle", 2);
        animator.SetTrigger("StartIdle");

    }

    public void OnDeath() {
        animator.SetBool("IsDeath", true);
        animator.SetBool("isMining", false);
    }
}
