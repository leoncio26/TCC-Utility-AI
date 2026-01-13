using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Keeper"))
        {
            //collision.GetComponent<KeeperController>().Die();
        }

        if (collision.CompareTag("Gizmo"))
        {
            //collision.GetComponent<GizmoController>().life--;
        }
    }
}
