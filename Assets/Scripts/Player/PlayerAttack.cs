using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public BossController boss;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private EnemyContext enemyContext;

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.Play("Attack", -1);
            enemyContext.playerIsAttackingMelee = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            Debug.Log("OnTriggerEnter2D Boss");
            boss.TakeDamage(10.0f);
        }
    }
}
