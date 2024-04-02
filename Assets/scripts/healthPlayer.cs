using UnityEngine;

public class healthPlayer : MonoBehaviour
{
    [SerializeField] int startingHealth = 10;
    int currentHealth;
    [HideInInspector] public bool gameOver = false;
    [SerializeField] SpriteRenderer healthIndicator;

    Color fullHealthColor = Color.green;
    Color zeroHealthColor = Color.red;

    void Start()
    {
        currentHealth = startingHealth;
        UpdateHealthColor();
    }

    public void UpdateHealthColor()
    {
        float healthPercentage = (float)currentHealth / startingHealth;
        healthIndicator.color = Color.Lerp(zeroHealthColor, fullHealthColor, healthPercentage);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        if (currentHealth == 0)
        {
            GameEvents.PlayerDied.Invoke();
            gameOver = true;
        }

        UpdateHealthColor();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);
        UpdateHealthColor();
    }
}
