// Script enemyMovement.cs
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Transform playerTransform;
    [SerializeField] int enemyDamage = 1;
    bool playerIsDead = false;
    bool enemyIsDead = false;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        GameEvents.PlayerDied.AddListener(OnPlayerDeath);
        GameEvents.EnemyDied.AddListener(OnEnemyDeath);
    }

    void OnPlayerDeath()
    {
        playerIsDead = true;
    }

    void OnEnemyDeath()
    {
        enemyIsDead = true;
    }

    void Update()
    {
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer = directionToPlayer.normalized;

        if (playerIsDead)
        {
            transform.position -= directionToPlayer * speed * Time.deltaTime;
        }
        else
        {
            transform.position += directionToPlayer * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthPlayer playerHealth = collision.gameObject.GetComponent<healthPlayer>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(enemyDamage);

                Vector3 directionToPlayer = playerTransform.position - transform.position;
                transform.position -= directionToPlayer * speed * Time.deltaTime;

                Destroy(gameObject); // Destruir el enemigo al tocar al jugador
            }
        }
        else if (collision.gameObject.CompareTag("Proyectil"))
        {
            enemyHealth enemyHealth = GetComponent<enemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(enemyDamage);

                Vector3 directionToPlayer = playerTransform.position - transform.position;
                transform.position -= directionToPlayer * speed * Time.deltaTime;
            }
        }
    }
}
