using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    //[SerializeField]
    //private Rigidbody2D rb;

    public void Move(float direction)
    {
        transform.position += new Vector3(
            direction * speed * Time.deltaTime,
            0,
            0
        );
    }

    public void Stop()
    {
       // rb.linearVelocity = Vector2.zero;
    }

    public void FaceDirection(float direction)
    {
        transform.localScale = new Vector3(
            Mathf.Sign(direction),
            1,
            1
        );
    }
}
