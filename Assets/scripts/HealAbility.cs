using UnityEngine;

public class HealAbility : ClasePadre
{
    healthPlayer health;

    public override void Trigger(Vector3 direction)
    {
        
        if (elapsedCoolDown == 0)
        {
            
            health = GetComponent<healthPlayer>();
            health.Heal(5);
            health.UpdateHealthColor();

            
            StartCoroutine(coolDownCouroutine());
        }

        else if (elapsedCoolDown >= CoolDown)
        {
            elapsedCoolDown = 0;
        }
    }
}
