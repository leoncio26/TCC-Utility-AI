using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 8f;
    public SpriteRenderer sr;

    private Vector2 direction;

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
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        Debug.Log("Fireball destruida");
    }
}
