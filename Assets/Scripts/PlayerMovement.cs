using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of movement
    public float jumpForce = 40.0f; // Jump strength
    private bool isJumping = false;
    private Rigidbody2D rb;
    private HealthManager healthManager;
    private float damageCooldown = 1.0f;
    private float lastDamageTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthManager = GetComponent<HealthManager>();
        if (healthManager == null)
        {
            Debug.LogError("HealthManager component is missing.");
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Horizontal movement
        Vector2 movement = new Vector2(moveHorizontal * speed, rb.velocity.y);
        rb.velocity = movement;

        // Jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    // Detect if the character is on the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    public void TakeDamage(int damage)
    {
        if (Time.time - lastDamageTime > damageCooldown)
        {
            healthManager.TakeDamage(damage);
            lastDamageTime = Time.time;
        }
    }
}
