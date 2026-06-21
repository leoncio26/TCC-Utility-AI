using UnityEngine;

public class GiratorioColisor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colidiu com o Giratorio");
            collision.GetComponent<PlayerController>().TakeDamage(30);
        }
    }
}
