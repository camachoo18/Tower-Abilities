using UnityEngine;

public class HealAbility : Ability
{
    healthPlayer health;

    public override void Trigger(Vector3 direction)
    {

        if (elapsedCooldown == 0)
        {

            health = GetComponent<healthPlayer>();
            health.Heal(5);
            health.UpdateHealthColor();

         
            StartCoroutine(coolDownCouroutine());
        }
        
        else if (elapsedCooldown >= coolDown)
        {
            elapsedCooldown = 0;
        }
    }
}
