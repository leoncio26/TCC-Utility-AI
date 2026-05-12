using UnityEngine;

public class FireballAttack : MonoBehaviour
{
    public Fireball fireballPrefab;
    public Transform firePoint;
    public SpriteRenderer sr;

    private bool facingRight = true;

    [SerializeField] private int maxFireballs = 3;
    [SerializeField] private float fireballCooldown = 2f;

    private int currentFireballs;
    private float cooldownTimer;

    void Start()
    {
        currentFireballs = maxFireballs;
    }

    void Update()
    {
        HandleDirection();

        HandleCooldown();

        if (Input.GetKeyDown(KeyCode.B) && currentFireballs > 0)
        {
            Shoot();
        }
    }

    void HandleCooldown()
    {
        if (currentFireballs > 0)
            return;

        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0f)
        {
            currentFireballs = maxFireballs;
        }
    }

    void Shoot()
    {
        Fireball fireball = Instantiate(
            fireballPrefab,
            firePoint.position,
            Quaternion.identity
            );

        Vector2 dir = facingRight ? Vector2.right : Vector2.left;

        fireball.SetDirection(dir);

        currentFireballs--;

        if (currentFireballs <= 0)
        {
            cooldownTimer = fireballCooldown;
        }
    }

    void HandleDirection()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (move > 0)
            facingRight = true;
        else if (move < 0)
            facingRight = false;
    }
}
