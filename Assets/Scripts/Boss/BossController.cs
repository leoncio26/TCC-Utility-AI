using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public HealthBar healthBar;
    public SpriteRenderer sr;
    public EnemyContext context;

    private float life = 100.0f;
    private float maxLife = 100.0f;

    public bool playerAttacking;

    private Rigidbody2D rb;

    [SerializeField]
    private Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            //Debug.Log("Est� defendendo com escudo");
            return;
        }

        Debug.Log("Dano: " + life);
        life -= damage;
        life = Mathf.Max(life, 0.0f);

        healthBar.UpdateHealthBar(maxLife, life);
    }

    public void Flip(float direction)
    {
        Vector3 scale = transform.localScale;
        scale.x = direction > 0 ? 1 : -1;
        transform.localScale = scale;
    }
}
