using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private EnemyContext context;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private bool playerAttacking;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject terremotoPrefab;
    [SerializeField] private Transform spawnPoint;

    private float life = 100.0f;
    private float maxLife = 100.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Mathf.Sign(playerTransform.position.x - transform.position.x);
        Flip(dir);
    }

    public void Move(float direction)
    {
        transform.position = new Vector2(direction * speed, transform.position.y);
    }

    public void TakeDamage(float damage)
    {
        if (context.isBlocking)
        {
            //Debug.Log("Está defendendo com escudo");
            return;
        }

        Debug.Log("Dano: " + life);
        life -= damage;
        life = Mathf.Max(life, 0.0f);
        context.bossLifeNormalized = life/maxLife;

        healthBar.UpdateHealthBar(maxLife, life);
    }

    public void Flip(float direction)
    {
        Vector3 scale = transform.localScale;
        scale.x = direction > 0 ? 1 : -1;
        transform.localScale = scale;
    }

    public void SpawnEarthquake()
    {
        if (!context.isTerremotoAtaque) return;

        GameObject quake = Instantiate(
            terremotoPrefab,
            spawnPoint.position,
            Quaternion.identity);

        float direction = Mathf.Sign(playerTransform.position.x - transform.position.x);

        quake.GetComponent<TerremotoAtaque>()
             .Initialize(direction > 0 ? 1 : -1);

        context.isTerremotoAtaque = false;
    }
}
