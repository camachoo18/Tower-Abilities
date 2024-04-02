using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float maxHealth = 10;
    [SerializeField] float currentHealth;
    bool playerIsDead = false;

    public void Heal(float amount)
    {
        ChangeHealth(amount);
    }

    public void ChangeHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if (currentHealth == 0)
            PlayerDied();
    }

    void PlayerDied()
    {
        playerIsDead = true;
        GameEvents.PlayerDied.Invoke();
    }
}
