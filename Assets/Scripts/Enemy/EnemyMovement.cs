using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    //[SerializeField]
    //private Rigidbody2D rb;

    public void Move(float direction)
    {
        //rb.linearVelocity = new Vector2(
        //    direction * speed,
        //    rb.linearVelocity.y
        //);

        return;

        transform.position += new Vector3(
            direction * speed,
            transform.position.y
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
