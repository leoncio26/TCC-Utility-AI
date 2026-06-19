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

    public float bossLifeNormalized;
    public float attackRange = 1.5f;
    public float moveSpeed = 3f;
    public float lastLeapTime = 3f;

    public bool playerIsAttackingMelee = false;

    public bool executing = false;
    public float globalCooldown = 0.0f;

    [Header("Projetil")]
    public bool incomingProjectileDetected = false;
    public bool isBlocking = false;
    public float projectilReactionTime = 0.0f;


    [Header("Area Bounds")]
    public Transform leftLimit;
    public Transform rightLimit;

    public bool isTerremotoAtaque = false;

    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bossController = GetComponent<BossController>();
        //animator = GetComponent<EnemyAnimator>();
        combat = GetComponent<EnemyCombat>();
    }
}
