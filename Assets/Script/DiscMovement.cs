using UnityEngine;

public class DiscMovement : MonoBehaviour
{
    public int damageAmount = 1;
    public float speed = 5f;
    private Vector2 direction;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomDirection();
    }

    public void SetRandomDirection()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
            rb.velocity = direction * speed;
        }
    }
}
