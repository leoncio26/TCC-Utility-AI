using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float speed;
    [SerializeField] private int addJumps;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;
    private Animator anim;
    private CapsuleCollider2D colliderPlayer;
    private float moveX;

    private float life = 100.0f;
    private float maxLife = 100.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colliderPlayer = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        if (isGrounded)
        {
            addJumps = 1;
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && addJumps > 0)
            {
                addJumps--;
                Jump();
            }
        }

        //if(life <= 0)
        //{
        //    this.enabled = false;
        //    colliderPlayer.enabled = false;
        //    rb.gravityScale = 0;
        //    anim.Play("Die", -1);
        //}

    }

    void FixedUpdate()
    {
        Move();
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        Debug.Log("Pula");
        anim.SetBool("IsJump", true);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Console.WriteLine("Verifica colis�o com o ch�o");
            anim.SetBool("IsJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        if(moveX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("IsRun", true);
        }
        else if(moveX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        life = Mathf.Max(0, life);

        healthBar.UpdateHealthBar(maxLife, life);

        if (life == 0) Die();
    }

    private void Die()
    {
        GameSession.Result = GameResult.Defeat;
        SceneManager.LoadScene(1);
    }
}
