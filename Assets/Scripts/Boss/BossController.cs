using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public HealthBar healthBar;
    public SpriteRenderer sr;

    private float life = 100.0f;
    private float maxLife = 100.0f;

    private bool isAttacking;
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
        //   if(isAttacking) animator.Play("AtaqueGiratorio");
        //if (Input.GetMouseButtonDown(0))
        //{
        //    TakeDamage(10);
        //}

        //float dir = Mathf.Sign(playerTransform.position.x - transform.position.x);
        //transform.localScale = new Vector3(Mathf.Sign(dir), 1, 1);

        //Debug.Log("Dir: " + dir);

        //if (dir == 0) return;

        sr.flipX = playerTransform.position.x < transform.position.x;
        //Debug.Log("flipX: " + sr.flipX);
    }

    public void Move(float direction)
    {
        transform.position = new Vector2(direction * speed, transform.position.y);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Dano: " + life);
        life -= damage;
        life = Mathf.Max(life, 0.0f);

        healthBar.UpdateHealthBar(maxLife, life);
    }
}
