using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f; // Velocidad de movimiento
    public float jumpForce = 5.0f; // Fuerza del salto
    private bool isJumping = false; // Controla si el personaje está saltando
    private Rigidbody2D rb;
    public int health = 5; // Vida del jugador

    public Text healthText; // Referencia al Text UI

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (healthText == null)
        {
            healthText = GameObject.Find("PlayerHealthText").GetComponent<Text>();
        }
        UpdateHealthUI();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Movimiento horizontal
        Vector2 movement = new Vector2(moveHorizontal * speed, rb.velocity.y);
        rb.velocity = movement;

        // Salto
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    // Detecta si el personaje está en el suelo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthUI();

        if (health <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
        else
        {
            Debug.LogError("Health Text UI element is not assigned.");
        }
    }

    void Die()
    {
        // Lógica de muerte del jugador
        Debug.Log("Player Died");
    }
}
