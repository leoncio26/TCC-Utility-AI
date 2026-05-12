using UnityEngine;

public class Defense : MonoBehaviour
{
    public EnemyContext context;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projetil"))
        {
            //Debug.Log("Projetil se aproximando");
            var fireball = collision.GetComponent<Fireball>();
            float dist = fireball.transform.position.x - transform.position.x;
            //Debug.Log("Dist: " +  dist);

            context.incomingProjectileDetected = true;
            context.projectilReactionTime = dist > 0.4f ? 0 : 0.4f;
            //Debug.Log("Tempo de rea��o: " + context.projectilReactionTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Projetil"))
        {
            //Debug.Log("Projetil saiu");
            context.incomingProjectileDetected = false;
        }
    }
}
