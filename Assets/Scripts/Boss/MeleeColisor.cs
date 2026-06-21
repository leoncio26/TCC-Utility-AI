using UnityEngine;

public class MeleeColisor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colidiu com o martelo");
            collision.GetComponent<PlayerController>().TakeDamage(10);
        }
    }
}
