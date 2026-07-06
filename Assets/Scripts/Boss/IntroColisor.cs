using UnityEngine;

public class IntroColisor : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colidiu no intro colider");
            animator.enabled = true;
            animator.Play("Cutscene");
            gameObject.SetActive(false);
        }
    }
}
