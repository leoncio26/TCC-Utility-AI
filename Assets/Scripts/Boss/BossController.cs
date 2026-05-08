using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public Transform leftLimit;
    public Transform rightLimit;

    [Header("Spin Attack")]
    public float spinDuration = 1.5f;
    public float spinSpeed = 12f;
    public float rotationSpeed = 1080f;
    public float windupTime = 0.4f;
    public float recoveryTime = 0.5f;
    public EnemyContext context;

    private bool isAttacking;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     //   if(isAttacking) animator.Play("AtaqueGiratorio");
    }

    public void Move(float direction)
    {
        transform.position = new Vector2(direction * speed, transform.position.y);
    }
}
