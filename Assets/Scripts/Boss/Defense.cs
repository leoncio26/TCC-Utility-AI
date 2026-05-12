using UnityEngine;

public class Defense : MonoBehaviour
{
    public EnemyContext context;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projetil"))
        {
            Debug.Log("Projetil se aproximando");
            context.incomingProjectileDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Projetil"))
        {
            Debug.Log("Projetil saiu");
            context.incomingProjectileDetected = false;
        }
    }
}
