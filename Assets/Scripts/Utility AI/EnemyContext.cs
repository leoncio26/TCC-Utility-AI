using UnityEngine;

public class EnemyContext : MonoBehaviour
{
    public Transform player;
    public CapangaController capangaController;
    public float attackRange = 1.5f;
    public float moveSpeed = 3f;
    public EnemyAnimator animator;
    public EnemyCombat combat;

    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capangaController = GetComponent<CapangaController>();
        animator = GetComponent<EnemyAnimator>();
        combat = GetComponent<EnemyCombat>();
    }
}
