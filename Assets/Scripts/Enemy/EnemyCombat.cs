using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float attackRange = 3f;
    public float attackCooldown = 1f;
    public int damage = 10;

    private float lastAttackTime;

    public bool CanAttack()
    {
        return Time.time >= lastAttackTime + attackCooldown;
    }

    public void Attack(Transform self, Transform player)
    {
        lastAttackTime = Time.time;

        float dist = Mathf.Abs(self.position.x - player.position.x);
        if (dist <= attackRange)
        {
            // aqui você chamaria o método de dano do jogador
            Debug.Log("Dano aplicado no jogador");
        }
    }
}
