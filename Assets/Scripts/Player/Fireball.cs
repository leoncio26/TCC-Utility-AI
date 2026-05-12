using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 8f;
    public SpriteRenderer sr;
    public Transform initialPosition;

    private Vector2 direction;

    private void Awake()
    {
        initialPosition = transform;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        sr.flipX = dir.x < 0;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Shield") || other.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Boss"))
        {
            //Debug.Log("Fireball acertou o boss");
            other.GetComponent<BossController>().TakeDamage(5);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        Debug.Log("Fireball destruida");
    }
}
