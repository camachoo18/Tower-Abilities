using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Heal Ability")]
public class HealAbility : Ability
{
    healthPlayer health;
    [SerializeField] Image HealAbilityIcon;

    void Start()
    {
        HealAbilityhIcon.fillAmount = 1f;
        
    }

    void Update()
    {
        if (isCooldown)
        {
            HealAbilityIcon.fillAmount = Mathf.Clamp01(elapsedCooldown / cooldown);
        }
    }


    public override void PlayerTransform(Transform player)
    {

    }


    public override void Trigger(Vector3 direction, MonoBehaviour mbCoroutine)
    {

        if (elapsedCoolDown == 0)
        {

            health = mbCoroutine.GetComponent<healthPlayer>();
            health.Heal(5);
            health.UpdateHealthColor();


            mbCoroutine.StartCoroutine(coolDownCouroutine());
        }

        else if (elapsedCoolDown >= CoolDown)
        {
            elapsedCoolDown = 0;
        }
    }
}
