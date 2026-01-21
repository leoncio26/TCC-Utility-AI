using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;

    private static readonly int AttackHash =
        Animator.StringToHash("Attack");
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        animator.Play("CapangaAttack");
    }
}
