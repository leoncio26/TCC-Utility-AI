using UnityEngine;

public class FireballAttack : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public SpriteRenderer sr;

    private bool facingRight = true;

    void Update()
    {
        HandleDirection();

        if (Input.GetKeyDown(KeyCode.B))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject fireball = Instantiate(
            fireballPrefab,
            firePoint.position,
            Quaternion.identity
        );

        Vector2 dir = facingRight ? Vector2.right : Vector2.left;

        fireball.GetComponent<Fireball>().SetDirection(dir);
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
