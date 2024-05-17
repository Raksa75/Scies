using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;


    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isDashing = false;
    private float dashTime;
    private float dashCooldownTime;

    static public bool isInvicible = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > dashCooldownTime)
        {
            StartCoroutine(Invicibility());
            StartDash();
        }

        else
        {
            if (Time.time >= dashTime)
            {
                EndDash();
            }
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            rb.velocity = moveInput.normalized * dashSpeed;
        }
        else
        {
            rb.velocity = moveInput * speed;
        }
    }

    void StartDash()
    {
        isDashing = true;
        dashTime = Time.time + dashDuration;
        dashCooldownTime = Time.time + dashCooldown;
    }

    void EndDash()
    {
        isDashing = false;
    }
    private IEnumerator Invicibility()
    {
        isInvicible = true;
        yield return new WaitForSeconds(0.2f);
        isInvicible = false;
    }
}



