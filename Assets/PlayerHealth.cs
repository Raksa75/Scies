using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Logique pour gérer la mort du personnage (par exemple, afficher un écran de game over, recharger le niveau, etc.)
        Debug.Log("Game Over");
    }
}
