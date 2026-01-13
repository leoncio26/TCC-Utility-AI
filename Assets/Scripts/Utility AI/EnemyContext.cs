using UnityEngine;

public class EnemyContext : MonoBehaviour
{
    public Transform player;
    public float attackRange = 1.5f;
    public float moveSpeed = 3f;

    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
