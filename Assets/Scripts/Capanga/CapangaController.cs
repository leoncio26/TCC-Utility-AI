using UnityEngine;

public class CapangaController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    }

    public void Move(float direction)
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    public void FaceDirection(float direction)
    {
        if (direction == 0) return;
        sprite.flipX = direction < 0;
    }
}
