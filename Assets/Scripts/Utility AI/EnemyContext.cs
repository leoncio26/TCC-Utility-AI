using UnityEngine;

public class EnemyContext : MonoBehaviour
{
    public Transform player;
    public PlayerController playerController;
    public CapangaController capangaController;
    public BossController bossController;
    public EnemyAnimator animator;
    public EnemyCombat combat;
    public float attackRange = 1.5f;
    public float moveSpeed = 3f;
    public float lastLeapTime = 3f;
    public bool isLeaping;

    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capangaController = GetComponent<CapangaController>();
        bossController = GetComponent<BossController>();
        animator = GetComponent<EnemyAnimator>();
        combat = GetComponent<EnemyCombat>();
    }
}
