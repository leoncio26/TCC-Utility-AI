using UnityEngine;

public class TerremotoAtaque : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float lifeTime = 3f;

    private int direction = 1;
    public void Initialize(int dir)
    {
        direction = dir;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }
}
