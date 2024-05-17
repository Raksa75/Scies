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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerMovement.isInvicible == false)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponentInParent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision_reflect)
    {
        Debug.Log("collision mur");
        if (collision_reflect.gameObject.CompareTag("Wall"))
        {   
            ContactPoint2D contact = collision_reflect.contacts[0];
            direction = Vector2.Reflect(direction, collision_reflect.contacts[0].normal);
            rb.velocity = direction * speed;
        }
    }
}