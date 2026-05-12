using UnityEngine;

public class EnemyContext : MonoBehaviour
{
    public Transform player;
    public PlayerController playerController;
    public BossController bossController;
    public Animator animator;
    public EnemyCombat combat;
    public EnemyMovement movement;
    public AnimatorController animatorController;
    public HealthBar bossHealthBar;

    public float attackRange = 1.5f;
    public float moveSpeed = 3f;
    public float lastLeapTime = 3f;
    public bool isLeaping;
    public bool executing = false;
    public bool incomingProjectileDetected = false;
    public bool isBlocking = false;

    [Header("Area Bounds")]
    public Transform leftLimit;
    public Transform rightLimit;

    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bossController = GetComponent<BossController>();
        //animator = GetComponent<EnemyAnimator>();
        combat = GetComponent<EnemyCombat>();
    }
}
