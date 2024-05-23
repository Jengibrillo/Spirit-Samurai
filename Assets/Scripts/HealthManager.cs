using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 5; // Maximum health
    private int currentHealth; // Current health
    public Text healthText; // Reference to the Text UI

    private GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to update the health UI
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
        else
        {
            Debug.LogError("Health Text UI element is not assigned.");
        }
    }

    // Method to handle player's death
    void Die()
    {
        Debug.Log("Player Died");
        gameManager.GameOver();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.SetActive(false);
        }
    }

    // Method to heal the player
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthUI();
    }
}
