using UnityEngine;

public class enemyHealth : MonoBehaviour
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

    void UpdateHealthColor()
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
            GameEvents.EnemyDied.Invoke();
            gameOver = true;

            Destroy(gameObject);
        }

        UpdateHealthColor();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);
        UpdateHealthColor();
    }

    // Método para manejar las colisiones Trigger con el proyectil
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Proyectil"))
        {
            LinearMovement projectile = other.GetComponent<LinearMovement>();
            if (projectile != null)
            {
                TakeDamage(2); // Ajusta el daño según sea necesario
                Destroy(other.gameObject);
            }
        }
        if (other.CompareTag("BigBullet"))
        {
            LinearMovement projectile = other.GetComponent<LinearMovement>();
            if (projectile != null)
            {
                TakeDamage(5); // Ajusta el daño según sea necesario
                Destroy(other.gameObject);
            }
        }
    }


    // Método para manejar las colisiones Trigger con el jugador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthPlayer playerHealth = collision.gameObject.GetComponent<healthPlayer>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(2); // Ajusta el daño según sea necesario
                Destroy(gameObject); // Esto puede removerse si prefieres manejar la destrucción en enemyMovement
            }
        }
    }
}
