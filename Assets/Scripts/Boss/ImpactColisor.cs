using UnityEngine;

public class ImpactColider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colidiu com o Impacto");
            collision.GetComponent<PlayerController>().TakeDamage(30);
        }
    }
}
